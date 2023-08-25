using AutoMapper;
using PROJE.Model.Dtos.Category;
using PROJE.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE.Business.Mappers.Automapper
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryGetDto>()
                .ForMember(dest =>
                dest.Description,
                opt => opt.MapFrom(src => src.Description == null
                            ? ""
                            : src.Description.ToUpper()))
                .ForMember(dest =>
                dest.CategoryName,
                opt => opt.MapFrom(src => src.CategoryName == null
                            ? ""
                            : src.CategoryName.ToUpper()));

           
            CreateMap<CategoryPostDto, Category>();
            CreateMap<CategoryPutDto, Category>();


        }
    }
}
