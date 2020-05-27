namespace styleBarber.Wep.ASP.Migrations
{
    using styleBarber.Wep.ASP.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<styleBarber.Wep.ASP.EF.BarberContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(styleBarber.Wep.ASP.EF.BarberContext context)
        {
           
        }
    }
}
