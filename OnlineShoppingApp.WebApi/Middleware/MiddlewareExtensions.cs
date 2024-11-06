namespace OnlineShoppingApp.WebApi.Middleware
{
    public static class MiddlewareExtensions
    {
        //program cs short name definition
        public static IApplicationBuilder UseMaintenanaceMode(this IApplicationBuilder app) 
        {
            return app.UseMiddleware<MaintenaneMiddleware>();
        }
    }
}
