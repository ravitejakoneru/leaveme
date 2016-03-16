using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;


namespace LeaveMe.Data.Security
{
    public class ApplicationPrincipal : IPrincipal
    {
         public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            if (Roles.Any(r => role.Contains(r)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasAccess(string role)
        {
            bool hasAcess = false;
            switch (role)
            {
                case SystemConfig.SYSADMIN:
                    hasAcess = Roles.Any(r => role.Equals(SystemConfig.SYSADMIN));
                    break;
                case SystemConfig.SITEADMIN:
                    hasAcess = Roles.Any(r => role.Equals(SystemConfig.SITEADMIN));
                    break;
                case SystemConfig.APPMANAGER:
                    hasAcess = Roles.Any(r => role.Equals(SystemConfig.APPMANAGER));
                    break;
                case SystemConfig.SYSNOTIFIER:
                    hasAcess = Roles.Any(r => role.Equals(SystemConfig.SYSNOTIFIER));
                    break;
                case SystemConfig.USER:
                    hasAcess = Roles.Any(r => role.Equals(SystemConfig.USER));
                    break;

            }
            return hasAcess;
        }

        public ApplicationPrincipal(string Email)
        {
            this.Identity = new GenericIdentity(Email);
        }

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
    
    [Serializable]
    public class ApplicationPrincipalSerializeModel
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