namespace SWGDealer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Message", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Email", c => c.String());
            AlterColumn("dbo.Contacts", "FirstName", c => c.String());
            DropColumn("dbo.Contacts", "Message");
        }
    }
}
