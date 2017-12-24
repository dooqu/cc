using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["User"] == null)
            {
                if (filterContext.HttpContext.Request.Headers["x-requested-with"] != null && string.Equals(filterContext.HttpContext.Request.Headers["x-requested-with"], "XMLHttpRequest", StringComparison.OrdinalIgnoreCase))
                {
                    filterContext.HttpContext.Response.AppendHeader("sessionstatus", "timeout");
                }
                else
                {
                    FormsAuthentication.RedirectToLoginPage();
                }
                this.Response.End();
            }
        }
    }
}
