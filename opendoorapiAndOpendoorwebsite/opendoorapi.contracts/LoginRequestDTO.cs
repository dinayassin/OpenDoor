using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDoorAPI.Contracts
{
    public class LoginRequestDTO
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
}
