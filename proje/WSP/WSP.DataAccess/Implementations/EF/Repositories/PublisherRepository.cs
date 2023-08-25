using Infrastructure.DataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSP.DataAccess.Implementations.EF.Contexts;
using WSP.DataAccess.Interfaces;
using WSP.Model.Entities;

namespace WSP.DataAccess.Implementations.EF.Repositories
{
    public class PublisherRepository : BaseRepository<Publisher, LibraryContext>, IPublisherRepository
    {
        public Publisher GetByID(int publisherID, params string[] includeList)
        {
            return Get(psr => psr.PublisherID == publisherID, includeList);
        }

        List<Publisher> IPublisherRepository.GetByPublisherAddress(string publisheraddress, params string[] includeList)
        {
            return GetAll(psr => psr.PublisherAddress == publisheraddress, includeList);
        }

        List<Publisher> IPublisherRepository.GetByPublisherName(string publishername, params string[] includeList)
        {
            return GetAll(psr => psr.PublisherName == publishername, includeList);
        }

        List<Publisher> IPublisherRepository.GetByPublisherPhone(string publisherphone  , params string[] includeList)
        {
            return GetAll(psr => psr.PublisherPhone == publisherphone, includeList);
        }
    }
}
