using System.Net;
using Microsoft.AspNetCore.Http;
using System;

using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineShoppingApp.WebApi.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
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

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var response = new
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = ex.Message,
                Detail = ex.InnerException?.Message // Detaylı hata mesajı
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var jsonResponse = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
