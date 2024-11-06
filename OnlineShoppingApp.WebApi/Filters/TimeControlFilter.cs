using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OnlineShoppingApp.WebApi.Filters
{
    //Filtering request sending time according to endpoints
    public class TimeControlFilter : ActionFilterAttribute
    {
        public string StartTime { get; set; }

        public string EndTime { get; set; }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var now = DateTime.Now.TimeOfDay;

            StartTime = "23:00";
            EndTime = "23:59";

            if (now >= TimeSpan.Parse(StartTime) && now <= TimeSpan.Parse(EndTime))
            {
                base.OnActionExecuting(context);
            }
            else
            {
                context.Result = new ContentResult
                {
                    Content = "Bu saatler arasinda bir end-poind'e istek atamazsin!",
                    StatusCode = 403
                };
            }
        }


    }
}
