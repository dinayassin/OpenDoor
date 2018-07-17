using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDoorAPI.Contracts
{
    public class VisitorDTO
    {
        public int UserProfileId { get;  set; }
        public string RFCCard { get; set; }
        public string ProfileImg { get; set; }
        public bool IsTemp { get; set; }
        public bool IsActive { get; set; }

    }
}
