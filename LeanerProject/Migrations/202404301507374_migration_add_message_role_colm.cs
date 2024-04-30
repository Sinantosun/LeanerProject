namespace LeanerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_add_message_role_colm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "RoleType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "RoleType");
        }
    }
}
