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

namespace LeaveMe.Areas.User.Controllers
{
    [RouteArea("User")]
    [RoutePrefix("Profile")]
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


        #region Profile

        [AllowRoles]
        public ActionResult Edit(Guid? UserID)
        {
            try
            {
                Guid userID = (!string.IsNullOrWhiteSpace(UserID.ToString())) ? UserID.Value : User.UserID;
                if (userID != Guid.Empty)
                {
                    UsersProfileViewModel viewModel = new UsersProfileViewModel();
                    viewModel = _userService.GetUserProfileByUserID(userID);

                    viewModel.WorkTitleList = _userService.GetWorkTitles(0).Select(x => new SelectListItem
                    {
                        Value = x.ID.ToString(),
                        Text = x.WorkTitle,
                        Selected = x.ID.Equals(viewModel.WorkTitleID)
                    }).ToList();

                    if (viewModel.UserID == Guid.Empty)
                    {
                        return RedirectToAction("NotFound", "Error", new { Area = "" });
                    }
                    else
                    {
                        return View(viewModel);
                    }
                }
                else
                {
                    return RedirectToAction("NotFound", "Error", new { Area = "" });
                }
                
            }
            catch (Exception cEx)
            {
                ModelState.AddModelError("", cEx.Message);
                return View();
            }
        }

        // POST: Admin/Profile/Edit/5
        [HttpPost]
        [AllowRoles]
        public ActionResult Edit(UsersProfileViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.UpdatedBy = User.UserID;
                    _userService.UpdateUserProfileByUserID(viewModel);

                    return RedirectToAction("Index", "Dashboard", new { Area = "Admin" });
                }
                viewModel.WorkTitleList = _userService.GetWorkTitles(0).Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.WorkTitle,
                    Selected = x.ID.Equals(viewModel.WorkTitleID)
                }).ToList();
                var errors = ModelState.Select(x => x.Value.Errors)
                          .Where(y => y.Count > 0)
                          .ToList();
                return View(viewModel);
            }
            catch (Exception cEx)
            {
                ModelState.AddModelError("", cEx.Message);
                return View();
            }

        }

        #endregion Profile


        #region Emergency

        [AllowRoles]
        public ActionResult Emergency(Guid? UserID, int? id)
        {
            UsersEmergencyContactViewModel viewModel = new UsersEmergencyContactViewModel();
            try
            {
                int _contactID = id.HasValue ? id.Value : 0;
                if (_contactID > 0)
                {
                    viewModel = _userService.GetEmergencyContactByID(_contactID);
                }

                Guid _userID = (!string.IsNullOrWhiteSpace(UserID.ToString())) ? UserID.Value : User.UserID;
                if (_userID != Guid.Empty)
                {
                    viewModel.UserID = _userID;
                    viewModel.UsersEmergencyContactList = _userService.GetEmergencyContactByUserID(_userID);
                }
                else
                {
                    return RedirectToAction("NotFound", "Error", new { Area = "" });
                }
                return View(viewModel);
            }
            catch (Exception cEx)
            {
                ModelState.AddModelError("", cEx.Message);
                return View();
            }
        }

        [HttpPost]
        [AllowRoles]
        public ActionResult Emergency(UsersEmergencyContactViewModel viewModel)
        {

            try
            {
                int _contactID = viewModel.Id.HasValue ? viewModel.Id.Value : 0;
                if (_contactID > 0)
                {
                    viewModel.UpdatedBy = User.UserID;
                    _userService.UpdateEmergencyContactDetails(viewModel);
                }
                else
                {
                    viewModel.CreatedBy = User.UserID;
                    int isCreated = _userService.CreateEmergencyContactDetails(viewModel);
                }

               return RedirectToAction("Emergency", "Profile", new { Area = "User", UserID = viewModel.UserID });

               
            }
            catch (Exception cEx)
            {
                ModelState.AddModelError("", cEx.Message);
                return View();
            }
        }

        [AllowRoles]
        public ActionResult EmergencyDelete(Guid? UserID, int id)
        {
           
            try
            {
                Guid _userID = (!string.IsNullOrWhiteSpace(UserID.ToString())) ? UserID.Value : User.UserID;

                if (id > 0)
                {
                    _userService.DeleteEmergencyContactDetails(id, User.UserID, false);
                }

                return RedirectToAction("Emergency", "Profile", new { Area = "User", UserID = _userID });

            }
            catch (Exception cEx)
            {
                ModelState.AddModelError("", cEx.Message);
                return View();
            }
        }

        #endregion Emergency


        
    }
}