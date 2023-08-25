using AutoMapper;
using PROJE.Model.Dtos.Employee;
using PROJE.Model.Entities;

namespace PROJE.Business.Mappers.Automapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeGetDto>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name == null
                            ? ""
                            : src.Name.ToUpper()))
                .ForMember(
                dest => dest.Country,
                opt => opt.MapFrom(src => src.Country == null
                            ? ""
                            : src.Country.ToUpper()))
                .ForMember(
                dest => dest.BirthDate,
                opt => opt.MapFrom(src => src.BirthDate == null
                            ? ""
                            : src.BirthDate.ToString()))
                .ForMember(
                dest => dest.City,
                opt => opt.MapFrom(src => src.City == null
                            ? ""
                            : src.City.ToUpper()));

            CreateMap<EmployeePostDto, Employee>();
            CreateMap<EmployeePutDto, Employee>();
        }
    }
}