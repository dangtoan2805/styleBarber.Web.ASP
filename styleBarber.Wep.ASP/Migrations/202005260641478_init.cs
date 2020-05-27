namespace styleBarber.Wep.ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        FisrtName = c.String(maxLength: 25),
                        LastName = c.String(maxLength: 25),
                        Email = c.String(maxLength: 100),
                        Phone = c.Int(nullable: false),
                        Note = c.String(maxLength: 350),
                        CalendarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Calendars", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Date = c.String(maxLength: 15),
                        Time = c.String(maxLength: 15),
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
                        LevelJob = c.Boolean(nullable: false),
                        Image = c.String(maxLength: 25),
                        Info = c.String(maxLength: 350),
                        LinkFB = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        Twiter = c.String(maxLength: 100),
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
                        Phone = c.Int(nullable: false),
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
                        Content = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 25),
                        Name = c.String(maxLength: 50),
                        ServiceDescripton = c.String(maxLength: 350),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 25),
                        Title = c.String(maxLength: 50),
                        Content = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StyleHairs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Image = c.String(maxLength: 25),
                        Content = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calendars", "BarberID", "dbo.Barbers");
            DropForeignKey("dbo.Appointments", "ID", "dbo.Calendars");
            DropIndex("dbo.Calendars", new[] { "BarberID" });
            DropIndex("dbo.Appointments", new[] { "ID" });
            DropTable("dbo.StyleHairs");
            DropTable("dbo.Sliders");
            DropTable("dbo.Services");
            DropTable("dbo.Reviewers");
            DropTable("dbo.InfoStores");
            DropTable("dbo.Contacts");
            DropTable("dbo.Barbers");
            DropTable("dbo.Calendars");
            DropTable("dbo.Appointments");
        }
    }
}
