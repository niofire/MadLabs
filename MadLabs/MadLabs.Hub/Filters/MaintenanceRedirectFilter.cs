using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;

namespace MadLabs.Hub.Filters
{
    /// <summary>
    /// Redirects all traffic to the maintenance page.
    /// </summary>
    public class MaintenanceRedirectFilter : IActionFilter
    {
        private IConfigurationRoot _config;

        public MaintenanceRedirectFilter(IConfigurationRoot config)
        {
            _config = config;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Do nothing!
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            bool isUnderMaintenance = _config.GetValue<bool>("isUnderMaintenance");

            if (!isUnderMaintenance || context.ActionDescriptor.RouteValues["action"] == "UnderMaintenance")
                return;

            context.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                        { "controller", "Home" },
                        {"action", "UnderMaintenance" }
                });
        }
    }
}
