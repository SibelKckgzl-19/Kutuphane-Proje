using Microsoft.Extensions.DependencyInjection;
using PROJE.Business.Implementations;
using PROJE.Business.Interfaces;
using PROJE.DataAccess.Implementations.EF.Repositories;
using PROJE.DataAccess.Interfaces;

namespace PROJE.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices (this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BookBs));

           
            services.AddScoped<IBookBs, BookBs>();
            services.AddScoped<IBookRepository, BookRepository>();

            services.AddScoped<ICategoryBs, CategoryBs>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IEmployeeBs, EmployeeBs>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IOrderBs, OrderBs>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IAdminPanelUserBs, AdminPanelUserBs>();
            services.AddScoped<IAdminPanelUserRepository, AdminPanelUserRepository>();


        }
    }
}
