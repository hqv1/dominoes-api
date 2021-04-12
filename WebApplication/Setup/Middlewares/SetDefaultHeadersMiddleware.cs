using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Hqv.Dominoes.WebApplication.Setup.Middlewares
{
    /**
     * Use to set some default headers.
     */
    public class SetDefaultHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public SetDefaultHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var headers = context.Request.Headers;

            var correlationId = headers[Headers.CorrelationIdField];
            if (string.IsNullOrEmpty(correlationId))
            {
                correlationId = Guid.NewGuid().ToString();
                headers.Add(Headers.CorrelationIdField, correlationId);
            }
            
            context.Response.Headers.TryAdd(Headers.CorrelationIdField, correlationId);
            await _next(context);
        }
    }
}