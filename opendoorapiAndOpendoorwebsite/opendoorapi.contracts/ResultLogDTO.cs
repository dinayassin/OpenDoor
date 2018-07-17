using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenDoorAPI;

namespace OpenDoorAPI.Contracts
{
    public class ResultLogDTO
    {
        public int LogID { get; set; }
        public int UserProfileId { get;  set; }
        public string UserFullName { get; set; }
        public string RFCCard { get; set; }
        public DateTime LoginDateTime { get; set; }
        public bool IsOpen { get; set; }
        public bool LogPicIsExist { get; set; }
    }
}

