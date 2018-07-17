using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenDoorEmailApi
{
    public class EmailRequest
    {
        public string To { get; set; }
        public string FromAddress { get; set; }
        public string FromDisplay { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}