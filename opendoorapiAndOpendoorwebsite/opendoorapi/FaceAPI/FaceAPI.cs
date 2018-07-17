using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System.Windows;

namespace OpenDoorAPI
{
    public class FaceAPI
    {
        /* https://www.microsoft.com/cognitive-services/en-US/subscriptions
         * https://docs.microsoft.com/en-us/azure/cognitive-services/face/tutorials/faceapiincsharptutorial
         * 
         * nugets install: Newtonsoft.Json,Microsoft.ProjectOxford.Face
         */

        const string GROUP_ID = "employees";
        const string key = "c8ab1755f38a4c1dbfdd1b5fcae6ffa6";//"b668a6d7f5b84c2f8d40b0ee28f1c900";
        //Guid personID;
        private readonly IFaceServiceClient faceServiceClient = new FaceServiceClient("b668a6d7f5b84c2f8d40b0ee28f1c900");




        public async Task<bool> VerifyFaceFunc(byte[] imageFilebytes, Visitor visitor)
        {
            try
            {
                var faceId = await GetFaceId(new MemoryStream(imageFilebytes));
                var verification = await faceServiceClient.VerifyAsync(faceId, GROUP_ID, visitor.ProfileImgID);
                return verification.IsIdentical;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        async Task<Guid> GetFaceId(Stream imageFileStream)
        {
            using (imageFileStream)
            {
                var faces = await faceServiceClient.DetectAsync(imageFileStream);
                return faces[0].FaceId;
            }
        }
        private async Task<Guid> CreatePerson(string name)
        {
            //await _faceServiceClient.CreatePersonGroupAsync(GROUP_ID, "employees");
            var person = await faceServiceClient.CreatePersonAsync(GROUP_ID, name);
            return person.PersonId;
        }

        public async Task<Guid> CreateFace(byte[]img,int userID)
        {
            Guid guidNumber=await CreatePerson(userID.ToString());


			await UploadFaces(img, guidNumber);
			
            return guidNumber;
        }

        private async Task<bool> UploadFaces(byte [] profileImg, Guid profileImgID)
        {
            Stream imageFileStream = new MemoryStream(profileImg);
            try
            {
                using (imageFileStream)
                {
                    await faceServiceClient.AddPersonFaceAsync(GROUP_ID, profileImgID, imageFileStream);
					return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}