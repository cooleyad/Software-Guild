namespace SWGDealer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userMapping : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "RoleName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "RoleName", c => c.String());
        }
    }
}
