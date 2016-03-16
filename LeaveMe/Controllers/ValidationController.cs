using LeaveMe.Data;
using LeaveMe.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaveMe.Controllers
{
    public class ValidationController : BaseController
    {
        private LeaveSysEntities db = new LeaveSysEntities();

        [HttpPost]
        public ActionResult ValidateEmailAddress(string email)
        {
            try
            {
                var _user = db.Users.Where(x => x.Email == email).FirstOrDefault();

                return Json(_user == null, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpGet]
        public ActionResult GetRoleDescriptionByRoleID(int RoleID)
        {
            try
            {
                var _description = db.ups_Roles_GetRoles().Where(x => x.RoleID == RoleID).Select(x => x.RoleDescription).FirstOrDefault();

                return Json(new { Result = _description }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Result = string.Empty }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public JsonResult GetUsersFullNameAndWorkTitleByLetter(string term)
        {
            try
            {

                var _users = db.vw_Users_ViewUsers.ToList();
                _users = _users.Where(pt => pt.IsUserActive == true).OrderBy(pt => pt.FullName).ToList();

                if (!string.IsNullOrWhiteSpace(term))
                {
                    _users = _users.Where(a => a.FullName.ToUpper().Contains(term.ToUpper())).ToList();
                }
                
                _users = _users.OrderByDescending(p => p.FullName).ToList();

                IEnumerable _usersList = _users.Select(results => new { id = results.UserID, value = results.FullName});


                return Json(new { Result = _usersList }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Result = string.Empty }, JsonRequestBehavior.AllowGet);
            }

        }

    }
}