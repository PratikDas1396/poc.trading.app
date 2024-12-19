using Microsoft.AspNetCore.Http;
using poc.trading.db.Connector;

namespace poc.trading.db.Middleware
{
    public class SqlConnectorMiddleware(RequestDelegate next, ISqlConnector dbManager)
    {
        private readonly RequestDelegate _next = next;
        private readonly ISqlConnector _dbManager = dbManager;

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
        }
    }
}