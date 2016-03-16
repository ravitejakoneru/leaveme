using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeaveMe.ViewModels
{
    public class ReportingToViewModel
    {
        public ReportingToViewModel()
        {
            SelectedUsers = new List<SelectedUsers>();
        }

        public Guid ManagedBy { get; set; }
        public DateTime ManagedDate { get; set; }
        public Guid UserReportingTo { get; set; }
        public string SelectedUserReportingTo { get; set; }
        public bool IsUserDelete { get; set; }
        public bool IsDirectReportingTo { get; set; }
        public string RepotingToUserDisplayName { get; set; }
        public Guid RepotingToUserID { get; set; }
        public string SelectedRepotingToUserID { get; set; }
        public string UserDisplayName { get; set; }
        public Guid UserID { get; set; }

        public IList<SelectedUsers> SelectedUsers { get; set; } 
    }

    public class SelectedUsers
    {
        public string id { get; set; }
        public string value { get; set; }
    }
}