using System;
using System.Linq;
using HospitalManagementApi.Models;
using HospitalManagementApi.Reposetories.Interface;
using HospitalManagementApi.ViewModel;

namespace HospitalManagementApi.Reposetories.Repository
{
    public class DoctorTypeMasterRepository : IDoctorTypeMasterRepository
    {
        private readonly HospitalManagementDBContext _context;

        public DoctorTypeMasterRepository(HospitalManagementDBContext context)
        {
            _context = context;
        }
        public DoctorTypeMaster Add(DoctorTypeMasterViewModel value)
        {
            DoctorTypeMaster typeMaster = new()
            {
                DrTypeName = value.DrTypeName,
                IsActive = value.IsActive,
                CreateDate = DateTime.Now,
                CreateBy = 1
            };
            _context.DoctorTypeMasters.Add(typeMaster);
            _context.SaveChanges();
            return typeMaster;
        }

        public DoctorTypeMaster? Delete(int id)
        {
            var model = _context.DoctorTypeMasters.Find(id);
            if (model == null)
            {
                return null;
            }
            _context.DoctorTypeMasters.Remove(model);
            _context.SaveChanges();

            return model;
        }

        public IQueryable<DoctorTypeMasterViewModel> GetAllDoctorType()
        {
            return _context.DoctorTypeMasters
                .Select(x => new DoctorTypeMasterViewModel
                {
                    Id = x.Id,
                    DrTypeName = x.DrTypeName,
                    IsActive = x.IsActive
                });
        }

        public DoctorTypeMasterViewModel? GetDoctorType(int id)
        {
            return _context.DoctorTypeMasters
                .Where(x => x.Id == id)
                .Select(x => new DoctorTypeMasterViewModel
                {
                    Id = x.Id,
                    DrTypeName = x.DrTypeName,
                    IsActive = x.IsActive
                }).FirstOrDefault();
        }

        public IQueryable<DoctorTypeMasterViewModel> SearchDoctorType(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return _context.DoctorTypeMasters
                .Where(x => x.DrTypeName.Contains(name))
                .Select(x => new DoctorTypeMasterViewModel
                {
                    Id = x.Id,
                    DrTypeName = x.DrTypeName,
                    IsActive = x.IsActive
                });
            }
            return null!;
        }

        public DoctorTypeMaster? Update(DoctorTypeMasterViewModel changeValue)
        {
            var record = _context.DoctorTypeMasters.Find(changeValue.Id);

            if (record == null)
            {
                return null;
            }
            record.DrTypeName = changeValue.DrTypeName;
            record.IsActive = changeValue.IsActive;
            record.ModifyDate = DateTime.Now;
            record.ModifyBy = 2;

            _context.DoctorTypeMasters.Update(record);
            _context.SaveChanges();
            return record;
        }
    }
}
