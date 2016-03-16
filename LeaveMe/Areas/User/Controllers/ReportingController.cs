using LeaveMe.Controllers;
using LeaveMe.Data;
using LeaveMe.Data.Security;
using LeaveMe.Services;
using LeaveMe.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaveMe.Areas.User.Controllers
{
    [RouteArea("User")]
    [RoutePrefix("Experience")]
    public class ReportingController : BaseController
    {
        private IUserService _userService;

        public ReportingController()
        {
            this._userService = new UserService(new LeaveSysEntities());
        }

        public ReportingController(IUserService userService)
        {
            this._userService = userService;
        }

        // GET: User/Reporting
        [AllowRoles]
        public ActionResult Manage(Guid? UserID)
        {
            ReportingToViewModel reportingToViewModel = new ReportingToViewModel();
            try
            {
                Guid _userID = (!string.IsNullOrWhiteSpace(UserID.ToString())) ? UserID.Value : User.UserID;
                reportingToViewModel.UserID = _userID;
                reportingToViewModel.ManagedBy = User.UserID;

               // Selected user or login user will be reporting to resultant users
               IList<SelectedUsers> selectedRepotingToUserID = _userService.GetUsersReportingByUserID(_userID);
               reportingToViewModel.SelectedRepotingToUserID = JsonConvert.SerializeObject(selectedRepotingToUserID);

               // The resultant users will be reporting to selected or login user
               IList<SelectedUsers> selectedUserReportingTo = _userService.GetReportingToByUserID(_userID);
               reportingToViewModel.SelectedUserReportingTo = JsonConvert.SerializeObject(selectedUserReportingTo);
              
            }
            catch (Exception cEx)
            {
                ModelState.AddModelError("", cEx.Message);
                return View();
            }

            return View(reportingToViewModel);
        }

        [HttpPost]
        [AllowRoles]
        public JsonResult ManageUserReportingTo(ReportingToViewModel reportingModel)
        {
            try
            {
                int result = _userService.ManageReportingTo(reportingModel);

                return Json(new { Result = "Success" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Result = string.Empty }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}