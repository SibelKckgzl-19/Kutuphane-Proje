using AutoMapper;
using PROJE.Model.Dtos.AdminPanelUser;
using PROJE.Model.Entities;

namespace PROJE.Business.Mappers.Automapper
{
    public class AdminUserProfile:Profile
    {
        public AdminUserProfile()
        {
            CreateMap<AdminPanelUser, AdminPanelUserDto>();
        }
    }
}
