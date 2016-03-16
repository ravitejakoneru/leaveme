using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeaveMe.ViewModels
{
    public class UsersExperienceViewModel
    {
        public UsersExperienceViewModel()
        {

        }

        public int? Id { get; set; }
        public Guid? UserID { get; set; }

        [Display(Name = "* Company")]
        [MaxLength(150)]
        [Required(ErrorMessage = "Please enter company name.")]
        public string Company { get; set; }

        [Display(Name = "* Job Title")]
        [MaxLength(150)]
        [Required(ErrorMessage = "Please enter job title.")]
        public string WorkTitle { get; set; }

        [DisplayName("* From")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please select date of joining.")]
        public Nullable<System.DateTime> FromDate { get; set; }

        [DisplayName("* To")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please select relieving date.")]
        public Nullable<System.DateTime> ToDate { get; set; }

        [Display(Name = "Comments")]
        [MaxLength(380)]
        public string Comments { get; set; }


        public bool? IsActive { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public IList<UsersExperienceViewModel> UsersExperienceList { get; set; }

    }
}