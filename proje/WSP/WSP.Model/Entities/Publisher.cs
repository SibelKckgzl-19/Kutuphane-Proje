using Infrastructure.Model;

namespace WSP.Model.Entities
{
    public class Publisher : IEntity
    {
        public int PublisherID { get; set; }
        public string? PublisherName { get; set; }
        public string? PublisherPhone { get; set;}
        public string? PublisherAddress { get; set;}


        public List<Book>? Books { get; set; }
    }
    
}
