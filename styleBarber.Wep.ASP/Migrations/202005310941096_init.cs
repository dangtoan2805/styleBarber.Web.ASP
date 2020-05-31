namespace styleBarber.Wep.ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppointmentDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FisrtName = c.String(maxLength: 25),
                        LastName = c.String(maxLength: 25),
                        Email = c.String(maxLength: 100),
                        Phone = c.Int(nullable: false),
                        Note = c.String(maxLength: 350),
                        AppointmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Appointments", t => t.AppointmentID, cascadeDelete: true)
                .Index(t => t.AppointmentID);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.String(maxLength: 15),
                        BarberID = c.Int(nullable: false),
                        CalendarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Barbers", t => t.BarberID, cascadeDelete: true)
                .ForeignKey("dbo.Calendars", t => t.CalendarID, cascadeDelete: true)
                .Index(t => t.BarberID)
                .Index(t => t.CalendarID);
            
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
                "dbo.Calendars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Time = c.String(maxLength: 15),
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
                "dbo.Sliders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 25),
                        Title = c.String(maxLength: 50),
                        SliderDescription = c.String(maxLength: 250),
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
            DropForeignKey("dbo.AppointmentDetails", "AppointmentID", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "CalendarID", "dbo.Calendars");
            DropForeignKey("dbo.Appointments", "BarberID", "dbo.Barbers");
            DropIndex("dbo.Appointments", new[] { "CalendarID" });
            DropIndex("dbo.Appointments", new[] { "BarberID" });
            DropIndex("dbo.AppointmentDetails", new[] { "AppointmentID" });
            DropTable("dbo.StyleHairs");
            DropTable("dbo.Sliders");
            DropTable("dbo.Services");
            DropTable("dbo.Reviewers");
            DropTable("dbo.InfoStores");
            DropTable("dbo.Contacts");
            DropTable("dbo.Calendars");
            DropTable("dbo.Barbers");
            DropTable("dbo.Appointments");
            DropTable("dbo.AppointmentDetails");
        }
    }
}
