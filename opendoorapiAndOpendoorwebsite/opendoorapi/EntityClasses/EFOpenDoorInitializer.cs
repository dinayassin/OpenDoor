using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OpenDoorAPI
{

    public class EFOpenDoorInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EFOpenDoor_Context>
    {

        protected override void Seed(EFOpenDoor_Context context)
        {

            UserProfile[] users = {
                         new UserProfile() { Fname = "Anonymous", SystemUser=true},
                        new UserProfile() { Fname = "Admin", Lname = "User",  Email = "OpenDoorR2017@Gmail.com", SystemUser=true},

                    };
            foreach (var user in users)
            {
                context.UserProfile.Add(user);
            }




            Role[] roles =
            {
                        new Role() {Description="מאבטח"},
                        new Role() {Description="מנהל"}
                    };
            foreach (var role in roles)
            {
                context.Role.Add(role);
            }


            UserCredntials[] usersCredntials = {
                        new UserCredntials() {UserProfile=users[1],UserName="Admin",Password=PasswordSecurity.Encrypt("Ruppin2017"),Role=roles[1],IsActive=true }
                    };
            foreach (var userCredntials in usersCredntials)
            {
                context.UserCredntials.Add(userCredntials);
            }
            context.SaveChanges();

            //base.Seed(context);
        }
    }
}