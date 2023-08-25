using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSP.Model.Entities
{
    public class BType:IEntity
    {
        [Key]
        public int BookTypeID { get; set; }
        public string? BookType { get; set; }
        public int? BookID { get; set; }
        public Book? Books { get; set; }
    }
}
