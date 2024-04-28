namespace LeanerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_new_db_messages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "SenderNameSurname", c => c.String());
            AddColumn("dbo.Messages", "SenderReciverNameSurname", c => c.String());
            DropColumn("dbo.Messages", "NameSurname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "NameSurname", c => c.String());
            DropColumn("dbo.Messages", "SenderReciverNameSurname");
            DropColumn("dbo.Messages", "SenderNameSurname");
        }
    }
}
