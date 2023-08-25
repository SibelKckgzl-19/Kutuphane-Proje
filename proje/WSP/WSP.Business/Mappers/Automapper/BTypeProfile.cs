using AutoMapper;
using WSP.Model.Dtos.BType;
using WSP.Model.Entities;

namespace WSP.Business.Mappers.Automapper
{
    public class BTypeProfile:Profile
    {
        public BTypeProfile() 
        {
            CreateMap<BType, BTypeGetDto>()
                .ForMember(
                dest => dest.BookType,
                opt => opt.MapFrom(src => src.BookType == null
                ? ""
                : src.BookType.ToUpper()))
                .ForMember(
                dest => dest.BookName,
                opt => opt.MapFrom(src => src.Books == null
                ? ""
                : src.Books.BookName))

                .ReverseMap();

        }
    }
}
