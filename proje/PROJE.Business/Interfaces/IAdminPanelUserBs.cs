using Infrastructure.Utilities.ApiResponses;
using PROJE.Model.Dtos.AdminPanelUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE.Business.Interfaces
{
    public interface IAdminPanelUserBs
    {
        Task<ApiResponse<AdminPanelUserDto>> LogInAsync(string userName, string password, params string[] includeList);
    }
}
