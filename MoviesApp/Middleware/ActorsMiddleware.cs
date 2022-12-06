using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Middleware
{
    public class ActorsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ActorsMiddleware> _logger;

        public ActorsMiddleware (RequestDelegate next, ILogger<ActorsMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.GetDisplayUrl().Contains("Actor"))
            {
                _logger.LogInformation($"{httpContext.Request.Method}" +
                    $"{httpContext.Request.Path}" +
                    $"{httpContext.Request.Protocol}" +
                    $"{httpContext.Request.ContentType}" +
                    $"{httpContext.Request.QueryString.Value}");
            }
            return _next(httpContext);
        }
    }

    public static class ActorsMiddlewareCustom
    {
        public static IApplicationBuilder UseActorsMiddlewareCustom(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ActorsMiddleware>();
        }
    }
}
