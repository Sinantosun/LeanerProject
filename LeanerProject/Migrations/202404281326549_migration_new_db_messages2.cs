namespace LeanerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_new_db_messages2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ReciverNameSurname", c => c.String());
            DropColumn("dbo.Messages", "SenderReciverNameSurname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "SenderReciverNameSurname", c => c.String());
            DropColumn("dbo.Messages", "ReciverNameSurname");
        }
    }
}
