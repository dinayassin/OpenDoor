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
    public class RoleController : ApiController
    {
        // GET: api/Role
        public IEnumerable<RoleDTO> Get()
        {
            JavaScriptSerializer seralizer = new JavaScriptSerializer();

            using (var db = new EFOpenDoor_Context())
            {
                return Mapper.Map<IEnumerable<RoleDTO>>(db.Role.ToList());
            }
        }
        [AllowAnonymous]
        [Route("api/Role/RoleList")]
        public string RoleList()
        {
            JavaScriptSerializer seralizer = new JavaScriptSerializer();

            using (var db = new EFOpenDoor_Context())
            {
                return seralizer.Serialize(Mapper.Map<IEnumerable<RoleDTO>>(db.Role.ToList()));
            }
        }

        // GET: api/Role/5
        public RoleDTO Get(int id)
        {
            using (var db = new EFOpenDoor_Context())
            {
                return Mapper.Map<RoleDTO>(db.Role.Find(id));
            }
        }

        // POST: api/Role
        public void Post([FromBody]RoleRequestDTO role)
        {
            using (var db = new EFOpenDoor_Context())
            {
                db.Role.Add(new Role() { Description = role.Description });
                db.SaveChanges();
            }
        }

        // PUT: api/Role/5
        public bool Put(RoleDTO roleUpdate)
        {
            using (var db = new EFOpenDoor_Context())
            {
                Role role = db.Role.Find(roleUpdate.RoleID);
                if (role == null)
                    return false;
                role.Description = roleUpdate.Description;
                db.SaveChanges();
                return true;
            }
        }


    }
}
