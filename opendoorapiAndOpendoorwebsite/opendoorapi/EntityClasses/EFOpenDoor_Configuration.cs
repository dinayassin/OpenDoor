using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;


namespace OpenDoorAPI
{
    
    public class EFOpenDoor_Configuration : DbMigrationsConfiguration<EFOpenDoor_Context>
    {
        public EFOpenDoor_Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
           
        }

    }
}
