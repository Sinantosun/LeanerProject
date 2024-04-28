namespace LeanerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_attechment_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Attachment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Attachment");
        }
    }
}
