using AutoMapper;
using WSP.Model.Dtos.Book;
using WSP.Model.Entities;

namespace WSP.Business.Mappers.Automapper
{
    public class BookProfile:Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookGetDto>()

                .ForMember(
                dest => dest.Author,
                opt => opt.MapFrom(src => src.Author == null
                                ? ""
                                : src.Author.ToUpper()))
                .ForMember(
                dest => dest.BookName,
                opt => opt.MapFrom(src => src.BookName == null
                                ? ""
                                : src.BookName.ToUpper()))
                .ForMember(
                dest => dest.PublisherName,
                opt => opt.MapFrom(src => src.Publisher == null
                                ? ""
                                : src.Publisher.PublisherName))
                .ForMember(
                dest => dest.Price,
                opt => opt.MapFrom(src => src.Price == null
                                ? 0
                                : src.Price.Value))
        
            .ReverseMap();

            CreateMap<BookPostDto, Book>();
            CreateMap<BookPutDto, Book>();

        }
    }
}
