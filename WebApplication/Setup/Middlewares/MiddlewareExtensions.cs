using Microsoft.AspNetCore.Builder;

namespace Hqv.Dominoes.WebApplication.Setup.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseLogDefaultHeaders(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogDefaultHeadersMiddleware>();
        }
        
        public static IApplicationBuilder UseSetDefaultHeaders(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SetDefaultHeadersMiddleware>();
        }
    }
}