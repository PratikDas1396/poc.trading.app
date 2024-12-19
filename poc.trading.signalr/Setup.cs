using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using poc.trading.signalr.Handler;
using poc.trading.signalr.Hubs;

namespace poc.trading.signalr
{
    public static class Setup
    {
        public static IServiceCollection SetupSignalR(this IServiceCollection services)
        {
            services.AddSignalR();
            services.AddSingleton<IClientHandler, ClientHandler>();
            return services;
        }

        public static IApplicationBuilder UseSingalR(this IApplicationBuilder app)
        {
            return app.UseEndpoints(endpoints =>
                {
                    endpoints.MapHub<TradingHub>("/tradingHub");
                }
            );
        }
    }
}