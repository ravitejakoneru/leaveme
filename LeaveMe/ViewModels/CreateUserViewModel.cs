using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaveMe.ViewModels
{
    public class CreateUserViewModel
    {
        public CreateUserViewModel()
        {

        }

        public System.Guid UserID { get; set; }

        [Required(ErrorMessage = "Please assign user role.")]
        [Display(Name = "* User Role")]
        public Nullable<int> roleID { get; set; }

        [Required(ErrorMessage = "Please enter users email.")]
        [Remote("ValidateEmailAddress", "Validation", System.Web.Mvc.AreaReference.UseRoot, HttpMethod = "POST", ErrorMessage = "User with such email already exists.")]
        [Display(Name = "* Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter user password.")]
        [DataType(DataType.Password)]
        [MinLength(6 ,ErrorMessage="Users password should be minimum 6 charaters.")]
        [MaxLength(20)]
        [Display(Name = "* Password")]
        public string password { get; set; }


        public Nullable<System.Guid> createdBy { get; set; }


        [Required(ErrorMessage = "Please enter First name.")]
        [DisplayName("* First Name")]
        [MaxLength(150)]
        public string firstName { get; set; }

        [DisplayName("Middle Name")]
        [MaxLength(150)]
        public string middleName { get; set; }

        [Required(ErrorMessage = "Please enter Last name.")]
        [DisplayName("* Last Name")]
        [MaxLength(150)]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Please assign users recognition.")]
        [DisplayName("* Recognition")]
        public Nullable<int> workTitleID { get; set; }

        [AllowHtml]
        public IList<SelectListItem> WorkTitleList { get; set; }

        [AllowHtml]
        public IList<SelectListItem> RolesList { get; set; }

        public Nullable<bool> IsActive { get; set; }

        [DisplayName("ID")]
        public string DisplayID { get; set; }
        [DisplayName("Name")]
        public string DisplayName { get; set; }
        public string DOB { get; set; }
        public string DOJ { get; set; }
        [DisplayName("Mobile")]
        public string Mobile { get; set; }
        public string OtherEmailAddress { get; set; }
        [DisplayName("Role")]
        public string RoleName { get; set; }
        [DisplayName("Recognition")]
        public string WorkTitle { get; set; }
        public Nullable<bool> IsLoginActive { get; set; }
        public Nullable<bool> IsUserActive { get; set; }
        [DisplayName("Status")]
        public string Status { get; set; }

       
    }
}