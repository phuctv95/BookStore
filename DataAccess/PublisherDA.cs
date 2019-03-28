using Model.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PublisherDA
    {
        public List<Publisher> GetList()
        {
            using (var db = new BookStoreContext())
            {
                return db.Publishers.ToList();
            }
        }
        public Publisher Find(int id)
        {
            using (var db = new BookStoreContext())
            {
                return db.Publishers.Find(id);
            }
        }

        public void Add(Publisher publisher)
        {
            using (var db = new BookStoreContext())
            {
                db.Publishers.Add(publisher);
                db.SaveChanges();
            }
        }

        public void Update(Publisher publisher)
        {

            using (var db = new BookStoreContext())
            {
                db.Entry(publisher).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new BookStoreContext())
            {
                var publisher = db.Publishers.Find(id);
                db.Publishers.Remove(publisher);
                db.SaveChanges();
            }
        }
    }
}
