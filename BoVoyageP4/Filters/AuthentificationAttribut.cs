using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageP4.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        public string Type { get; set; } = "BO";
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (Type == "CLIENT")
            {
                if (filterContext.HttpContext.Session["CLIENT"] == null)
                {
                    filterContext.Controller.TempData["REDIRECT"] = filterContext.HttpContext.Request.Url.AbsoluteUri;
                    filterContext.Result = new RedirectResult(@"\authentification\login");
                }
            }

            if (Type == "BO")
            {
                if (filterContext.HttpContext.Session["COMMERCIAL"] == null)
                {
                    filterContext.Result = new RedirectResult(@"\backoffice\authentification\login");
                    //filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new{ controller="authentication", action= "login", area="backoffice" }));
                }
            }
        }
    }
}