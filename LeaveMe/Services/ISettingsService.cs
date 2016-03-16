using LeaveMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMe.Services
{
    public interface ISettingsService : IDisposable
    {
        #region LeaveType

        LeaveTypeViewModel GetLeaveTypes(int LeaveTypeID = 0);
        int UpdateLeaveType(LeaveTypeViewModel LeaveType);
        int InsertLeaveType(LeaveTypeViewModel LeaveType);

        #endregion LeaveType
    }
}
