using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DomainModel;

namespace DataAccess
{
    public class UserDA
    {
        public List<User> GetList()
        {
            using (var db = new BookStoreContext())
            {
                return db.Users.ToList();
            }
        }
        public User Find(string userName)
        {
            using (var db = new BookStoreContext())
            {
                return db.Users.Find(userName);
            }
        }

        public void Add(User user)
        {
            using (var db = new BookStoreContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void Update(User user)
        {

            using (var db = new BookStoreContext())
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges(); 
            }
        }

        public void Delete(string userName)
        {
            using (var db = new BookStoreContext())
            {
                var user = db.Users.Find(userName);
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
    }
}
