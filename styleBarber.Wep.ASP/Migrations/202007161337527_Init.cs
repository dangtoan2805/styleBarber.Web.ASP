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
                        FirstName = c.String(),
                        LastName = c.String(maxLength: 25),
                        Email = c.String(maxLength: 100),
                        Phone = c.String(),
                        Note = c.String(maxLength: 350),
                        Status = c.Boolean(nullable: false),
                        BarberID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Barbers", t => t.BarberID, cascadeDelete: true)
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
                "dbo.Contacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 25),
                        LastName = c.String(maxLength: 25),
                        Email = c.String(maxLength: 100),
                        Phone = c.String(),
                        Note = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.ID);
            
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
                "dbo.Reviewers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Image = c.String(maxLength: 25),
                        Job = c.String(maxLength: 50),
                        Review = c.String(maxLength: 350),
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
            DropForeignKey("dbo.Appointments", "BarberID", "dbo.Barbers");
            DropIndex("dbo.Appointments", new[] { "BarberID" });
            DropTable("dbo.StyleHairs");
            DropTable("dbo.Services");
            DropTable("dbo.Reviewers");
            DropTable("dbo.InfoStores");
            DropTable("dbo.Contacts");
            DropTable("dbo.Barbers");
            DropTable("dbo.Appointments");
        }
    }
}
