using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OpenDoorAPI.Contracts;
using AutoMapper;
using System.Web.Script.Serialization;

namespace OpenDoorAPI.Controllers
{
    public class UserProfileController : ApiController
    {
        // GET: api/UserProfile
        public IEnumerable<UserProfileDTO> Get()
        {
            using (var db = new EFOpenDoor_Context())
            {
                var users = db.UserProfile.Where(u => u.IsDelete == false && u.SystemUser == false);
                return Mapper.Map<IEnumerable<UserProfileDTO>>(users.ToList());
            }
        }

        // GET: api/UserProfile/5
        [AllowAnonymous]
        public UserProfileDTO Get(int id)
        {
            using (var db = new EFOpenDoor_Context())
            {
                var userProfile = db.UserProfile.FirstOrDefault(u => u.UserID == id);
                return Mapper.Map<UserProfileDTO>(userProfile);
            }
        }

        [AllowAnonymous]
        [Route("api/UserProfile/UserProfileData")]
        public string UserProfileData([FromBody]int id)
        {
            JavaScriptSerializer seralizer = new JavaScriptSerializer();
            using (var db = new EFOpenDoor_Context())
            {
                var userProfile = db.UserProfile.FirstOrDefault(u => u.UserID == id);
                return seralizer.Serialize(Mapper.Map<UserProfileDTO>(userProfile));
            }
        }


        [AllowAnonymous]
        [Route("api/UserProfile/CreateEdit")]
        public string CreateEdit([FromBody]UserProfileDTO input)
        {
            JavaScriptSerializer seralizer = new JavaScriptSerializer();
            try
            {
                using (var db = new EFOpenDoor_Context())
                {
                    var userProfile = db.UserProfile.FirstOrDefault(u => u.UserID == input.UserID);
                    if (userProfile != null)
                    {
                        userProfile.Phone = input.Phone;
                        userProfile.Lname = input.Lname;
                        userProfile.Fname = input.Fname;
                        userProfile.Email = input.Email;
                        userProfile.Address = input.Address;
                    }
                    else
                    {
                        userProfile = Mapper.Map<UserProfile>(input);
                        db.UserProfile.Add(userProfile);
                    }
                    db.SaveChanges();
                    return seralizer.Serialize(userProfile.UserID);
                }
            }
            catch (Exception)
            { }
            return seralizer.Serialize(0); //error

        }

        [AllowAnonymous]
        [Route("api/UserProfile/UserProfileDelete")]
        public void UserProfileDelete([FromBody]int id)
        {
            JavaScriptSerializer seralizer = new JavaScriptSerializer();
            using (var db = new EFOpenDoor_Context())
            {
                UserProfile userProfile = db.UserProfile.FirstOrDefault(u => u.UserID == id);
                Visitor visitor = db.Visitor.FirstOrDefault(v => v.UserProfile.UserID == id);
                UserCredntials userCredntials = db.UserCredntials.FirstOrDefault(u => u.UserProfile.UserID == id);
                if (visitor != null)
                    db.Visitor.Remove(visitor);
                if (userCredntials != null)
                    db.UserCredntials.Remove(userCredntials);
                userProfile.IsDelete = true;
                //db.UserProfile.Remove(userProfile);
                db.SaveChanges();
            }
        }



    }
}

