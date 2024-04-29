namespace LeanerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_colm_adding : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "AttachmentNormalizeName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "AttachmentNormalizeName");
        }
    }
}
