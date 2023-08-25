using AutoMapper;
using PROJE.Model.Dtos.Book;
using PROJE.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE.Business.Mappers.Automapper
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookGetDto>()
                .ForMember(
                dest => dest.CategoryName,
                opt => opt.MapFrom(src => src.Category == null
                            ? ""
                            : src.Category.CategoryName))
                .ForMember(
                dest => dest.BookName,
                opt => opt.MapFrom(src => src.BookName == null
                            ? ""
                            : src.BookName.ToUpper()))
                .ForMember(
                dest => dest.Author,
                opt => opt.MapFrom(src => src.Author == null
                            ? ""
                            : src.Author.ToUpper()))
                .ForMember(
                dest => dest.Price,
                opt => opt.MapFrom(src => src.Price == null
                            ? 0
                            : src.Price.Value * 1.18m))
                .ReverseMap();

            CreateMap<BookPostDto, Book>();
           


        }
    }
}

