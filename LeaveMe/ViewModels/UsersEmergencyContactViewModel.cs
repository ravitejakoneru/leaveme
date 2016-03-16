using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeaveMe.ViewModels
{
    public class UsersEmergencyContactViewModel
    {
        public UsersEmergencyContactViewModel()
        {
            UsersEmergencyContactList = new List<UsersEmergencyContactViewModel>();
        }

        public Nullable<int> Id { get; set; }
        public Guid UserID { get; set; }

        [Required(ErrorMessage = "Please enter name.")]
        [Display(Name = "* Name")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter relationship.")]
        [Display(Name = "* Relationship")]
        [MaxLength(150)]
        public string Relationship { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "Please enter mobile number.")]
        [Display(Name = "* Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "Work Mobile")]
        [MaxLength(20)]
        public string WorkMobile { get; set; }

        [Display(Name = "Notes")]
        [MaxLength(400)]
        public string Notes { get; set; }

        public Nullable<bool> IsActive { get; set; }
        public Guid CreatedBy { get; set; }
        public Nullable<Guid> UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }

        public IList<UsersEmergencyContactViewModel> UsersEmergencyContactList { get; set; }
    }
}