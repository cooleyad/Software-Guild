namespace SWGDealer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moreUserUpdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "RoleName", c => c.String());
            DropColumn("dbo.AspNetUsers", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Role", c => c.String());
            DropColumn("dbo.AspNetUsers", "RoleName");
        }
    }
}
