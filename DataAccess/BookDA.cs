using Model.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookDA
    {
        private BookStoreContext db = new BookStoreContext();

        public List<Book> GetList()
        {

            return db.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .ToList();

        }

        public List<Book> GetList(int pageSize, int pageNumber)
        {

            return db.Books
                .OrderBy(b => b.BookId)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .ToList();
        }

        public int GetNumOfPages(int pageSize)
        {
            int numOfRows = db.Books.Count();
            return numOfRows / pageSize + 1;
        }

        public Book Find(int id)
        {

            return db.Books.Find(id);
        }

        public void Add(Book book)
        {

            db.Books.Add(book);
            db.SaveChanges();
        }

        public void Update(Book book)
        {


            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {

            var book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
        }

        public IEnumerable<Author> GetAuthors()
        {

            return db.Authors.ToList();

        }

        public IEnumerable<Category> GetCategories()
        {

            return db.Categories.ToList();

        }

        public IEnumerable<Publisher> GetPublishers()
        {

            return db.Publishers.ToList();

        }

        public void DisposeBook()
        {
            db.Dispose();
        }
    }
}
