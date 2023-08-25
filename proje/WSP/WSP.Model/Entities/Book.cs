using Infrastructure.Model;

namespace WSP.Model.Entities
{
    public class Book : IEntity
    {
        public int BookID { get; set; }
        public string? BookName { get; set; }
        public string? Author { get; set; }
        public int BookTypeID { get; set; }
        public int PublisherID { get; set; }
        public decimal? Price { get; set; }

        //Navigation property
        public Publisher? Publisher { get; set; }
       
    }
}
