namespace styleBarber.Wep.ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Note = c.String(),
                        Status = c.Boolean(nullable: false),
                        UserID = c.Int(),
                        BarberID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Barbers", t => t.BarberID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.BarberID);
            
            CreateTable(
                "dbo.Barbers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        isFounder = c.Boolean(nullable: false),
                        Image = c.String(maxLength: 25),
                        Info = c.String(maxLength: 350),
                        LinkFB = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        Twitter = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        isAdmin = c.Boolean(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(maxLength: 25),
                        Email = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 15),
                        Image = c.String(maxLength: 150),
                        Job = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Review = c.String(maxLength: 350),
                        UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.InfoStores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Logo = c.String(maxLength: 25),
                        About = c.String(maxLength: 350),
                        Mission = c.String(maxLength: 350),
                        Reason = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 25),
                        Name = c.String(maxLength: 50),
                        ServiceDescription = c.String(maxLength: 350),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StyleHairs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Image = c.String(maxLength: 25),
                        StyleDescription = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Contacts", "UserID", "dbo.Users");
            DropForeignKey("dbo.Appointments", "BarberID", "dbo.Barbers");
            DropIndex("dbo.Contacts", new[] { "UserID" });
            DropIndex("dbo.Appointments", new[] { "BarberID" });
            DropIndex("dbo.Appointments", new[] { "UserID" });
            DropTable("dbo.StyleHairs");
            DropTable("dbo.Services");
            DropTable("dbo.InfoStores");
            DropTable("dbo.Contacts");
            DropTable("dbo.Users");
            DropTable("dbo.Barbers");
            DropTable("dbo.Appointments");
        }
    }
}
