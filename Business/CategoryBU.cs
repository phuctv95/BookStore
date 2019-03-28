using DataAccess;
using Model.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CategoryBU
    {
        private CategoryDA categoryDA = new CategoryDA();

        public List<Category> GetList()
        {
            return categoryDA.GetList();
        }

        public Category Find(int id)
        {
            return categoryDA.Find(id);
        }

        public void Add(Category category)
        {
            categoryDA.Add(category);
        }

        public void Update(Category category)
        {
            categoryDA.Update(category);
        }

        public void Delete(int id)
        {
            categoryDA.Delete(id);
        }
    }
}
