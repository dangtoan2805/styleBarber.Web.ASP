namespace styleBarber.Wep.ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Barbers", "Twitter", c => c.String(maxLength: 100));
            AddColumn("dbo.Services", "ServiceDescription", c => c.String(maxLength: 350));
            DropColumn("dbo.Barbers", "Twiter");
            DropColumn("dbo.Services", "ServiceDescripton");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "ServiceDescripton", c => c.String(maxLength: 350));
            AddColumn("dbo.Barbers", "Twiter", c => c.String(maxLength: 100));
            DropColumn("dbo.Services", "ServiceDescription");
            DropColumn("dbo.Barbers", "Twitter");
        }
    }
}
