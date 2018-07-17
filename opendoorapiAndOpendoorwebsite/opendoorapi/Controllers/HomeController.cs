using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenDoorAPI;
using System.Data.Entity.Infrastructure; // namespace for the EdmxWriter class
using System.Xml;
using System.Text;

namespace OpenDoorAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            // for get class diagram
            //GetEdmx(@"E:\Model.edmx");
            return View();
        }
        public void GetEdmx(string Path)
        {
            // for get class diagram
            using (var ctx = new EFOpenDoor_Context())
            {
                using (var writer = new XmlTextWriter(Path, Encoding.Default))
                {
                    EdmxWriter.WriteEdmx(ctx, writer);
                }
            }
        }
    }
}
