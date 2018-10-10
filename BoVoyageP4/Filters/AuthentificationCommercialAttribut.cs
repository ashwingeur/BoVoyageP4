using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageP4.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AuthentificationCommercialAttribut : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["COMMERCIAL"] == null)
            {
                filterContext.Result = new RedirectResult(@"\backoffice\authentication\login");
                //filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new{ controller="authentication", action= "login", area="backoffice" }));
            }

        }
    }
}