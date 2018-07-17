using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDoorAPI.Contracts
{
    public class LogDTO
    {
        public int LogID { get; set; }
        public int UserProfileId { get;  set; }
        public string RFCCard { get; set; }
        public DateTime LoginDateTime { get; set; }
        public bool IsOpen { get; set; }
        public byte[] Picture { get; set; }
    }
}
