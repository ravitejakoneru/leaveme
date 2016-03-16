using LeaveMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeaveMe.Data.Helpers
{
    public static class MappingExtensions
    {
        #region UsersProfile

        // mappings to PatientInsurance entity to Role view model 


        public static UsersProfileViewModel ToModel(this UsersProfile entity)
        {
            if (entity == null)
                return null;

            var model = new UsersProfileViewModel()
            {
                UserID = entity.UserID,
                FirstName = entity.FirstName,
                MiddleName = entity.MiddleName,
                LastName = entity.LastName,
                WorkTitleID = entity.WorkTitleID,
                DisplayID = entity.DisplayID,
                Gender = entity.Gender,
                DOB = entity.DOB,
                MartialStatus = entity.MartialStatus,
                Address = entity.Address,
                City = entity.City,
                State = entity.State,
                ZipCode = entity.ZipCode,
                Country = entity.Country,
                Mobile = entity.Mobile,
                OtherEmailAddress = entity.OtherEmailAddress,
                IsActive = entity.IsActive,
                CreatedBy = entity.CreatedBy,
                UpdatedBy = entity.UpdatedBy,
                CreatedDate = entity.CreatedDate,
                UpdatedDate = entity.UpdatedDate
            };
            return model;
        }


        public static UsersProfile ToEntity(this UsersProfileViewModel model)
        {
            if (model == null)
                return null;

            var entity = new UsersProfile();
            return ToEntity(model, entity);
        }

        public static UsersProfile ToEntity(this UsersProfileViewModel model, UsersProfile destination)
        {
            if (model == null)
                return destination;

            //destination.Id = model.Id;
            destination.UserID = model.UserID;
            destination.FirstName = model.FirstName;
            destination.MiddleName = model.MiddleName;
            destination.LastName = model.LastName;
            destination.WorkTitleID = model.WorkTitleID;
            destination.DisplayID = model.DisplayID;
            destination.Gender = model.Gender;
            destination.DOB = model.DOB;
            destination.MartialStatus = model.MartialStatus;
            destination.Address = model.Address;
            destination.City = model.City;
            destination.State = model.State;
            destination.ZipCode = model.ZipCode;
            destination.Country = model.Country;
            destination.Mobile = model.Mobile;
            destination.OtherEmailAddress = model.OtherEmailAddress;
            destination.IsActive = model.IsActive;
            destination.CreatedBy = model.CreatedBy;
            destination.UpdatedBy = model.UpdatedBy;
            destination.CreatedDate = model.CreatedDate;
            destination.UpdatedDate = model.UpdatedDate;

            return destination;
        }

        #endregion UsersProfile

        

    }
}