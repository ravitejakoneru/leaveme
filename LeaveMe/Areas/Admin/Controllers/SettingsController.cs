using LeaveMe.Controllers;
using LeaveMe.Data;
using LeaveMe.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaveMe.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [RoutePrefix("Settings")]
    public class SettingsController : BaseController
    {
        private ISettingsService _settingsService;

        public SettingsController()
        {
            this._settingsService = new SettingsService(new LeaveSysEntities());
        }

        public SettingsController(ISettingsService settingsService)
        {
            this._settingsService = settingsService;
        }

        // GET: Admin/Settings
        public ActionResult Index()
        {
            return View();
        }


    }
}