using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDoorAPI.Contracts
{
    public class UserCredntialsDTO
    {
        public int UserProfileId { get;  set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public int RoleID { get; set; }
    }
}
