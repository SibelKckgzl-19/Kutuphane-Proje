using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSP.Model.Dtos.Book
{
    public class BookPutDto:IDto
    {
        public int BookID { get; set; }
        public string? Author { get; set; }
        public string? BookName { get; set; }
        public decimal? Price { get; set; }
        public string? PublisherID { get; set; }
    }
}
