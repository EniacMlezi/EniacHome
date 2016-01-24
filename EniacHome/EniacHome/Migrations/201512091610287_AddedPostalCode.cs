namespace EniacHome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPostalCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "PostalCode", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "PostalCode");
        }
    }
}
