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
    public class Role
    {
        public int RoleID { get; set; }
        public string Description { get; set; }
    }
}