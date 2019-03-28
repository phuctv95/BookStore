namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Authors", "Author_AuthorId", "dbo.Authors");
            DropForeignKey("dbo.CommentBooks", "Comment_CommentId", "dbo.Comments");
            DropForeignKey("dbo.CommentBooks", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.Publishers", "Publisher_PubId", "dbo.Publishers");
            DropIndex("dbo.Authors", new[] { "Author_AuthorId" });
            DropIndex("dbo.Publishers", new[] { "Publisher_PubId" });
            DropIndex("dbo.CommentBooks", new[] { "Comment_CommentId" });
            DropIndex("dbo.CommentBooks", new[] { "Book_BookId" });
            CreateIndex("dbo.Comments", "BookId");
            AddForeignKey("dbo.Comments", "BookId", "dbo.Books", "BookId", cascadeDelete: true);
            DropColumn("dbo.Authors", "Author_AuthorId");
            DropColumn("dbo.Publishers", "Publisher_PubId");
            DropTable("dbo.CommentBooks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CommentBooks",
                c => new
                    {
                        Comment_CommentId = c.Int(nullable: false),
                        Book_BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Comment_CommentId, t.Book_BookId });
            
            AddColumn("dbo.Publishers", "Publisher_PubId", c => c.Int());
            AddColumn("dbo.Authors", "Author_AuthorId", c => c.Int());
            DropForeignKey("dbo.Comments", "BookId", "dbo.Books");
            DropIndex("dbo.Comments", new[] { "BookId" });
            CreateIndex("dbo.CommentBooks", "Book_BookId");
            CreateIndex("dbo.CommentBooks", "Comment_CommentId");
            CreateIndex("dbo.Publishers", "Publisher_PubId");
            CreateIndex("dbo.Authors", "Author_AuthorId");
            AddForeignKey("dbo.Publishers", "Publisher_PubId", "dbo.Publishers", "PubId");
            AddForeignKey("dbo.CommentBooks", "Book_BookId", "dbo.Books", "BookId", cascadeDelete: true);
            AddForeignKey("dbo.CommentBooks", "Comment_CommentId", "dbo.Comments", "CommentId", cascadeDelete: true);
            AddForeignKey("dbo.Authors", "Author_AuthorId", "dbo.Authors", "AuthorId");
        }
    }
}
