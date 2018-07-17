using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OpenDoorAPI;
using System.IO;
using OpenDoorAPI.Contracts;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;

namespace OpenDoorAPI.Controllers
{
    public class VisitorIdentificationController : ApiController
    {

        // GET: api/VisitorIdentification
        public string Get()
        {
            return string.Empty;
        }

        // GET: api/VisitorIdentification/5
        public string Get(int id)
        {
            return string.Empty;
        }

        // POST: api/VisitorIdentification
        //Task<VisitorIdentificationResultDTO>
        public async Task<VisitorIdentificationResultDTO> Post([FromBody]VisitorIdentificationRequestDTO requestDTO)
        {

            VisitorIdentificationResultDTO ResultDTO = new VisitorIdentificationResultDTO();
            using (var db = new EFOpenDoor_Context())
            {
                Log log = null;

                Visitor visitor = db.Visitor.FirstOrDefault(b => b.RFCCard.ToLower() == requestDTO.RFCData.ToLower());
                if (visitor == null)
                {

                    UserProfile user = db.UserProfile.FirstOrDefault(u => u.Fname == "Anonymous");
                    log = new Log() { IsOpen = false, LoginDateTime = DateTime.Now, RFCCard = requestDTO.RFCData, UserProfile = user, Picture = null, UserProfileId = user.UserID };
                    ResultDTO.Result = VisitorIdentificationResults.FaildIdentification;
                    //db.Log.Add(log);
                    //db.SaveChanges();
                }
                else
                {
					if (!visitor.IsActive)
					{
						log = new Log() { IsOpen = false, LoginDateTime = DateTime.Now, RFCCard = requestDTO.RFCData, Picture = requestDTO.Picture, UserProfile = visitor.UserProfile, UserProfileId = visitor.UserProfileId };
						ResultDTO.Result = VisitorIdentificationResults.FaildIdentification;
					}
					else
					{
						if (visitor.IsTemp)
						{
							log = new Log() { IsOpen = true, LoginDateTime = DateTime.Now, RFCCard = requestDTO.RFCData, UserProfile = visitor.UserProfile, UserProfileId = visitor.UserProfileId, Picture = null };
							ResultDTO.Result = VisitorIdentificationResults.OpenDoor;
						}
						else
						{
							if (requestDTO.Picture == null)
							{
								ResultDTO.Result = VisitorIdentificationResults.RetakeImage;
							}
							else
							{
								var isVerified = await FaceVerifiedFunc(requestDTO.Picture, visitor);

								if (isVerified)
								{
									log = new Log() { IsOpen = true, LoginDateTime = DateTime.Now, RFCCard = requestDTO.RFCData, Picture = requestDTO.Picture, UserProfile = visitor.UserProfile, UserProfileId = visitor.UserProfileId };
									ResultDTO.Result = VisitorIdentificationResults.OpenDoor;
								}
								else
								{
									log = new Log() { IsOpen = false, LoginDateTime = DateTime.Now, RFCCard = requestDTO.RFCData, Picture = requestDTO.Picture, UserProfile = visitor.UserProfile, UserProfileId = visitor.UserProfileId };
									ResultDTO.Result = VisitorIdentificationResults.FaildIdentification;
								}
							}
						}
					}
                }
                if (log != null)
                {
                    db.Log.Add(log);
                    db.SaveChanges();
                }
            }
            return ResultDTO;
        }

        async Task<bool> FaceVerifiedFunc(string Picture, Visitor _Visitor)
        {
            var pic =ImageConvert.Base64ToByteArray(Picture);
            FaceAPI fAPI = new FaceAPI();
            return await fAPI.VerifyFaceFunc(pic, _Visitor);
        }


    }
}
