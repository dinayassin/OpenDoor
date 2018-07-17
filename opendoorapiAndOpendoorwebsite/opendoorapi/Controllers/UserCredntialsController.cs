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
    public class UserCredntialsController : ApiController
    {

        JavaScriptSerializer seralizer = new JavaScriptSerializer();
        [AllowAnonymous]
        [Route("api/UserCredntials/WebsiteLogin")]
        public string WebsiteLogin(LoginRequestDTO loginData)
        {
            LoginResultDTO res = new LoginResultDTO() { Result = false };
            if (loginData != null)
            {


                using (var db = new EFOpenDoor_Context())
                {
                    var user = db.UserCredntials.FirstOrDefault(b => b.UserName.ToLower() == loginData.userName.ToLower());
                    if (user != null)
                        if (PasswordSecurity.Decrypt(user.Password) == loginData.password && user.IsActive)
                        {
                            res.Result = true;
                            res.UserID = user.UserProfile.UserID;
                            TokenData token = new TokenData() { UserName = user.UserName, Pass = user.Password };
                            res.Token = PasswordSecurity.SetTokenData(token);
                        }
                }
            }
            return seralizer.Serialize(res);
        }



        [AllowAnonymous]
        [Route("api/UserCredntials/CheckLogin")]
        public string CheckLogin([FromBody]string Token)
        {
            if (Token != "" && Token != null && Token != "null")
            {
                try
                {
                    TokenData token = PasswordSecurity.GetTokenData(Token);
                    using (var db = new EFOpenDoor_Context())
                    {
                        var user = db.UserCredntials.FirstOrDefault(b => b.UserName.ToLower() == token.UserName.ToLower());
                        if (user != null)
                            if (user.Password == token.Pass && user.IsActive)
                                return seralizer.Serialize(true);
                    }
                }
                catch (Exception)
                {
                }

            }
            return seralizer.Serialize(false);
        }

        [AllowAnonymous]
        [Route("api/UserCredntials/ChangePass")]
        public string ChangePass([FromBody]ChangePassRequestDTO Data)
        {
            if (Data != null)
            {
                using (var db = new EFOpenDoor_Context())
                {
                    var userC = db.UserCredntials.FirstOrDefault(b => b.UserName.ToLower() == Data.UserName.ToLower());
                    if (userC != null)
                        if (PasswordSecurity.Decrypt(userC.Password) == Data.CurrentPass)
                        {
                            userC.Password = PasswordSecurity.Encrypt(Data.NewPass);
                            db.SaveChanges();
                            return seralizer.Serialize(true);
                        }
                }
            }
            return seralizer.Serialize(false);
        }

        [AllowAnonymous]
        [Route("api/UserCredntials/IsEditingUserData")]
        public string IsEditingUserData([FromBody]string userName)
        {
            if (userName != string.Empty)
            {
                using (var db = new EFOpenDoor_Context())
                {
                    var user = db.UserCredntials.FirstOrDefault(b => b.UserName.ToLower() == userName);
                    if (user != null)
                    {
                        if (user.Role.Description == "מנהל")
                            return seralizer.Serialize(true);
                    }
                }
            }
            return seralizer.Serialize(false);
        }

        [AllowAnonymous]
        [Route("api/UserCredntials/ForgotPassword")]
        public string ForgotPassword([FromBody]string userName)
        {
            if (userName != string.Empty)
            {
                using (var db = new EFOpenDoor_Context())
                {
                    var user = db.UserCredntials.FirstOrDefault(b => b.UserName.ToLower() == userName && b.UserProfile.SystemUser == false);
                    if (user != null)
                    {
                        string newPass = PasswordSecurity.randPassword();
                        user.Password = PasswordSecurity.Encrypt(newPass);
                        db.SaveChanges();
                        Email.sendForgotPassWordEmail(user.UserProfile.Email, "Reset your OpenDoor password", user.UserProfile.Fname + " " + user.UserProfile.Lname, newPass).ToString();
                        return seralizer.Serialize(true);
                    }

                }
            }
            return seralizer.Serialize(false);
        }


        [AllowAnonymous]
        [Route("api/UserCredntials/UserNameExists")]
        public string UserNameExists(UserNameExistsDTO input)
        {
            JavaScriptSerializer seralizer = new JavaScriptSerializer();
            using (var db = new EFOpenDoor_Context())
            {
                var userC = db.UserCredntials.FirstOrDefault(u => u.UserName.ToLower() == input.UserName.ToLower() && u.UserProfile.UserID != input.UserID);
                if (userC == null)
                    return seralizer.Serialize(false);
                else
                    return seralizer.Serialize(true);
            }
        }
        [AllowAnonymous]
        [Route("api/UserCredntials/UserCredntialsByID")]
        public string UserCredntialsByID([FromBody]int id)
        {
            JavaScriptSerializer seralizer = new JavaScriptSerializer();
            using (var db = new EFOpenDoor_Context())
            {
                var userC = db.UserCredntials.FirstOrDefault(u => u.UserProfile.UserID == id);
                return seralizer.Serialize(Mapper.Map<UserCredntialsDTO>(userC));
            }
        }

        [AllowAnonymous]
        [Route("api/UserCredntials/UserCredntialsDelete")]
        public void UserCredntialsDelete([FromBody]int id)
        {
            JavaScriptSerializer seralizer = new JavaScriptSerializer();
            using (var db = new EFOpenDoor_Context())
            {
                var userC = db.UserCredntials.FirstOrDefault(u => u.UserProfile.UserID == id);
                if (userC != null)
                {
                    db.UserCredntials.Remove(userC);
                    db.SaveChanges();
                }
            }
        }

        [AllowAnonymous]
        [Route("api/UserCredntials/CreateEdit")]
        public string CreateEdit([FromBody]UserCredntialsDTO input)
        {
            JavaScriptSerializer seralizer = new JavaScriptSerializer();
            try
            {
                using (var db = new EFOpenDoor_Context())
                {
                    var userC = db.UserCredntials.FirstOrDefault(u => u.UserProfile.UserID == input.UserProfileId);
                    var userProfile = db.UserProfile.FirstOrDefault(u => u.UserID == input.UserProfileId);
                    if (userC != null)
                    {
                        userC.UserProfileId = input.UserProfileId;
                        userC.UserProfile = userProfile;
                        userC.UserName = input.UserName;
                        userC.Role = null;
                        userC.Role = db.Role.FirstOrDefault(r => r.RoleID == input.RoleID);
                        userC.IsActive = input.IsActive;
                    }
                    else
                    {
                        userC = new UserCredntials();
                        userC.UserProfileId = input.UserProfileId;
                        userC.UserProfile = userProfile;
                        userC.UserName = input.UserName;
                        userC.Role = null;
                        userC.Role = db.Role.FirstOrDefault(r => r.RoleID == input.RoleID);
                        string newPass = PasswordSecurity.randPassword();
                        userC.Password = PasswordSecurity.Encrypt(newPass);
                        userC.IsActive = input.IsActive;
                        db.UserCredntials.Add(userC);
                        Email.sendNewPassWordEmail(userProfile.Email, "Welcome to the OpenDoor family !", userProfile.Fname + " " + userProfile.Lname, newPass);
                    }
                    db.SaveChanges();
                    return seralizer.Serialize(true);
                }
            }
            catch (Exception)
            { }
            return seralizer.Serialize(false); //error
        }

    }
}
