namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMore : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(),
                        History = c.String(),
                        Author_AuthorId = c.Int(),
                    })
                .PrimaryKey(t => t.AuthorId)
                .ForeignKey("dbo.Authors", t => t.Author_AuthorId)
                .Index(t => t.Author_AuthorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CateId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        PubId = c.Int(nullable: false),
                        Sumary = c.String(),
                        ImgUrl = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CateId, cascadeDelete: true)
                .ForeignKey("dbo.Publishers", t => t.PubId, cascadeDelete: true)
                .Index(t => t.CateId)
                .Index(t => t.AuthorId)
                .Index(t => t.PubId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CateId = c.Int(nullable: false, identity: true),
                        CateName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CateId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        Content = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        PubId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Publisher_PubId = c.Int(),
                    })
                .PrimaryKey(t => t.PubId)
                .ForeignKey("dbo.Publishers", t => t.Publisher_PubId)
                .Index(t => t.Publisher_PubId);
            
            CreateTable(
                "dbo.CommentBooks",
                c => new
                    {
                        Comment_CommentId = c.Int(nullable: false),
                        Book_BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Comment_CommentId, t.Book_BookId })
                .ForeignKey("dbo.Comments", t => t.Comment_CommentId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_BookId, cascadeDelete: true)
                .Index(t => t.Comment_CommentId)
                .Index(t => t.Book_BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "PubId", "dbo.Publishers");
            DropForeignKey("dbo.Publishers", "Publisher_PubId", "dbo.Publishers");
            DropForeignKey("dbo.CommentBooks", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.CommentBooks", "Comment_CommentId", "dbo.Comments");
            DropForeignKey("dbo.Books", "CateId", "dbo.Categories");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Authors", "Author_AuthorId", "dbo.Authors");
            DropIndex("dbo.CommentBooks", new[] { "Book_BookId" });
            DropIndex("dbo.CommentBooks", new[] { "Comment_CommentId" });
            DropIndex("dbo.Publishers", new[] { "Publisher_PubId" });
            DropIndex("dbo.Books", new[] { "PubId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropIndex("dbo.Books", new[] { "CateId" });
            DropIndex("dbo.Authors", new[] { "Author_AuthorId" });
            DropTable("dbo.CommentBooks");
            DropTable("dbo.Publishers");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
