using LeaveMe.Data;
using LeaveMe.Data.Models;
using LeaveMe.Data.Security;
using LeaveMe.Services;
using LeaveMe.ViewModels;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LeaveMe.Controllers
{
    public class AccountController : BaseController
    {
        private IUserService _userService;

        public AccountController()
        {
            this._userService = new UserService(new LeaveSysEntities());
        }

        public AccountController(IUserService userService)
        {
            this._userService = userService;
        }
        // GET: Account
       
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (User != null)
            {
                if (User.Identity.IsAuthenticated == true)
                {
                    if (User.Roles.Contains(SystemConfig.SYSADMIN) ||
                        User.Roles.Contains(SystemConfig.SITEADMIN) ||
                        User.Roles.Contains(SystemConfig.APPMANAGER))
                    {
                        return RedirectToAction("Index", "Dashboard", new { Area = "Admin" });
                    }
                    else if (User.Roles.Contains(SystemConfig.SYSNOTIFIER) ||
                        User.Roles.Contains(SystemConfig.USER))
                    {
                        return RedirectToAction("Index", "Dashboard", new { Area = "User" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string ReturnUrl = "")
        {
            if (ModelState.IsValid)
            {
                UserLoginInfo _validateLoginUserData = _userService.GetUserByEmailandPassword(model.Email, model.Password);
                if (_validateLoginUserData != null)
                {
                    //var roles = user.Roles.Select(m => m.RoleName).ToArray();

                    ApplicationPrincipalSerializeModel serializeModel = new ApplicationPrincipalSerializeModel();
                    serializeModel.UserID = _validateLoginUserData.UserID;
                    serializeModel.UserName = _validateLoginUserData.UserName;
                    serializeModel.Email = _validateLoginUserData.Email;
                    serializeModel.FirstName = _validateLoginUserData.FirstName;
                    serializeModel.LastName = _validateLoginUserData.LastName;
                    serializeModel.MiddleName = _validateLoginUserData.MiddleName;
                    serializeModel.DisplayName = _validateLoginUserData.DisplayName;
                    serializeModel.DisplayID = _validateLoginUserData.DisplayID;
                    serializeModel.Roles = _validateLoginUserData.Roles;


                    string userData = JsonConvert.SerializeObject(serializeModel);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                             1,
                            _validateLoginUserData.Email,
                             DateTime.Now,
                             DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
                             model.RememberMe,
                             userData);

                    string encTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(faCookie);

                    if (!string.IsNullOrWhiteSpace(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    if (_validateLoginUserData.Roles.Contains(SystemConfig.SYSADMIN) ||
                       _validateLoginUserData.Roles.Contains(SystemConfig.SITEADMIN) ||
                       _validateLoginUserData.Roles.Contains(SystemConfig.APPMANAGER))
                    {
                        return RedirectToAction("Index", "Dashboard", new { Area = "Admin" });
                    }
                    else if (_validateLoginUserData.Roles.Contains(SystemConfig.SYSNOTIFIER) ||
                        _validateLoginUserData.Roles.Contains(SystemConfig.USER))
                    {
                        return RedirectToAction("Index", "Dashboard", new { Area = "User" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError("", "Invalid username or password!");
            }

            return View(model);
        }


        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }
    }
}