using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeaveMe.Data.Models
{
    public class UserLoginInfo
    {
        public System.Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string[] Roles { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string DisplayID { get; set; }
    }
   
}