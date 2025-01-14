using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.IServices.Infrastructure;
using Shop.Infrastructure.Contexts;
using Shop.Infrastructure.Repository;

namespace Shop.Infrastructure.Configurations
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("Database")
                           ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<ShopDbContext>(options => {
                options.UseSqlite(connection);
                options.UseSqlite(connection, b => b.MigrationsAssembly("Shop.API"));
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            return services;
        }
    }
}
