using Model.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AuthorDA
    {
        public List<Author> GetList()
        {
            using (var db = new BookStoreContext())
            {
                return db.Authors.ToList();
            }
        }

        public Author Find(int id)
        {
            using (var db = new BookStoreContext())
            {
                return db.Authors.Find(id);
            }
        }

        public void Add(Author author)
        {
            using (var db = new BookStoreContext())
            {
                db.Authors.Add(author);
                db.SaveChanges();
            }
        }

        public void Update(Author author)
        {

            using (var db = new BookStoreContext())
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new BookStoreContext())
            {
                var author = db.Authors.Find(id);
                db.Authors.Remove(author);
                db.SaveChanges();
            }
        }
    }
}
