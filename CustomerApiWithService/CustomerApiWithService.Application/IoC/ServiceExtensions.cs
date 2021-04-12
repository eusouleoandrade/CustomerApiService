using CustomerApiWithService.Application.Interfaces;
using CustomerApiWithService.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CustomerApiWithService.Application.IoC
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
