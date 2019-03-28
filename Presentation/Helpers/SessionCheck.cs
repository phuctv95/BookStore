using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Presentation.Helpers
{
    public class SessionCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //base.OnActionExecuting(filterContext);
            var session = filterContext.HttpContext.Session;
            if (session != null && session[SessionKeys.LOGGED_IN] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary()
                {
                    { "Controller", "Admin" },
                    { "Action", "Index" }
                });
            }
        }
    }
}