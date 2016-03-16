using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LeaveMe.Data.Security
{
    public class ApplicationAuthorizeAttribute : AuthorizeAttribute
    {
        public string UsersConfigKey { get; set; }
        public string RolesConfigKey { get; set; }

        protected virtual ApplicationPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as ApplicationPrincipal; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                var authorizedUsers = ConfigurationManager.AppSettings[UsersConfigKey];
                var authorizedRoles = ConfigurationManager.AppSettings[RolesConfigKey];

                Users = String.IsNullOrEmpty(Users) ? authorizedUsers : Users;
                Roles = String.IsNullOrEmpty(Roles) ? authorizedRoles : Roles;

                if (!String.IsNullOrEmpty(Roles))
                {
                    if (!CurrentUser.IsInRole(Roles))
                    {
                        filterContext.Result = new RedirectToRouteResult(new
                     RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));

                        // base.OnAuthorization(filterContext); //returns to login url
                    }
                }

                if (!String.IsNullOrEmpty(Users))
                {
                    if (!Users.Contains(CurrentUser.UserID.ToString()))
                    {
                        filterContext.Result = new RedirectToRouteResult(new
                     RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));

                    }
                }
            }
            else
            {
                base.OnAuthorization(filterContext); //returns to login url
            }

        }

    }

    public class AllowRolesAttribute : AuthorizeAttribute
    {
        public string RolesConfigKey { get; set; }

        protected virtual ApplicationPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as ApplicationPrincipal; }
        }

        public AllowRolesAttribute(params string[] roles)
            : base()
        {
            Roles = string.Join(",", roles);
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                var authorizedRoles = ConfigurationManager.AppSettings[RolesConfigKey];

                Roles = String.IsNullOrWhiteSpace(Roles) ? authorizedRoles : Roles;

                if (!String.IsNullOrWhiteSpace(Roles))
                {
                    if (!CurrentUser.IsInRole(Roles))
                    {
                        filterContext.Result = new RedirectToRouteResult(new
                     RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));

                    }
                }
            }
            else
            {
                base.OnAuthorization(filterContext); //returns to login url
            }

        }

    }

    public class AdminOnlyAttribute : AuthorizeAttribute
    {
        protected virtual ApplicationPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as ApplicationPrincipal; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                if (!CurrentUser.HasAccess(SystemConfig.SYSADMIN))
                {
                    filterContext.Result = new RedirectToRouteResult(new
                 RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));

                }
            }
            else
            {
                base.OnAuthorization(filterContext); //returns to login url
            }

        }

    }

    public class ApproveMangerOnlyAttribute : AuthorizeAttribute
    {
        protected virtual ApplicationPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as ApplicationPrincipal; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                if (!CurrentUser.HasAccess(SystemConfig.APPMANAGER))
                {
                    filterContext.Result = new RedirectToRouteResult(new
                 RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));

                }
            }
            else
            {
                base.OnAuthorization(filterContext); //returns to login url
            }

        }

    }

    public class UserOnlyAttribute : AuthorizeAttribute
    {
        protected virtual ApplicationPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as ApplicationPrincipal; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                if (!CurrentUser.HasAccess(SystemConfig.USER))
                {
                    filterContext.Result = new RedirectToRouteResult(new
                 RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));

                }
            }
            else
            {
                base.OnAuthorization(filterContext); //returns to login url
            }

        }

    }
}