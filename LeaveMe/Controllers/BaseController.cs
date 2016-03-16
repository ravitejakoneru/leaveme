using LeaveMe.Data.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaveMe.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected virtual new ApplicationPrincipal User
        {
            get { return HttpContext.User as ApplicationPrincipal; }
        }
    }
}