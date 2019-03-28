using DataAccess;
using Model.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class AuthorBU
    {
        private AuthorDA authorDA = new AuthorDA();

        public List<Author> GetList()
        {
            return authorDA.GetList();
        }

        public Author Find(int id)
        {
            return authorDA.Find(id);
        }

        public void Add(Author author)
        {
            authorDA.Add(author);
        }

        public void Update(Author author)
        {
            authorDA.Update(author);
        }

        public void Delete(int id)
        {
            authorDA.Delete(id);
        }
    }
}
