using LeaveMe.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaveMe.ViewModels
{
    public class UsersProfileViewModel
    {


        public UsersProfileViewModel()
        {
            this.IsActive = true;
        }


        public System.Guid UserID { get; set; }

        [Required(ErrorMessage = "Please enter First name.")]
        [DisplayName("* First Name")]
        [MaxLength(150)]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        [MaxLength(150)]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Please enter Last name.")]
        [DisplayName("* Last Name")]
        [MaxLength(150)]
        public string LastName { get; set; }

        [DisplayName("Display ID")]
        [MaxLength(15)]
        public string DisplayID { get; set; }

        [DisplayName("* Recognition")]
        [Required(ErrorMessage = "Please select recognition.")]
        public Nullable<int> WorkTitleID { get; set; }


        [DisplayName("* Recognition")]
        public string WorkTitle { get; set; }

        [DisplayName("* Date of Joining")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please enter date of joining.")]
        public Nullable<System.DateTime> DOJ { get; set; }

        [AllowHtml]
        public IList<SelectListItem> WorkTitleList { get; set; }

        [DisplayName("* Gender")]
        [Required(ErrorMessage = "Please select Gender")]
        public Nullable<bool> Gender { get; set; }

        [DisplayName("* Date of birth")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please enter your date of birth.")]
        public Nullable<System.DateTime> DOB { get; set; }

        [DisplayName("Martial Status")]
        public Nullable<int> MartialStatus { get; set; }

        [DisplayName("Address")]
        [MaxLength(400)]
        public string Address { get; set; }

        [DisplayName("City")]
        [MaxLength(200)]
        public string City { get; set; }

        [DisplayName("State")]
        [MaxLength(150)]
        public string State { get; set; }

        [DisplayName("ZipCode")]
        [MaxLength(20)]
        public string ZipCode { get; set; }

        [DisplayName("Country")]
        [MaxLength(150)]
        public string Country { get; set; }

        [DisplayName("* Mobile")]
        [MaxLength(20)]
        [Required(ErrorMessage = "Please enter your mobile number.")]
        public string Mobile { get; set; }

        [DisplayName("Personal Email")]
        [MaxLength(200)]
        [EmailAddress(ErrorMessage="Invalid email address")]
        public string OtherEmailAddress { get; set; }


        public Nullable<bool> IsActive { get; set; }

        [Required]
        public System.Guid CreatedBy { get; set; }

        public Nullable<System.Guid> UpdatedBy { get; set; }

        public System.DateTime CreatedDate { get; set; }

        public Nullable<System.DateTime> UpdatedDate { get; set; }

    }
}