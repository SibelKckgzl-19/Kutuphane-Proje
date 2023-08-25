using Infrastructure.DataAccess;
using PROJE.Model.Entities;

namespace PROJE.DataAccess.Interfaces
{
    public interface IAdminPanelUserRepository:IBaseRepository<AdminPanelUser>
    {
        Task<AdminPanelUser> GetByUserNameAndPasswordAsync(string userName, string password, params string[] includeList);
    }
}
