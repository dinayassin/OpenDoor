using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OpenDoorAPI.Contracts;
using AutoMapper;
using System.Web.Script.Serialization;

namespace OpenDoorAPI.Controllers
{
    public class LogController : ApiController
    {
        JavaScriptSerializer seralizer = new JavaScriptSerializer();
        // GET: api/Log
        //[AllowAnonymous]
        public IEnumerable<ResultLogDTO> Get()
        {


            using (var db = new EFOpenDoor_Context())
            {
                return Mapper.Map<IEnumerable<ResultLogDTO>>(db.Log.ToList());
            }
        }


        // GET: api/Log/5
        //[AllowAnonymous]
        public ResultLogDTO Get(int id)
        {
            using (var db = new EFOpenDoor_Context())
            {
                return Mapper.Map<ResultLogDTO>(db.Log.Find(id));
            }
        }

        // GET: api/Log/LogImg
        [AllowAnonymous]
        [Route("api/Log/LogImg")]
        public string LogImg([FromBody]int id)
        {
            using (var db = new EFOpenDoor_Context())
            {
                var log = db.Log.FirstOrDefault(l => l.LogID == id);
                if (log != null)
                    if (log.Picture != null)
                        return seralizer.Serialize(log.Picture);
            }
            return seralizer.Serialize("");
        }

    }
}
