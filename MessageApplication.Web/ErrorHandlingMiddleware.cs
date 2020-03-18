using System;
using System.Threading.Tasks;
using MessageApplication.Web.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MessageApplication.Web
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = 500;

            if (ex is BadRequestException)
            {
                int.TryParse(ex.Message.Substring(0, 3), out code);
            }

            var result = JsonConvert.SerializeObject(new { _code = code, _error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;
            return context.Response.WriteAsync(result);
        }
    }
}
