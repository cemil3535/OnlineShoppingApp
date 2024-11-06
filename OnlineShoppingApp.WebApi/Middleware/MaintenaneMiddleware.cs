using OnlineShoppingApp.Business.Operations.Setting;

namespace OnlineShoppingApp.WebApi.Middleware
{
    public class MaintenaneMiddleware
    {
        // maintenance operations operations
        private readonly RequestDelegate _next;
        

        public MaintenaneMiddleware(RequestDelegate next)
        {
            _next = next;
            
        }

        public async Task Invoke(HttpContext context)
        {
            var settingService = context.RequestServices.GetRequiredService<ISettingService>();
            bool maintenanceMode = settingService.GetMaintenanceState();

            if (context.Request.Path.StartsWithSegments("/api/Auth/login")|| context.Request.Path.StartsWithSegments("/api/Settings"))
            {
                await _next(context);
                return;
            }

            if (maintenanceMode)
            {
                await context.Response.WriteAsync("Su anda hizmet verememekteyiz.");
            }
            else
            {
                await _next(context);
            }

        }
    }
}
