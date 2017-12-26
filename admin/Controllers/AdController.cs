using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace admin.Controllers
{
    public class AdController : Controller
    {
        //
        // GET: /Ad/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdAdd()
        {
            return View();
        }
    }
}
