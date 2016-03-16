using LeaveMe.Data;
using LeaveMe.Data.Models;
using LeaveMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeaveMe.Services
{
    public interface IUserService : IDisposable
    {
        #region Login

            UserLoginInfo GetUserByEmailandPassword(string Email, string Password);

        #endregion

        #region Profile

            UsersProfileViewModel GetUserProfileByUserID(Guid UserId);

            void UpdateUserProfileByUserID(UsersProfileViewModel usersProfile);

        #endregion

        #region Roles
            IList<Roles> GetRoles(int id = 0);
        #endregion

        #region WorkTitles
            IList<WorkTitles> GetWorkTitles(int id = 0);
        #endregion WorkTitles

        #region create users

            int CreateUser(CreateUserViewModel createUserViewModel);

            IList<CreateUserViewModel> GetAllUsers(bool IsActive);

        #endregion create users

        #region EmergencyContact

            IList<UsersEmergencyContactViewModel> GetEmergencyContactByUserID(Guid UserID);
            int CreateEmergencyContactDetails(UsersEmergencyContactViewModel usersEmergencyContactViewModel);
            int UpdateEmergencyContactDetails(UsersEmergencyContactViewModel usersEmergencyContactViewModel);
            UsersEmergencyContactViewModel GetEmergencyContactByID(int ContactID);
            int DeleteEmergencyContactDetails(int Id, Guid UserID, bool IsActive);

        #endregion EmergencyContact

        #region Experience

            IList<UsersExperienceViewModel> GetExperienceByUserID(Guid UserID);
            int CreateExperienceDetails(UsersExperienceViewModel usersExperienceViewModel);
            int UpdateExperienceDetails(UsersExperienceViewModel usersExperienceViewModel);
            UsersExperienceViewModel GetExperienceByID(int ExperienceID);
            int DeleteExperienceDetails(int Id, Guid UserID, bool IsActive);

        #endregion Experience

        #region Education

            IList<UsersEducationViewModel> GetEducationByUserID(Guid UserID);
            int CreateEducationDetails(UsersEducationViewModel usersEducationViewModel);
            int UpdateEducationDetails(UsersEducationViewModel usersEducationViewModel);
            UsersEducationViewModel GetEducationByID(int EducationID);
            int DeleteEducationDetails(int Id, Guid UserID, bool IsActive);

        #endregion Education

        #region ReportingTo
            int ManageReportingTo(ReportingToViewModel reportingToViewModel);

            /// <summary>
            /// This UserID will be reporting to below resultant users
            /// </summary>
            /// <param name="UserID"></param>
            /// <returns></returns>
            IList<SelectedUsers> GetReportingToByUserID(Guid UserID);

            /// <summary>
            /// The resultant Users will be reporting this UserID
            /// </summary>
            /// <param name="UserID"></param>
            /// <returns></returns>
            IList<SelectedUsers> GetUsersReportingByUserID(Guid UserID);
        #endregion ReportingTo
    }
}