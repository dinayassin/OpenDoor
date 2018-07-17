using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDoorAPI.Contracts
{
    public class VisitorIdentificationResultDTO
    {
        public VisitorIdentificationResults Result { get; set; }
    }

    public enum VisitorIdentificationResults
    {
        OpenDoor,
        FaildIdentification,
        RetakeImage
    }
}
