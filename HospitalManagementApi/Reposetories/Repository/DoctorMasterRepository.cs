using System;
using System.Linq;
using HospitalManagementApi.Models;
using HospitalManagementApi.Reposetories.Interface;
using HospitalManagementApi.ViewModel;

namespace HospitalManagementApi.Reposetories.Repository
{
    public class DoctorMasterRepository : IDoctorMasterRepository
    {
        private readonly HospitalManagementDBContext _context;

        public DoctorMasterRepository(HospitalManagementDBContext context)
        {
            _context = context;
        }

        public DoctorMaster Add(DoctorMasterViewModel value)
        {

            DoctorMaster doctorMaster = new()
            {
                DrTypeId = value.DrTypeId,
                DrLicenceNo = value.DrLicenceNo,
                FirstName = value.FirstName,
                MiddleName = value.MiddleName,
                LastName = value.LastName,
                PersonalMobileNo = value.PersonalMobileNo,
                EmargencyMobileNo = value.EmargencyMobileNo,
                Email = value.Email,
                Age = value.Age,
                GenderId = value.GenderId,
                Qualification = value.Qualification,
                Address = value.Address,
                IsActive = value.IsActive,
                CreateDate = DateTime.Now,
                CreateBy = 1
            };

            _context.DoctorMasters.Add(doctorMaster);
            _context.SaveChanges();

            return doctorMaster;
        }

        public DoctorMaster? Delete(int id)
        {
            var model = _context.DoctorMasters.Find(id);

            if (model == null)
            {
                return null;
            }

            _context.DoctorMasters.Remove(model);
            _context.SaveChanges();

            return model;
        }

        public IQueryable<GetDoctorViewModel> GetAllDoctor()
        {
            return _context.DoctorMasters
                .Select(x => new GetDoctorViewModel
                {
                    Id = x.Id,
                    DrTypeId = x.DrTypeId,
                    DrTypeName = x.DrType.DrTypeName,
                    DrLicenceNo = x.DrLicenceNo,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    PersonalMobileNo = x.PersonalMobileNo,
                    EmargencyMobileNo = x.EmargencyMobileNo,
                    Email = x.Email,
                    Age = x.Age,
                    GenderId = x.GenderId,
                    Gender = x.Gender.Gender,
                    Qualification = x.Qualification,
                    Address = x.Address,
                    IsActive = x.IsActive,
                    FullName = x.FirstName + " " + x.MiddleName + " " + x.LastName,
                });
        }

        public GetDoctorViewModel? GetDoctor(int id)
        {
            return _context.DoctorMasters
                .Where(x => x.Id == id)
                .Select(x => new GetDoctorViewModel
                {
                    Id = x.Id,
                    DrTypeId = x.DrTypeId,
                    DrTypeName = x.DrType.DrTypeName,
                    DrLicenceNo = x.DrLicenceNo,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    PersonalMobileNo = x.PersonalMobileNo,
                    EmargencyMobileNo = x.EmargencyMobileNo,
                    Email = x.Email,
                    Age = x.Age,
                    GenderId = x.GenderId,
                    Gender = x.Gender.Gender,
                    Qualification = x.Qualification,
                    Address = x.Address,
                    IsActive = x.IsActive
                }).FirstOrDefault();
        }

        public IQueryable<GetDoctorViewModel> SearchDr(string name)
        {
            IQueryable<DoctorMaster> data = _context.DoctorMasters;

            if (!string.IsNullOrEmpty(name))
            {
                data = data.Where(x => x.FirstName.StartsWith(name));
            }

            return data.Select(x => new GetDoctorViewModel
            {
                Id = x.Id,
                DrTypeId = x.DrTypeId,
                DrTypeName = x.DrType.DrTypeName,
                DrLicenceNo = x.DrLicenceNo,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                PersonalMobileNo = x.PersonalMobileNo,
                EmargencyMobileNo = x.EmargencyMobileNo,
                Email = x.Email,
                Age = x.Age,
                GenderId = x.GenderId,
                Gender = x.Gender.Gender,
                Qualification = x.Qualification,
                Address = x.Address,
                IsActive = x.IsActive
            });
        }

        public DoctorMaster? Update(DoctorMasterViewModel model)
        {
            var record = _context.DoctorMasters.Find(model.Id);

            if (record is null)
            {
                return null;
            }

            record.DrTypeId = model.DrTypeId;
            record.DrLicenceNo = model.DrLicenceNo;
            record.FirstName = model.FirstName;
            record.MiddleName = model.MiddleName;
            record.LastName = model.LastName;
            record.PersonalMobileNo = model.PersonalMobileNo;
            record.EmargencyMobileNo = model.EmargencyMobileNo;
            record.Email = model.Email;
            record.Age = model.Age;
            record.GenderId = model.GenderId;
            record.Qualification = model.Qualification;
            record.Address = model.Address;
            record.IsActive = model.IsActive;
            record.ModifyDate = DateTime.Now;
            record.ModifyBy = 2;

            _context.DoctorMasters.Update(record);
            _context.SaveChanges();

            return record;
        }
    }
}