﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDoorAPI.Contracts
{
	public class LoginResultDTO
	{
		public string Token { get; set; }
		public int UserID { get; set; }
		public bool Result { get; set; }
	}
}
