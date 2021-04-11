using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Hqv.Dominoes.WebApplication.Setup.Middlewares
{
    /**
     * Use to set some default headers to always be logged. Should be called after SetDefaultHeadersMiddleware.
     */
    public class LogDefaultHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public LogDefaultHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogger<LogDefaultHeadersMiddleware> logger)
        {
            var headers = context.Request.Headers;

            using (logger.BeginScope(new Dictionary<string, object>
            {
                [Headers.CorrelationIdField] = headers[Headers.CorrelationIdField]
            }))
            {
                await _next(context);
            }
        }
    }
}