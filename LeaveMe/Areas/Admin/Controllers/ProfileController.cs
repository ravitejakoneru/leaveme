using LeaveMe.Controllers;
using LeaveMe.Data;
using LeaveMe.Data.Security;
using LeaveMe.Services;
using LeaveMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeaveMe.Data.Helpers;

namespace LeaveMe.Areas.Admin.Controllers
{
    public class ProfileController : BaseController
    {

        private IUserService _userService;

        public ProfileController()
        {
            this._userService = new UserService(new LeaveSysEntities());
        }

        public ProfileController(IUserService userService)
        {
            this._userService = userService;
        }
        // GET: Admin/Profile

        public ActionResult Index()
        {
            return View();
        }



        [AllowRoles(SystemConfig.SITEADMIN, SystemConfig.SYSADMIN)]
        public ActionResult Edit()
        {
            try
            {
                UsersProfileViewModel viewModel = new UsersProfileViewModel();
                viewModel = _userService.GetUserProfileByUserID(User.UserID);

                viewModel.WorkTitleList = _userService.GetWorkTitles(0).Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(), 
                    Text = x.WorkTitle,
                    Selected = x.ID.Equals(viewModel.WorkTitleID)
                }).ToList();

                return View(viewModel);
            }
            catch (Exception cEx)
            {
                ModelState.AddModelError("", cEx.Message);
                return View();
            }
        }

        // POST: Admin/Profile/Edit/5
        [HttpPost]
        [AllowRoles(SystemConfig.SITEADMIN, SystemConfig.SYSADMIN)]
        public ActionResult Edit(UsersProfileViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.UserID = User.UserID;
                    viewModel.UpdatedBy = User.UserID;
                    _userService.UpdateUserProfileByUserID(viewModel);

                    return RedirectToAction("Index", "Dashboard", new { Area = "Admin" });
                }
                return View(viewModel);
            }
            catch(Exception cEx)
            {
                ModelState.AddModelError("", cEx.Message);
                return View();
            }
            
        }

        
    }
}
