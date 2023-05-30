using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PcStore.Application.Contract;
using PcStore.Application.Services;
using PcStore.Infrastructure.Context;
using PcStore.Infrastructure.Interfaces;
using PcStore.Infrastructure.Repositories;

namespace PcStore.IOC
{
    public static class ContextDependecy
    {
        public static void AddPcStoreDependency(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IProductoRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            //services
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICategoryService, CategoryService>();
        }

        public static void AddContextDependecy(this IServiceCollection services, string connString)
        {
            services.AddDbContext<PcStoreContext>(
                options => options
                    .UseMySql(connString, ServerVersion.AutoDetect(connString))
            );
        }
    }
}