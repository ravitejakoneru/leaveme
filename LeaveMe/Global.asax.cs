using LeaveMe.Data.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace LeaveMe
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {

                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                ApplicationPrincipalSerializeModel serializeModel = JsonConvert.DeserializeObject<ApplicationPrincipalSerializeModel>(authTicket.UserData);
                ApplicationPrincipal newUser = new ApplicationPrincipal(authTicket.Name);
                newUser.UserID = serializeModel.UserID;
                newUser.UserName = serializeModel.UserName;
                newUser.Email = serializeModel.Email;
                newUser.FirstName = serializeModel.FirstName;
                newUser.LastName = serializeModel.LastName;
                newUser.MiddleName = serializeModel.MiddleName;
                newUser.DisplayName = serializeModel.DisplayName;
                newUser.DisplayID = serializeModel.DisplayID;
                newUser.Roles = serializeModel.Roles;

                HttpContext.Current.User = newUser;
            }
            

        }

    }
}
