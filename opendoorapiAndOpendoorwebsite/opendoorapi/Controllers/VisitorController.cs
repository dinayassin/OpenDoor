using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OpenDoorAPI.Contracts;
using AutoMapper;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Text;

namespace OpenDoorAPI.Controllers
{
    public class VisitorController : ApiController
    {
      

        [AllowAnonymous]
        [Route("api/Visitor/RFCExists")]
        public string RFCExists(RFCCardExistsDTO RFC)
        {

            JavaScriptSerializer seralizer = new JavaScriptSerializer();
            using (var db = new EFOpenDoor_Context())
            {
                var userV = db.Visitor.FirstOrDefault(u => u.RFCCard.ToLower() == RFC.RFCStr.ToLower() && u.UserProfile.UserID != RFC.UserID);
                if (userV == null)
                    return seralizer.Serialize(false);
                else
                    return seralizer.Serialize(true);
            }
        }

        // POST: api/Visitor/VisitorById
        [AllowAnonymous]
        [Route("api/Visitor/VisitorById")]
        public string VisitorById([FromBody]int id)
        {

            JavaScriptSerializer seralizer = new JavaScriptSerializer();
            using (var db = new EFOpenDoor_Context())
            {
                var userV = db.Visitor.FirstOrDefault(u => u.UserProfile.UserID == id);
                return seralizer.Serialize(Mapper.Map<VisitorDTO>(userV));
            }
        }


        // POST: api/Visitor/DeleteVisitor
        [AllowAnonymous]
        [Route("api/Visitor/VisitorDelete")]
        public void VisitorDelete([FromBody]int id)
        {

            using (var db = new EFOpenDoor_Context())
            {
                var userV = db.Visitor.FirstOrDefault(u => u.UserProfile.UserID == id);
                if (userV != null)
                {
                    db.Visitor.Remove(userV);
                    db.SaveChanges();
                }
            }
        }


        [AllowAnonymous]
        [Route("api/Visitor/CreateEdit")]
        public async Task<string> CreateEdit([FromBody]VisitorDTO input)
        {
            JavaScriptSerializer seralizer = new JavaScriptSerializer();
            try
            {
                using (var db = new EFOpenDoor_Context())
                {
                    var visitor = db.Visitor.FirstOrDefault(u => u.UserProfile.UserID == input.UserProfileId);
                    var userProfile = db.UserProfile.FirstOrDefault(u => u.UserID == input.UserProfileId);
                    if (visitor != null)
                    {
                        visitor.UserProfileId = input.UserProfileId;
                        visitor.UserProfile = userProfile;
                        visitor.IsActive = input.IsActive;
                        visitor.IsTemp = input.IsTemp;
                        if (visitor.ProfileImg != input.ProfileImg)
                        {

                            if (input.ProfileImg != null && input.ProfileImg != "")
                            {
                                byte[] imgbyte = ImageConvert.Base64ToByteArray(input.ProfileImg);
                                visitor.ProfileImgID = await (new FaceAPI()).CreateFace(imgbyte, userProfile.UserID);
                                if (visitor.ProfileImgID == new System.Guid("00000000-0000-0000-0000-000000000000"))
                                    return seralizer.Serialize(false); //error
                                visitor.ProfileImg = input.ProfileImg;
                            }
                        }
                        visitor.RFCCard = input.RFCCard;

                    }
                    else
                    {
                        visitor = new Visitor();
                        visitor.UserProfileId = input.UserProfileId;
                        visitor.UserProfile = userProfile;
                        visitor.IsActive = input.IsActive;
                        visitor.IsTemp = input.IsTemp;
                        if (input.ProfileImg != null && input.ProfileImg != "")
                        {
                            byte[] imgbyte = Convert.FromBase64String(input.ProfileImg);
                            visitor.ProfileImgID = await (new FaceAPI()).CreateFace(imgbyte, userProfile.UserID);
                            if (visitor.ProfileImgID == new System.Guid("00000000-0000-0000-0000-000000000000"))
                                return seralizer.Serialize(false); //error
                            visitor.ProfileImg = input.ProfileImg;
                        }
                        visitor.RFCCard = input.RFCCard;
                        db.Visitor.Add(visitor);
                    }
                    db.SaveChanges();
                    return seralizer.Serialize(true);
                }
            }
            catch (Exception ex)
            { }
            return seralizer.Serialize(false); //error
        }

         }
}
