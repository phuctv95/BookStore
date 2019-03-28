using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Model.DomainModel;

namespace Business
{
    public class UserBU
    {
        private UserDA userDA = new UserDA();

        public List<User> GetList()
        {
            return userDA.GetList();
        }

        public User Find(string userName)
        {
            return userDA.Find(userName);
        }

        public void Add(User user)
        {
            userDA.Add(user);
        }

        public void Update(User user)
        {
            userDA.Update(user);
        }

        public void Delete(string userName)
        {
            userDA.Delete(userName);
        }
    }
}
