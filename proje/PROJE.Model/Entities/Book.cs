using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE.Model.Entities
{
    public class Book:IEntity
    { 
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public string? Author { get; set; }
        public decimal? Price { get; set; }
        public int? CategoryId { get; set; }

        public bool? IsActive { get; set; }
        public string? PicturePath { get; set; }
        public Category? Category { get; set; }
    }
}
