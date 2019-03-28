namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePublisher : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Publishers", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Publishers", "Name", c => c.String());
        }
    }
}
