namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Summary", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Books", "Sumary");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Sumary", c => c.String());
            AlterColumn("dbo.Books", "Title", c => c.String());
            DropColumn("dbo.Books", "Summary");
        }
    }
}
