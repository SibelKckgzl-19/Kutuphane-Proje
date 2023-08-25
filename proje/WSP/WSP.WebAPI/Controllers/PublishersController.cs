using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WSP.Business.Implementations;
using WSP.Business.Interfaces;
using WSP.Model.Entities;

namespace WSP.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherBs _publisherBs;
       
        public PublishersController(IPublisherBs publisherBs)
        {
            _publisherBs = publisherBs;
        }

        [HttpGet]
        public List<Publisher> GetAllPublishers()
        {
            
            var list = _publisherBs.GetPublishers();
            return list;
        }

        [HttpGet("publishername")]
        public List<Publisher> GetAllPublishersByPublisherName(string publishername)
        { 
            var list = _publisherBs.GetPublishersByPublisherName(publishername);
            return list;
        }
        
        [HttpGet("publisherphone")]
        public List<Publisher> GetAllPublishersByPublisherPhone(string publisherphone)
        {
            var list = _publisherBs.GetPublishersByPublisherPhone(publisherphone);
            return list;
        }

        [HttpGet("publisheraddress")]
        public List<Publisher> GetAllPublishersByPublisherAddress(string publisheraddress)
        {
            var list = _publisherBs.GetPublishersByPublisherAddress(publisheraddress);
            return list;
        }
    }
}



