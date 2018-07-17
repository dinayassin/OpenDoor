using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDoorAPI.Contracts
{
	public class ChangePassRequestDTO
	{
		public string UserName { get; set; }
		public string CurrentPass { get; set; }
		public string NewPass { get; set; }
	}
}
