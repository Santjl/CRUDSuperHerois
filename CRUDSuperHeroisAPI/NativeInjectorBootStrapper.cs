using CRUDSuperHeroisAPI.Data.Repository;
using CRUDSuperHeroisAPI.Data.UoW;
using CRUDSuperHeroisAPI.Domain.Interfaces;
using CRUDSuperHeroisAPI.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CRUDSuperHeroisAPI
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton(serviceProvider => serviceProvider);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IHeroisRepository, HeroisRepository>();
            services.AddScoped<IHeroisSuperpoderesRepository, HeroisSuperpoderesRepository>();
            services.AddScoped<ISuperpoderesRepository, SuperpoderesRepository>();
            services.AddScoped<NotificationService>();

        }
    }
}
