using LeaveMe.Data;
using LeaveMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeaveMe.Services
{
    public class SettingsService : ISettingsService
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(SettingsService));

        private LeaveSysEntities _context;

        public SettingsService(LeaveSysEntities context)
        {
            this._context = context;
        }

        #region LeaveType

        public LeaveTypeViewModel GetLeaveTypes(int leaveTypeID)
        {
            LeaveTypeViewModel leaveTypeModel = new LeaveTypeViewModel();

            try
            {
                if(leaveTypeID > 0)
                {
                leaveTypeModel = _context.usp_LeaveType_GetAll(leaveTypeID)
                     .Select(x => new LeaveTypeViewModel
                     {
                         LeaveTypeID = x.LeaveTypeID,
                         LeaveTypeName = x.LeaveTypeName,
                         LeaveTypeDescription = x.LeaveTypeDescription,
                         ColorCode = x.ColorCode,
                         LeaveDays = x.LeaveDays,
                         IsActive = x.IsActive,
                         CreatedBy = x.CreatedBy,
                         UpdatedBy = x.UpdatedBy,
                         CreatedDate = x.CreatedDate,
                         UpdatedDate = x.UpdatedDate

                     }).FirstOrDefault();
                }
                else{

                    leaveTypeModel.LeaveTypes = _context.usp_LeaveType_GetAll(leaveTypeID)
                        .Select(x => new LeaveTypeViewModel
                        {
                            LeaveTypeID = x.LeaveTypeID,
                            LeaveTypeName = x.LeaveTypeName,
                            LeaveTypeDescription = x.LeaveTypeDescription,
                            ColorCode = x.ColorCode,
                            LeaveDays = x.LeaveDays,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            UpdatedBy = x.UpdatedBy,
                            CreatedDate = x.CreatedDate,
                            UpdatedDate = x.UpdatedDate

                        }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return leaveTypeModel;
        }

        public LeaveTypeViewModel GetLeaveTypesById(int LeaveTypeID)
        {
            LeaveTypeViewModel leaveTypeViewModel = new LeaveTypeViewModel();

            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return leaveTypeViewModel;
        }

        public int UpdateLeaveType(LeaveTypeViewModel leaveType)
        {
            int isUpdated = 0;

            try
            {
                isUpdated = _context.usp_LeaveType_Update(leaveType.LeaveTypeID
                    , leaveType.LeaveTypeName, leaveType.LeaveTypeDescription, leaveType.ColorCode, leaveType.LeaveDays,
                    leaveType.IsActive, leaveType.UpdatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isUpdated;
        }

        public int InsertLeaveType(LeaveTypeViewModel leaveType)
        {
            int isCreated = 0;

            try
            {
                isCreated = _context.usp_LeaveType_Insert(leaveType.LeaveTypeName, leaveType.LeaveTypeDescription,
                    leaveType.ColorCode, leaveType.LeaveDays, leaveType.CreatedBy);
                  
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isCreated;
        }

        #endregion LeaveType

        #region disposal

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion disposal
    }
}