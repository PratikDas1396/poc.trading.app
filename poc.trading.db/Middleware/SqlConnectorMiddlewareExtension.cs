using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using poc.trading.db.Connector;

namespace poc.trading.db.Middleware
{
    public static class SqlConnectorMiddlewareExtension
    {
        public static IServiceCollection AddSqlConnector(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<ISqlConnector>(new SqlConnector(connectionString));
            return services;
        }

        public static IApplicationBuilder UseSqlConnector(this IApplicationBuilder app)
        {
            var dbManager = app.ApplicationServices.GetRequiredService<ISqlConnector>();
            return app.UseMiddleware<SqlConnectorMiddleware>(dbManager);
        }
    }
}
