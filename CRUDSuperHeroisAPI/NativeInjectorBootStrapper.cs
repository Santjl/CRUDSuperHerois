using CRUDSuperHeroisAPI.Data.UoW;
using CRUDSuperHeroisAPI.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CRUDSuperHeroisAPI
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton(serviceProvider => serviceProvider);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
