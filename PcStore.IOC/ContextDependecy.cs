using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PcStore.Infrastructure.Context;
using PcStore.Infrastructure.Interfaces;
using PcStore.Infrastructure.Repositories;

namespace PcStore.IOC
{
    public static class ContextDependecy
    {
        public static void AddPcStoreDependency(this IServiceCollection services)
        {
            services.AddScoped<IProductoRepository, ProductRepository>();
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