using DataAccess;
using Model.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BookBU
    {
        private BookDA bookDA = new BookDA();

        public List<Book> GetList()
        {
            return bookDA.GetList();
        }

        public Book Find(int id)
        {
            return bookDA.Find(id);
        }

        public void Add(Book book)
        {
            book.CreatedDate = DateTime.Now;
            book.ModifiedDate = DateTime.Now;
            bookDA.Add(book);
        }

        public void Update(Book book)
        {
            book.ModifiedDate = DateTime.Now;
            bookDA.Update(book);
        }

        public void Delete(int id)
        {
            bookDA.Delete(id);
        }

        public IEnumerable<Author> GetAuthors()
        {
            return bookDA.GetAuthors();
        }

        public IEnumerable<Category> GetCategories()
        {
            return bookDA.GetCategories();
        }

        public IEnumerable<Publisher> GetPublishers()
        {
            return bookDA.GetPublishers();
        }

        public void DisposeBook()
        {
            bookDA.DisposeBook();
        }
    }
}
