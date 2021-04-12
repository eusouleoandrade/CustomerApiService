using CustomerApiWithService.Application.Interfaces;
using CustomerApiWithService.Infra.Persistence.Contexts;
using CustomerApiWithService.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerApiWithService.Infra.Persistence.IoC
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Db Context
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
               configuration.GetConnectionString("DefaultConnection"),
               b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // Repositories
            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddScoped<ICustomerRepositoryAsync, CustomerRepositoryAsync>();
        }
    }
}
