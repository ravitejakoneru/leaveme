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
    [RoutePrefix("Experience")]
    public class ExperienceController : BaseController
    {
        private IUserService _userService;

        public ExperienceController()
        {
            this._userService = new UserService(new LeaveSysEntities());
        }

        public ExperienceController(IUserService userService)
        {
            this._userService = userService;
        }

        #region Experience


        [AllowRoles]
        public ActionResult Add(Guid? UserID, int? id)
        {
            UsersExperienceViewModel viewModel = new UsersExperienceViewModel();
            try
            {
                int _expID = id.HasValue ? id.Value : 0;
                if (_expID > 0)
                {
                    viewModel = _userService.GetExperienceByID(_expID);
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
        [AllowRoles]
        public ActionResult Add(UsersExperienceViewModel viewModel)
        {
            try
            {
                int _experienceID = viewModel.Id.HasValue ? viewModel.Id.Value : 0;
                if (_experienceID > 0)
                {
                    viewModel.UpdatedBy = User.UserID;
                    _userService.UpdateExperienceDetails(viewModel);
                }
                else
                {
                    viewModel.CreatedBy = User.UserID;
                    int isCreated = _userService.CreateExperienceDetails(viewModel);
                }
                return RedirectToAction("Experiences", "Experience", new { Area = "User", UserID = viewModel.UserID });
            }
            catch (Exception cEx)
            {
                ModelState.AddModelError("", cEx.Message);
                return View();
            }
        }


        [AllowRoles]
        public ActionResult Experiences(Guid? UserID)
        {
            UsersExperienceViewModel viewModel = new UsersExperienceViewModel();

            try
            {
                Guid _userID = (!string.IsNullOrWhiteSpace(UserID.ToString())) ? UserID.Value : User.UserID;
                if (_userID != Guid.Empty)
                {
                    viewModel.UserID = _userID;
                    viewModel.UsersExperienceList = _userService.GetExperienceByUserID(_userID);
                }

                return View(viewModel);
            }
            catch (Exception cEx)
            {
                ModelState.AddModelError("", cEx.Message);
                return View();
            }
        }

        [AllowRoles]
        public ActionResult DeleteExperience(Guid? UserID, int id)
        {

            try
            {
                Guid _userID = (!string.IsNullOrWhiteSpace(UserID.ToString())) ? UserID.Value : User.UserID;

                if (id > 0)
                {
                    _userService.DeleteExperienceDetails(id, User.UserID, false);
                }

                return RedirectToAction("Experiences", "Experience", new { Area = "User", UserID = _userID });

            }
            catch (Exception cEx)
            {
                ModelState.AddModelError("", cEx.Message);
                return View();
            }
        }

        #endregion Experience
    }
}