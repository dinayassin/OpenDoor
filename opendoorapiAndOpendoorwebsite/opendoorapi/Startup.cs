using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using OpenDoorAPI;
using System.Drawing;

[assembly: OwinStartup(typeof(OpenDoorAPI.Startup))]

namespace OpenDoorAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
