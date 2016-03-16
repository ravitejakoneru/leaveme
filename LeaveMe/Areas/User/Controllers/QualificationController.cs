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

namespace LeaveMe.Areas.User.Controllers
{
    [RouteArea("User")]
    [RoutePrefix("Qualification")]
    public class QualificationController : BaseController
    {
        private IUserService _userService;

        public QualificationController()
        {
            this._userService = new UserService(new LeaveSysEntities());
        }

        public QualificationController(IUserService userService)
        {
            this._userService = userService;
        }


        [ApplicationAuthorize(Roles = "Administrator,User")]
        public ActionResult Add(Guid? UserID, int? id)
        {
            UsersEducationViewModel viewModel = new UsersEducationViewModel();
            try
            {
                int _eduID = id.HasValue ? id.Value : 0;
                if (_eduID > 0)
                {
                    viewModel = _userService.GetEducationByID(_eduID);
                }
                Guid _userID = (!string.IsNullOrWhiteSpace(UserID.ToString())) ? UserID.Value : User.UserID;
                if (_userID != Guid.Empty)
                {
                    viewModel.UserID = _userID;
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
        [ApplicationAuthorize(Roles = "Administrator,User")]
        public ActionResult Add(UsersEducationViewModel viewModel)
        {
            try
            {
                int __eduID = viewModel.Id.HasValue ? viewModel.Id.Value : 0;
                if (__eduID > 0)
                {
                    viewModel.UpdatedBy = User.UserID;
                    _userService.UpdateEducationDetails(viewModel);
                }
                else
                {
                    viewModel.CreatedBy = User.UserID;
                    int isCreated = _userService.CreateEducationDetails(viewModel);
                }
                return RedirectToAction("Qualifications", "Qualification", new { Area = "User", UserID = viewModel.UserID });
            }
            catch (Exception cEx)
            {
                ModelState.AddModelError("", cEx.Message);
                return View();
            }
        }


        [ApplicationAuthorize(Roles = "Administrator,User")]
        public ActionResult Qualifications(Guid? UserID)
        {
            UsersEducationViewModel viewModel = new UsersEducationViewModel();

            try
            {
                Guid _userID = (!string.IsNullOrWhiteSpace(UserID.ToString())) ? UserID.Value : User.UserID;
                if (_userID != Guid.Empty)
                {
                    viewModel.UserID = _userID;
                    viewModel.UsersEducationList = _userService.GetEducationByUserID(_userID);
                }

                return View(viewModel);
            }
            catch (Exception cEx)
            {
                ModelState.AddModelError("", cEx.Message);
                return View();
            }
        }

        [AllowRoles(SystemConfig.SYSADMIN, SystemConfig.SYSADMIN)]
        public ActionResult DeleteQualification(Guid? UserID, int id)
        {

            try
            {
                Guid _userID = (!string.IsNullOrWhiteSpace(UserID.ToString())) ? UserID.Value : User.UserID;

                if (id > 0)
                {
                    _userService.DeleteEducationDetails(id, User.UserID, false);
                }

                return RedirectToAction("Qualifications", "Qualification", new { Area = "User", UserID = _userID });

            }
            catch (Exception cEx)
            {
                ModelState.AddModelError("", cEx.Message);
                return View();
            }
        }
    }
}