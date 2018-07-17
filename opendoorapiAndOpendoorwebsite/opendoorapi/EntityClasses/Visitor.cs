using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace OpenDoorAPI
{

    public class Visitor
    {
        public int VisitorID { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public int UserProfileId { get; internal set; }
        public string RFCCard { get; set; }
        public string ProfileImg { get; set; }
        public virtual Guid ProfileImgID { get; set; }
        public bool IsTemp { get; set; }
        public bool IsActive { get; set; }
    }
}