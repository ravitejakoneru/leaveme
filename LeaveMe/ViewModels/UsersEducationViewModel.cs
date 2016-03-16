using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeaveMe.ViewModels
{
    public class UsersEducationViewModel
    {

        public int? Id { get; set; }
        public Guid? UserID { get; set; }

        [Display(Name = "* Institute")]
        [MaxLength(150)]
        [Required(ErrorMessage = "Please enter institute name.")]
        public string Institute { get; set; }

        [Display(Name = "* Course")]
        [MaxLength(150)]
        [Required(ErrorMessage = "Please enter course specialization.")]
        public string CourseSpecialization { get; set; }

        [Display(Name = "* GPA")]
        [Required(ErrorMessage = "Please enter GPA.")]
        public decimal? GPA { get; set; }

        [DisplayName("* Start peroid")]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please select course start peroid.")]
        public string StartPeriod { get; set; }

        [DisplayName("* Ending peroid")]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please select course end peroid")]
        public string EndPeriod { get; set; }

        [Display(Name = "Comments/Credits")]
        [MaxLength(700)]
        public string Comments { get; set; }


        public bool? IsActive { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public IList<UsersEducationViewModel> UsersEducationList { get; set; }

    }
}