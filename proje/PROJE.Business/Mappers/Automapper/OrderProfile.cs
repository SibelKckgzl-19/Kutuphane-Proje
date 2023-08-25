using AutoMapper;
using PROJE.Model.Dtos.Order;
using PROJE.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE.Business.Mappers.Automapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderGetDto>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Employees == null
                            ? ""
                            : src.Employees.Name))
                    .ForMember(dest =>
                    dest.ShipCity,
                    opt => opt.MapFrom(src => src.ShipCity == null
                    ? ""
                    : src.ShipCity.ToUpper()))
                    .ForMember(dest =>
                    dest.ShipAddress,
                    opt => opt.MapFrom(src => src.ShipAddress == null
                    ? ""
                    : src.ShipAddress.ToUpper()));

            CreateMap<OrderPostDto, Order>();
            CreateMap<OrderPutDto, Order>();


        }


    }
}
