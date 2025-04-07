using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace CRUD.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class PreventFromUrlAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            var referer = request.Headers["Referer"].ToString();
            var host = request.Host.Host;

            var currentController = context.RouteData.Values["controller"]?.ToString();
            var currentAction = context.RouteData.Values["action"]?.ToString();

            // ✅ Allow direct access only to Users/Index
            if (currentController == "Users" && currentAction == "Index")
            {
                base.OnActionExecuting(context);
                return;
            }

            // ❌ Block everything else if referer is missing or from another host
            if (string.IsNullOrEmpty(referer) || !referer.Contains(host))
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new
                    {
                        controller = "Users",
                        action = "Index"
                    }));
            }

            base.OnActionExecuting(context);
        }
    }
}
