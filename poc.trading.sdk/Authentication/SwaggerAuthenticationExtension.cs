using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace poc.trading.sdk.Authentication
{
    public static class SwaggerAuthenticationExtension
    {
        public static IServiceCollection AddSwaggerAuthentication(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            return services;
        }
    }
}
