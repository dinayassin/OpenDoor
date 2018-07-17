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
    public class Log
    {
        public int LogID { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public int UserProfileId { get; internal set; }
        public string RFCCard { get; set; }
        public DateTime LoginDateTime { get; set; }
        public bool IsOpen { get; set; }
        public string Picture { get; set; }
    }
}