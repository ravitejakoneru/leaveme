using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeaveMe.ViewModels
{
    public class LeaveTypeViewModel
    {
        public LeaveTypeViewModel()
        {
            LeaveTypes = new List<LeaveTypeViewModel>();
        }
        public int LeaveTypeID { get; set; }
        public string LeaveTypeName { get; set; }
        public string LeaveTypeDescription { get; set; }
        public string ColorCode { get; set; }
        public int LeaveDays { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Guid CreatedBy { get; set; }
        public Nullable<Guid> UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }

        public IList<LeaveTypeViewModel> LeaveTypes { get; set; }
    }
}