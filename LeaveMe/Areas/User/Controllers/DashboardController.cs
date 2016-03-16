using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaveMe.Areas.User.Controllers
{
    public class DashboardController : Controller
    {
        // GET: User/Dashboard
        public ActionResult Index(string UserID)
        {
            return View();
        }
    }
}