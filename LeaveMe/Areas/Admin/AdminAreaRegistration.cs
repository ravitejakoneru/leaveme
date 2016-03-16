using System.Web.Mvc;

namespace LeaveMe.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            //context.MapRoute(
            //    "Admin_default",
            //    "Admin/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);

            context.MapRoute(
                "Admin_USERID",
                "Admin/{controller}/{action}/{UserID}",
                new { action = "Index", UserID = UrlParameter.Optional }
            );
        }
    }
}