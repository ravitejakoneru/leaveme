using LeaveMe.Controllers;
using LeaveMe.Data.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaveMe.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        // GET: Admin/Dashboard
        //[CustomAuthorize(RolesConfigKey = "RolesConfigKey")]
        // [CustomAuthorize(UsersConfigKey = "UsersConfigKey")]
        // [CustomAuthorize(Users = "1")]
        [AllowRoles(SystemConfig.SYSADMIN,SystemConfig.SITEADMIN)]
        public ActionResult Index()
        {
            return View();
        }

       
    }
}