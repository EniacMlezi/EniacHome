namespace MVC_default.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountConfirmation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "AccountConfirmed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "AccountConfirmed");
        }
    }
}
