using System.Web.Mvc;

namespace LeaveMe.Areas.User
{
    public class UserAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "User";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
                "User_USERID",
                "User/{controller}/{action}/{UserID}",
                new { action = "Index", UserID = UrlParameter.Optional }
                
            );

            context.MapRoute(
                "User_Emergency",
                "User/{controller}/{action}/{UserID}/{id}",
                new { action = "Index",UserID = UrlParameter.Optional, id = UrlParameter.Optional }
            );
            
        }
    }
}