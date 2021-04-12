using Microsoft.AspNetCore.Builder;

namespace CustomerApiWithService.App.WebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerApiWithService.App.WebApi v1"));
        }
    }
}
