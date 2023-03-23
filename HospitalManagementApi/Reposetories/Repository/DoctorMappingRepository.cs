using System;
using System.Linq;
using HospitalManagementApi.Models;
using HospitalManagementApi.Reposetories.Interface;
using HospitalManagementApi.ViewModel;

namespace HospitalManagementApi.Reposetories.Repository
{
    public class DoctorMappingRepository : IDoctorMappingRepository
    {
        private readonly HospitalManagementDBContext _context;

        public DoctorMappingRepository(HospitalManagementDBContext context)
        {
            _context = context;
        }
        public DoctorMapping Add(DoctorMappingViewModel value)
        {
            DoctorMapping doctorMapping = new()
            {
                DrId = value.DrId,
                ProductId = value.ProductId,
                IsActive = value.IsActive,
                CreateDate = DateTime.Now,
                CreateBy = 1
            };
            _context.DoctorMappings.Add(doctorMapping);
            _context.SaveChanges();
            return doctorMapping;
        }

        public DoctorMapping? Delete(int id)
        {


            var model = _context.DoctorMappings.Find(id);
            if (model == null)
            {
                return null;
            }
            _context.DoctorMappings.Remove(model);
            _context.SaveChanges();
            return model;
        }

        public IQueryable<DrProductViewModel> GetAllDoctorMapping()
        {

            return _context.DoctorMappings
                               .Select(x => new DrProductViewModel
                               {
                                   Id = x.Id,
                                   DrId = x.DrId,
                                   FirstName = x.Dr.FirstName,
                                   MiddleName = x.Dr.MiddleName,
                                   LastName = x.Dr.LastName,
                                   ProductId = x.ProductId,
                                   ProductName = x.Product.ProductName,
                                   IsActive = x.IsActive
                               });
        }

        public IQueryable<DrProductViewModel> GetDoctorMapping(int id)
        {
            var s = _context.DoctorMappings
             .Where(x => x.DrId == id)
             .Select(x => new DrProductViewModel
             {
                 Id = x.Id,
                 DrId = x.DrId,
                 FirstName = x.Dr.FirstName,
                 MiddleName = x.Dr.MiddleName,
                 LastName = x.Dr.LastName,
                 ProductId = x.ProductId,
                 ProductName = x.Product.ProductName,
                 IsActive = x.IsActive
             });

            return s;
        }

        public DoctorMapping? Update(DoctorMappingViewModel changeValue)
        {
            var record = _context.DoctorMappings.Find(changeValue.Id);

            if (record == null)
            {
                return null;
            }

            record.DrId = changeValue.DrId;
            record.ProductId = changeValue.ProductId;
            record.IsActive = changeValue.IsActive;
            record.ModifyDate = DateTime.Now;
            record.ModifyBy = 2;

            _context.DoctorMappings.Update(record);
            _context.SaveChanges();

            return record;
        }

        public IQueryable<ProductMasterViewModelGet> SearchProductByDoctorId(int id)
        {
            return _context.DoctorMappings
                   .Where(a => a.DrId == id)
                   .Select(x => new ProductMasterViewModelGet
                   {
                       Id = x.Product.Id,
                       ProductName = x.Product.ProductName,
                       ProductPrice = x.Product.ProductPrice,
                       ProductImage = x.Product.ProductImage,
                       Size = x.Product.Size,
                       Weight = x.Product.Weight,
                       Quantity = x.Product.Quantity,
                       Description = x.Product.Description,
                       ManufactureDate = x.Product.ManufactureDate,
                       ExpiryDate = x.Product.ExpiryDate,
                       Manufacturer = x.Product.Manufacturer,
                       IsActive = x.Product.IsActive
                   });
        }
    }
}
