namespace DataAccess.Migrations
{
    using Model.DomainModel;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.BookStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DataAccess.BookStoreContext";
        }

        protected override void Seed(DataAccess.BookStoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Categories.AddOrUpdate(c => c.CateName,
                new Category { CateName = "Hài hước", Description = "..." },
                new Category { CateName = "Công nghệ thông tin", Description = "..." },
                new Category { CateName = "Văn học, thơ" },
                new Category { CateName = "Sức khỏe" },
                new Category { CateName = "Sample1" },
                new Category { CateName = "Sample2" }
            );
            context.SaveChanges();

            context.Authors.AddOrUpdate(a => a.AuthorName,
                new Author { AuthorName = "Nguyễn Nhật Ánh" },
                new Author { AuthorName = "Nguyễn Du" },
                new Author { AuthorName = "Sample1" },
                new Author { AuthorName = "Sample2" }
            );
            context.SaveChanges();

            context.Publishers.AddOrUpdate(p => p.Name,
                new Publisher { Name = "NXB Giáo Dục" },
                new Publisher { Name = "NXB Trẻ" },
                new Publisher { Name = "Sample1" },
                new Publisher { Name = "Sample2" }
            );
            context.SaveChanges();

            context.Books.AddOrUpdate(b => b.Title,
                new Book
                {
                    Title = "Truyện Kiều",
                    CateId = context.Categories.Where(c => c.CateName == "Văn học, thơ").FirstOrDefault().CateId,
                    AuthorId = context.Authors.Where(a => a.AuthorName == "Nguyễn Du").FirstOrDefault().AuthorId,
                    PubId = context.Publishers.Where(p => p.Name == "NXB Giáo Dục").FirstOrDefault().PubId,
                    Summary = "...",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Price = 1.5m,
                    Quantity = 150
                },
                new Book
                {
                    Title = "Sống khỏe",
                    CateId = context.Categories.Where(c => c.CateName == "Sức khỏe").FirstOrDefault().CateId,
                    AuthorId = context.Authors.Where(a => a.AuthorName == "Sample1").FirstOrDefault().AuthorId,
                    PubId = context.Publishers.Where(p => p.Name == "Sample2").FirstOrDefault().PubId,
                    Summary = "...",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Price = 1.5m,
                    Quantity = 30
                },
                new Book
                {
                    Title = "Sample 1",
                    CateId = context.Categories.Where(c => c.CateName == "Sức khỏe").FirstOrDefault().CateId,
                    AuthorId = context.Authors.Where(a => a.AuthorName == "Sample1").FirstOrDefault().AuthorId,
                    PubId = context.Publishers.Where(p => p.Name == "Sample1").FirstOrDefault().PubId,
                    Summary = "...",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Price = 3.5m,
                    Quantity = 40
                },
                new Book
                {
                    Title = "Sample 2",
                    CateId = context.Categories.Where(c => c.CateName == "Sample1").FirstOrDefault().CateId,
                    AuthorId = context.Authors.Where(a => a.AuthorName == "Sample1").FirstOrDefault().AuthorId,
                    PubId = context.Publishers.Where(p => p.Name == "Sample1").FirstOrDefault().PubId,
                    Summary = "...",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Price = 3.5m,
                    Quantity = 40
                },
                new Book
                {
                    Title = "Sample 3",
                    CateId = context.Categories.Where(c => c.CateName == "Sức khỏe").FirstOrDefault().CateId,
                    AuthorId = context.Authors.Where(a => a.AuthorName == "Sample1").FirstOrDefault().AuthorId,
                    PubId = context.Publishers.Where(p => p.Name == "Sample2").FirstOrDefault().PubId,
                    Summary = "...",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Price = 1.5m,
                    Quantity = 50
                },
                new Book
                {
                    Title = "Sample 4",
                    CateId = context.Categories.Where(c => c.CateName == "Sức khỏe").FirstOrDefault().CateId,
                    AuthorId = context.Authors.Where(a => a.AuthorName == "Sample1").FirstOrDefault().AuthorId,
                    PubId = context.Publishers.Where(p => p.Name == "Sample2").FirstOrDefault().PubId,
                    Summary = "...",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Price = 1.5m,
                    Quantity = 30
                },
                new Book
                {
                    Title = "Sample 5",
                    CateId = context.Categories.Where(c => c.CateName == "Sức khỏe").FirstOrDefault().CateId,
                    AuthorId = context.Authors.Where(a => a.AuthorName == "Sample1").FirstOrDefault().AuthorId,
                    PubId = context.Publishers.Where(p => p.Name == "Sample1").FirstOrDefault().PubId,
                    Summary = "...",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Price = 3.5m,
                    Quantity = 40
                },
                new Book
                {
                    Title = "Sample 6",
                    CateId = context.Categories.Where(c => c.CateName == "Sức khỏe").FirstOrDefault().CateId,
                    AuthorId = context.Authors.Where(a => a.AuthorName == "Sample1").FirstOrDefault().AuthorId,
                    PubId = context.Publishers.Where(p => p.Name == "Sample2").FirstOrDefault().PubId,
                    Summary = "...",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Price = 1.5m,
                    Quantity = 30
                },
                new Book
                {
                    Title = "Sample 7",
                    CateId = context.Categories.Where(c => c.CateName == "Sức khỏe").FirstOrDefault().CateId,
                    AuthorId = context.Authors.Where(a => a.AuthorName == "Sample1").FirstOrDefault().AuthorId,
                    PubId = context.Publishers.Where(p => p.Name == "Sample1").FirstOrDefault().PubId,
                    Summary = "...",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Price = 3.5m,
                    Quantity = 40
                },
                new Book
                {
                    Title = "Sample 8",
                    CateId = context.Categories.Where(c => c.CateName == "Sample1").FirstOrDefault().CateId,
                    AuthorId = context.Authors.Where(a => a.AuthorName == "Sample1").FirstOrDefault().AuthorId,
                    PubId = context.Publishers.Where(p => p.Name == "Sample1").FirstOrDefault().PubId,
                    Summary = "...",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Price = 3.5m,
                    Quantity = 40
                },
                new Book
                {
                    Title = "Sample 9",
                    CateId = context.Categories.Where(c => c.CateName == "Sức khỏe").FirstOrDefault().CateId,
                    AuthorId = context.Authors.Where(a => a.AuthorName == "Sample1").FirstOrDefault().AuthorId,
                    PubId = context.Publishers.Where(p => p.Name == "Sample2").FirstOrDefault().PubId,
                    Summary = "...",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Price = 1.5m,
                    Quantity = 50
                },
                new Book
                {
                    Title = "Sample 10",
                    CateId = context.Categories.Where(c => c.CateName == "Sức khỏe").FirstOrDefault().CateId,
                    AuthorId = context.Authors.Where(a => a.AuthorName == "Sample1").FirstOrDefault().AuthorId,
                    PubId = context.Publishers.Where(p => p.Name == "Sample2").FirstOrDefault().PubId,
                    Summary = "...",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Price = 1.5m,
                    Quantity = 30
                },
                new Book
                {
                    Title = "Sample 11",
                    CateId = context.Categories.Where(c => c.CateName == "Sức khỏe").FirstOrDefault().CateId,
                    AuthorId = context.Authors.Where(a => a.AuthorName == "Sample1").FirstOrDefault().AuthorId,
                    PubId = context.Publishers.Where(p => p.Name == "Sample1").FirstOrDefault().PubId,
                    Summary = "...",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Price = 3.5m,
                    Quantity = 40
                }
            );
            context.SaveChanges();
        }
    }
}
