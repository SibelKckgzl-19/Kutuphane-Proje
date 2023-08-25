using Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSP.Model.Entities;

namespace WSP.DataAccess.Interfaces
{
    public interface IPublisherRepository : IBaseRepository<Publisher>
    {
        List<Publisher> GetByPublisherName(string publishername, params string[] includeList);
        List<Publisher> GetByPublisherPhone(string publisherphone, params string[] includeList);
        List<Publisher> GetByPublisherAddress(string publisheraddress, params string[] includeList);

        Publisher GetByID(int PublisherID, params string[] includeList);

    }
}
