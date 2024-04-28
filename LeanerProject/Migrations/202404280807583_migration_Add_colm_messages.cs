namespace LeanerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_Add_colm_messages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "MessageDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageDate");
            DropColumn("dbo.Messages", "IsDeleted");
        }
    }
}
