using Model.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDA
    {
        public List<Category> GetList()
        {
            using (var db = new BookStoreContext())
            {
                return db.Categories.ToList();
            }
        }
        public Category Find(int id)
        {
            using (var db = new BookStoreContext())
            {
                return db.Categories.Find(id);
            }
        }

        public void Add(Category category)
        {
            using (var db = new BookStoreContext())
            {
                db.Categories.Add(category);
                db.SaveChanges();
            }
        }

        public void Update(Category category)
        {

            using (var db = new BookStoreContext())
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new BookStoreContext())
            {
                var category = db.Categories.Find(id);
                db.Categories.Remove(category);
                db.SaveChanges();
            }
        }
    }
}
