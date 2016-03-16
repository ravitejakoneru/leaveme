using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeaveMe.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            this.RememberMe = false;
        }

        [Required(ErrorMessage="Please enter email address.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage="Please enter password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

    }
}