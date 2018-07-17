using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDoorAPI.Contracts
{
    public class UserNameExistsDTO
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
}
