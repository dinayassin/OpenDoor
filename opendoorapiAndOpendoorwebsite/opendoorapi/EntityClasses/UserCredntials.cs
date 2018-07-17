using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;


namespace OpenDoorAPI
{
    public class UserCredntials
    {
        public int UserCredntialsID { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public int UserProfileId { get; internal set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public virtual Role Role { get; set; }

    }
}