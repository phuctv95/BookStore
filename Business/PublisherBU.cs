using DataAccess;
using Model.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PublisherBU
    {
        private PublisherDA publisherDA = new PublisherDA();

        public List<Publisher> GetList()
        {
            return publisherDA.GetList();
        }

        public Publisher Find(int id)
        {
            return publisherDA.Find(id);
        }

        public void Add(Publisher publisher)
        {
            publisherDA.Add(publisher);
        }

        public void Update(Publisher publisher)
        {
            publisherDA.Update(publisher);
        }

        public void Delete(int id)
        {
            publisherDA.Delete(id);
        }
    }
}
