using LeaveMe.Data;
using LeaveMe.Data.Models;
using LeaveMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeaveMe.Services
{
    public class UserService : IUserService
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(UserService));

        private LeaveSysEntities _context;

        public UserService(LeaveSysEntities context)
        {
            this._context = context;
        }

        #region Login


        public UserLoginInfo GetUserByEmailandPassword(string Email, string Password)
        {
            UserLoginInfo _userInfo = null;
            try
            {
                IList<usp_Users_LoginUserByEmailandPassword_Result> _vLoginUser = _context.usp_Users_LoginUserByEmailandPassword(Email, Password).ToList();
                if (_vLoginUser.Count > 0)
                {
                    _userInfo = _vLoginUser
                        .Select(x => new UserLoginInfo
                        {
                            UserID = x.UserID,
                            UserName = x.UserName,
                            Email = x.Email,
                            Password = x.Password,
                            FirstName = x.FirstName,
                            LastName = x.LastName,
                            MiddleName = x.MiddleName,
                            DisplayName = x.DisplayName,
                            DisplayID = x.DisplayID

                        }).FirstOrDefault();

                    _userInfo.Roles = (from r in _vLoginUser select r.RoleName).ToArray();
                }



            }
            catch (Exception ex)
            {
                logger.Error("Error occured in UserService - GetUserByEmailandPassword", ex);
                _userInfo = null;
            }
            return _userInfo;
        }


        #endregion

        #region Profile

        public UsersProfileViewModel GetUserProfileByUserID(Guid UserId)
        {
            UsersProfileViewModel _userProfle = new UsersProfileViewModel();
            try
            {
                ups_UsersProfile_GetByUserID_Result vUserProfle = _context.ups_UsersProfile_GetByUserID(UserId).FirstOrDefault();
                if (vUserProfle != null)
                {
                    _userProfle.UserID = vUserProfle.UserID;
                    _userProfle.FirstName = vUserProfle.FirstName;
                    _userProfle.MiddleName = vUserProfle.MiddleName;
                    _userProfle.LastName = vUserProfle.LastName;
                    _userProfle.WorkTitleID = vUserProfle.WorkTitleID;
                    _userProfle.WorkTitle = vUserProfle.WorkTitle;
                    _userProfle.DOJ = vUserProfle.DOJ;
                    _userProfle.DisplayID = vUserProfle.DisplayID;
                    _userProfle.Gender = vUserProfle.Gender;
                    _userProfle.DOB = vUserProfle.DOB;
                    _userProfle.MartialStatus = vUserProfle.MartialStatus;
                    _userProfle.Address = vUserProfle.Address;
                    _userProfle.City = vUserProfle.City;
                    _userProfle.State = vUserProfle.State;
                    _userProfle.ZipCode = vUserProfle.ZipCode;
                    _userProfle.Country = vUserProfle.Country;
                    _userProfle.Mobile = vUserProfle.Mobile;
                    _userProfle.OtherEmailAddress = vUserProfle.OtherEmailAddress;
                    _userProfle.IsActive = vUserProfle.IsActive;
                    _userProfle.CreatedBy = vUserProfle.CreatedBy;
                    _userProfle.UpdatedBy = vUserProfle.UpdatedBy;
                    _userProfle.CreatedDate = vUserProfle.CreatedDate;
                    _userProfle.UpdatedDate = vUserProfle.UpdatedDate;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _userProfle;
        }

        public void UpdateUserProfileByUserID(UsersProfileViewModel usersProfile)
        {
            try
            {
            _context.ups_UsersProfile_UpdateByUserID(usersProfile.UserID, usersProfile.FirstName, usersProfile.MiddleName,
                usersProfile.LastName, usersProfile.WorkTitleID, usersProfile.DOJ, usersProfile.DisplayID, usersProfile.Gender, usersProfile.DOB, usersProfile.MartialStatus,
                usersProfile.Address, usersProfile.City, usersProfile.State, usersProfile.ZipCode, usersProfile.Country,
                usersProfile.Mobile, usersProfile.OtherEmailAddress, usersProfile.UpdatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        #endregion

        #region Roles

        public IList<Roles> GetRoles(int id = 0)
        {
            IList<Roles> _roles = new List<Roles>();
            try
            {
                _roles = _context.ups_Roles_GetRoles()
                    .Select(x => new Roles
                    {
                         RoleID = x.RoleID,
                         RoleName = x.RoleName,
                         RoleDescription = x.RoleDescription

                    }).ToList();
                    
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _roles;
        }

        #endregion

        #region workTitles

        public IList<WorkTitles> GetWorkTitles(int id = 0)
        {
            IList<WorkTitles> workTitles = new List<WorkTitles>();
            try
            {
                 workTitles = _context.ups_WorkTitle_GetWorkTitles()
                    .Select(x => new WorkTitles
                    {
                        ID = x.ID,
                        WorkTitle = x.WorkTitle,
                    }).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return workTitles;
        }

        #endregion workTitles

        #region create users

        public int CreateUser(CreateUserViewModel createUserViewModel)
        {
            int isUserCreated = 0;
            try
            {
               isUserCreated =  _context.ups_Users_CreateUser(createUserViewModel.email, createUserViewModel.password, createUserViewModel.createdBy,
                    createUserViewModel.firstName, createUserViewModel.middleName, createUserViewModel.lastName,
                    createUserViewModel.workTitleID, createUserViewModel.roleID);
            }
            catch (Exception ex)
            {
                isUserCreated = 0;
                throw ex;
            }

            return isUserCreated;
        }


        public IList<CreateUserViewModel> GetAllUsers(bool IsActive = true)
        {
            IList<CreateUserViewModel> viewUsers = new List<CreateUserViewModel>();
            try
            {
                viewUsers = _context.usp_Users_GetAllUsers(IsActive)
                     .Select(x => new CreateUserViewModel
                     {
                      
                         UserID = x.UserID,
                         DisplayID = x.DisplayID,
                         DisplayName = x.DisplayName,
                         DOB =  x.DOB,
                         DOJ = x.DOJ,
                         email = x.Email,
                         firstName = x.FirstName,
                         lastName = x.LastName,
                         middleName = x.MiddleName,
                         Mobile = x.Mobile,
                         OtherEmailAddress = x.OtherEmailAddress,
                         roleID = x.RoleID,
                         RoleName = x.RoleName,
                         WorkTitle = x.WorkTitle,
                         workTitleID = x.WorkTitleID,
                        IsLoginActive = x.IsLoginActive,
                        Status = x.IsLoginActive == true ? "Active" : "In Active",
                        IsUserActive = x.IsUserActive

                     }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return viewUsers;
        }


        #endregion create users

        #region EmergencyContact

        public IList<UsersEmergencyContactViewModel> GetEmergencyContactByUserID(Guid UserID)
        {
            IList<UsersEmergencyContactViewModel> emergencyContacts = new List<UsersEmergencyContactViewModel>();
            try
            {

                emergencyContacts = _context.usp_UsersEmergencyContact_GetByUserID(UserID)
                     .Select(x => new UsersEmergencyContactViewModel
                     {
                       Id = x.Id,
                       Name = x.Name,
                       Mobile = x.Mobile,
                       WorkMobile = x.WorkMobile,
                       Notes = x.Notes,
                       Relationship = x.Relationship,
                       IsActive = x.IsActive,
                       UserID = x.UserID,
                       CreatedBy = x.CreatedBy,
                       UpdatedBy = x.UpdatedBy,
                       CreatedDate = x.CreatedDate,
                       UpdatedDate = x.UpdatedDate
                       

                     }).ToList(); 
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return emergencyContacts;
        }

        public int CreateEmergencyContactDetails(UsersEmergencyContactViewModel usersEmergencyContactModel)
        {
            int isEmergencyContactCreated = 0;

            try
            {
                isEmergencyContactCreated = _context.usp_UsersEmergencyContact_Insert(usersEmergencyContactModel.UserID,
                    usersEmergencyContactModel.Name, usersEmergencyContactModel.Relationship, usersEmergencyContactModel.Mobile,
                    usersEmergencyContactModel.WorkMobile, usersEmergencyContactModel.Notes, usersEmergencyContactModel.CreatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isEmergencyContactCreated;
        }

        public int UpdateEmergencyContactDetails(UsersEmergencyContactViewModel usersEmergencyContactModel)
        {
            int isEmergencyContactUpdated = 0;
            try
            {
                isEmergencyContactUpdated = _context.usp_UsersEmergencyContact_Update(
                   usersEmergencyContactModel.Id, usersEmergencyContactModel.UserID,
                 usersEmergencyContactModel.Name, usersEmergencyContactModel.Relationship,
                 usersEmergencyContactModel.Mobile,
                 usersEmergencyContactModel.WorkMobile,usersEmergencyContactModel.Notes, usersEmergencyContactModel.UpdatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isEmergencyContactUpdated;
        }

        public UsersEmergencyContactViewModel GetEmergencyContactByID(int ContactID)
        {
            UsersEmergencyContactViewModel emergencyContact = new UsersEmergencyContactViewModel();
            try
            {

                emergencyContact = _context.usp_UsersEmergencyContact_GetByID(ContactID)
                     .Select(x => new UsersEmergencyContactViewModel
                     {
                         Id = x.Id,
                         Name = x.Name,
                         Mobile = x.Mobile,
                         WorkMobile = x.WorkMobile,
                         Notes = x.Notes,
                         Relationship = x.Relationship,
                         IsActive = x.IsActive,
                         UserID = x.UserID,
                         CreatedBy = x.CreatedBy,
                         UpdatedBy = x.UpdatedBy,
                         CreatedDate = x.CreatedDate,
                         UpdatedDate = x.UpdatedDate


                     }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return emergencyContact;
        }

        public int DeleteEmergencyContactDetails(int Id, Guid UserID, bool IsActive)
        {
            int isEmergencyContactDeleted = 0;
            try
            {
                isEmergencyContactDeleted = _context.usp_UsersEmergencyContact_Deactivate(
                   Id, UserID, IsActive);
                
                 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isEmergencyContactDeleted;
        }


        #endregion EmergencyContact

        #region Experience

        public IList<UsersExperienceViewModel> GetExperienceByUserID(Guid UserID)
        {
            IList<UsersExperienceViewModel> experiences = new List<UsersExperienceViewModel>();
            try
            {

                experiences = _context.usp_UsersExperience_GetByUserID(UserID)
                     .Select(x => new UsersExperienceViewModel
                     {
                         Id = x.Id,
                         Company = x.Company,
                         WorkTitle = x.WorkTitle,
                         FromDate = x.FromDate,
                         ToDate = x.ToDate,
                         Comments = x.Comments,
                         IsActive = x.IsActive,
                         UserID = x.UserID,
                         CreatedBy = x.CreatedBy,
                         UpdatedBy = x.UpdatedBy,
                         CreatedDate = x.CreatedDate,
                         UpdatedDate = x.UpdatedDate


                     }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return experiences;
        }

        public int CreateExperienceDetails(UsersExperienceViewModel usersExperienceViewModel)
        {
            int isExperienceCreated = 0;

            try
            {
                isExperienceCreated = _context.usp_UsersExperience_Insert(usersExperienceViewModel.UserID,
                    usersExperienceViewModel.WorkTitle, usersExperienceViewModel.Company, usersExperienceViewModel.FromDate,
                    usersExperienceViewModel.ToDate, usersExperienceViewModel.Comments, usersExperienceViewModel.CreatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isExperienceCreated;
        }

        public int UpdateExperienceDetails(UsersExperienceViewModel usersExperienceViewModel)
        {
            int isExperienceUpdated = 0;
            try
            {
                isExperienceUpdated = _context.usp_UsersExperience_Update(
                   usersExperienceViewModel.Id, usersExperienceViewModel.UserID,
                 usersExperienceViewModel.WorkTitle, usersExperienceViewModel.Company,
                 usersExperienceViewModel.FromDate,
                 usersExperienceViewModel.ToDate, usersExperienceViewModel.Comments, usersExperienceViewModel.UpdatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isExperienceUpdated;
        }

        public UsersExperienceViewModel GetExperienceByID(int ExperienceID)
        {
            UsersExperienceViewModel experience = new UsersExperienceViewModel();
            try
            {

                experience = _context.usp_UsersExperience_GetByID(ExperienceID)
                     .Select(x => new UsersExperienceViewModel
                     {
                         Id = x.Id,
                         Company = x.Company,
                         WorkTitle = x.WorkTitle,
                         FromDate = x.FromDate,
                         ToDate = x.ToDate,
                         Comments = x.Comments,
                         IsActive = x.IsActive,
                         UserID = x.UserID,
                         CreatedBy = x.CreatedBy,
                         UpdatedBy = x.UpdatedBy,
                         CreatedDate = x.CreatedDate,
                         UpdatedDate = x.UpdatedDate


                     }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return experience;
        }

        public int DeleteExperienceDetails(int Id, Guid UserID, bool IsActive)
        {
            int isExperienceDeleted = 0;
            try
            {
                isExperienceDeleted = _context.usp_UsersExperience_Deactivate(
                   Id, UserID, IsActive);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isExperienceDeleted;
        }

        #endregion Experience

        #region Education

        public IList<UsersEducationViewModel> GetEducationByUserID(Guid UserID)
        {
            IList<UsersEducationViewModel> educations = new List<UsersEducationViewModel>();

            try
            {
                educations = _context.usp_UsersEducation_GetByUserID(UserID)
                     .Select(x => new UsersEducationViewModel
                     {
                         Id = x.Id,
                         CourseSpecialization = x.CourseSpecialization,
                         Institute = x.Institute,
                         GPA = x.GPA,
                         StartPeriod = x.StartPeriod,
                         EndPeriod = x.EndPeriod,
                         Comments = x.Comments,
                         IsActive = x.IsActive,
                         UserID = x.UserID,
                         CreatedBy = x.CreatedBy,
                         UpdatedBy = x.UpdatedBy,
                         CreatedDate = x.CreatedDate,
                         UpdatedDate = x.UpdatedDate


                     }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return educations;
        }


        public int CreateEducationDetails(UsersEducationViewModel usersEducationViewModel)
        {
            int isEducationCreated = 0;
            try
            {
                isEducationCreated = _context.usp_UsersEducation_Insert(usersEducationViewModel.UserID, usersEducationViewModel.Institute,
                    usersEducationViewModel.CourseSpecialization, usersEducationViewModel.GPA, usersEducationViewModel.StartPeriod,
                    usersEducationViewModel.EndPeriod, usersEducationViewModel.Comments, usersEducationViewModel.CreatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isEducationCreated;
        }


        public int UpdateEducationDetails(UsersEducationViewModel usersEducationViewModel)
        {
            int isEducationCreated = 0;

            try
            {
                isEducationCreated = _context.usp_UsersEducation_Update(usersEducationViewModel.Id,
                    usersEducationViewModel.UserID, usersEducationViewModel.Institute, usersEducationViewModel.CourseSpecialization,
                    usersEducationViewModel.GPA, usersEducationViewModel.StartPeriod, usersEducationViewModel.EndPeriod, usersEducationViewModel.Comments,
                    usersEducationViewModel.UpdatedBy);
                   
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isEducationCreated;
        }


        public UsersEducationViewModel GetEducationByID(int EducationID)
        {
            UsersEducationViewModel education = new UsersEducationViewModel();
            try
            {
                education = _context.usp_UsersEducation_GetByID(EducationID)
                     .Select(x => new UsersEducationViewModel
                     {
                         Id = x.Id,
                         CourseSpecialization = x.CourseSpecialization,
                         Institute = x.Institute,
                         GPA = x.GPA,
                         StartPeriod = x.StartPeriod,
                         EndPeriod = x.EndPeriod,
                         Comments = x.Comments,
                         IsActive = x.IsActive,
                         UserID = x.UserID,
                         CreatedBy = x.CreatedBy,
                         UpdatedBy = x.UpdatedBy,
                         CreatedDate = x.CreatedDate,
                         UpdatedDate = x.UpdatedDate


                     }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return education;
        }


        public int DeleteEducationDetails(int Id, Guid UserID, bool IsActive)
        {
            int isEducationDeleted = 0;
            try
            {
                isEducationDeleted = _context.usp_UsersEducation_Deactivate(
                 Id, UserID, IsActive);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isEducationDeleted;
        }

        #endregion Education

        #region ReportingTo

        public int ManageReportingTo(ReportingToViewModel reportingToViewModel)
        {
            int isManaged = 0;
            try
            {
                if (!reportingToViewModel.IsUserDelete)
                {
                    isManaged = _context.usp_UsersReporting_Insert(reportingToViewModel.UserID,
                        reportingToViewModel.RepotingToUserID, reportingToViewModel.IsDirectReportingTo,
                        reportingToViewModel.ManagedBy);
                }
                else
                {
                    isManaged = _context.usp_UsersReporting_DeletetByUserID(reportingToViewModel.UserID,
                         reportingToViewModel.RepotingToUserID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isManaged;
        }


        /// <summary>
        /// the resultant users will be reporting to selected or login user
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public IList<SelectedUsers> GetReportingToByUserID(Guid UserID)
        {
            IList<SelectedUsers> Reporting = new List<SelectedUsers>();
            try
            {
                Reporting = _context.usp_UsersReporting_GetByRepotingToUserID(UserID)
                            .Select(x => new SelectedUsers
                             {
                                 id = x.UserID.ToString(),
                                 value = x.UserDisplayName

                             }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Reporting;
        }

        /// <summary>
        /// selected or login user will be reporting to resultant users
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public IList<SelectedUsers> GetUsersReportingByUserID(Guid UserID)
        {
            IList<SelectedUsers> Reporting = new List<SelectedUsers>();
            try
            {
                Reporting = _context.usp_UsersReporting_GetByUserID(UserID)
                            .Select(x => new SelectedUsers
                            {
                                id = x.RepotingToUserID.ToString(),
                                value = x.RepotingToUserDisplayName

                            }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Reporting;
        }

        #endregion ReportingTo

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