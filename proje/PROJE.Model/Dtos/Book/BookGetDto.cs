using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE.Model.Dtos.Book
{
    public class BookGetDto
    {
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public string? Author { get; set; }
        public decimal? Price { get; set; }
        public string? CategoryName { get; set; }
        public string? PicturePath { get; set; }
    }
}
