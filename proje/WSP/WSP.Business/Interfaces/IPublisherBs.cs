using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSP.Model.Entities;

namespace WSP.Business.Interfaces
{
    public interface IPublisherBs
    {
        List<Publisher> GetPublishers();
        List<Publisher> GetPublishersByPublisherName(string publishername);
        List<Publisher> GetPublishersByPublisherPhone(string publisherphone);
        List<Publisher> GetPublishersByPublisherAddress(string publisheraddress);

    }
}

