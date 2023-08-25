using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSP.Business.Interfaces;
using WSP.DataAccess.Implementations.EF.Repositories;
using WSP.DataAccess.Interfaces;
using WSP.Model.Entities;

namespace WSP.Business.Implementations
{
    public class PublisherBs : IPublisherBs
    {
        private readonly IPublisherRepository _repo;

        public PublisherBs(IPublisherRepository repo)
        {
            _repo = repo;
        }

        public List<Publisher> GetPublishers()
        {

            var list = _repo.GetAll();
            return list;
        }

        public List<Publisher> GetPublishersByPublisherAddress(string publisheraddress)
        {
            return _repo.GetByPublisherAddress(publisheraddress);
        }

        public List<Publisher> GetPublishersByPublisherName(string publishername)
        {
            return _repo.GetByPublisherName(publishername);
        }

        public List<Publisher> GetPublishersByPublisherPhone(string publisherphone)
        {
            return _repo.GetByPublisherPhone(publisherphone);
        }
    }
}