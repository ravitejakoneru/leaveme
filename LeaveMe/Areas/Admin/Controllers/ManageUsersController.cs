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

namespace LeaveMe.Areas.Admin.Controllers
{
    public class ManageUsersController : BaseController
    {
         private IUserService _userService;

        public ManageUsersController()
        {
            this._userService = new UserService(new LeaveSysEntities());
        }

        public ManageUsersController(IUserService userService)
        {
            this._userService = userService;
        }

        // GET: Admin/ManageUsers/Create
        [AllowRoles(SystemConfig.SITEADMIN , SystemConfig.SYSADMIN)]
        public ActionResult Create()
        {
            CreateUserViewModel viewModel = new CreateUserViewModel();

            viewModel.WorkTitleList = _userService.GetWorkTitles(0).Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.WorkTitle,

            }).ToList();

            viewModel.RolesList = _userService.GetRoles(0).Select(x => new SelectListItem
            {
                Value = x.RoleID.ToString(),
                Text = x.RoleName,

            }).ToList();
            viewModel.createdBy = User.UserID;
            return View(viewModel);
        }

        // POST: Admin/ManageUsers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowRoles]
        public ActionResult Create(CreateUserViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.createdBy = User.UserID;
                    _userService.CreateUser(viewModel);

                    return RedirectToAction("ViewUsers", "ManageUsers", new { Area = "Admin" });
                }
                return View(viewModel);

                
            }
            catch (Exception cEx)
            {
                ModelState.AddModelError("", cEx.Message);
                return View();
            }
        }

        [AllowRoles(SystemConfig.SITEADMIN, SystemConfig.SYSADMIN)]
        public ActionResult ViewUsers()
        {
            IList<CreateUserViewModel> viewModel = new List<CreateUserViewModel>();
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel = _userService.GetAllUsers(true);
                }

                return View(viewModel);


            }
            catch (Exception cEx)
            {
                ModelState.AddModelError("", cEx.Message);
                return View();
            }
        }

        

        
    }
}
