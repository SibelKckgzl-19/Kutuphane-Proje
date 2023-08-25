using Infrastructure.DataAccess.EF;
using PROJE.DataAccess.Implementations.EF.Contexts;
using PROJE.DataAccess.Interfaces;
using PROJE.Model.Entities;

namespace PROJE.DataAccess.Implementations.EF.Repositories
{
    public class AdminPanelUserRepository : BaseRepositoryEf<AdminPanelUser, LibraryContext>, IAdminPanelUserRepository
    {
        public async Task<AdminPanelUser> GetByUserNameAndPasswordAsync(string userName, string password, params string[] includeList)
        {
            return await GetAsync(x => x.UserName == userName && x.Password == password && x.IsActive.Value, includeList);
           
        }
    }
}
