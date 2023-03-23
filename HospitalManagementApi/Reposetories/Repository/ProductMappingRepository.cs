using System;
using System.Linq;
using HospitalManagementApi.Models;
using HospitalManagementApi.Reposetories.Interface;
using HospitalManagementApi.ViewModel;

namespace HospitalManagementApi.Reposetories.Repository
{
    public class ProductMappingRepository : IProductMappingRepository
    {
        private readonly HospitalManagementDBContext _context;

        public ProductMappingRepository(HospitalManagementDBContext context)
        {
            _context = context;
        }
        public ProductMapping Add(ProductMappingViewModel value)
        {
            ProductMapping productMapping = new()
            {
                ProductId = value.ProductId,
                DrTypeId = value.DrTypeId,
                IsActive = value.IsActive,
                CreateDate = DateTime.Now,
                CreateBy = 1
            };

            _context.ProductMappings.Add(productMapping);
            _context.SaveChanges();
            return productMapping;
        }

        public ProductMapping Delete(int id)
        {
            var record = _context.ProductMappings.Find(id);
            if (record == null)
            {
                return record;
            }
            _context.ProductMappings.Remove(record);
            _context.SaveChanges();
            return record;
        }

        public IQueryable<DrTypeProductViewModel> GetAllProductMapping()
        {
            return _context.ProductMappings
                .Select(x => new DrTypeProductViewModel
                {
                    Id = x.Id,
                    DrTypeId = x.DrTypeId,
                    DrTypeName = x.DrType.DrTypeName,
                    ProductId = x.ProductId,
                    ProductName = x.Product.ProductName,
                    IsActive = x.IsActive
                });
        }

        public DrTypeProductViewModel GetProductMapping(int id)
        {
            return _context.ProductMappings
                .Where(x => x.Id == id)
                .Select(x => new DrTypeProductViewModel
                {
                    Id = x.Id,
                    DrTypeId = x.DrTypeId,
                    DrTypeName = x.DrType.DrTypeName,
                    ProductId = x.ProductId,
                    ProductName = x.Product.ProductName,
                    IsActive = x.IsActive
                }).FirstOrDefault();
        }

        public ProductMapping Update(ProductMappingViewModel changevalue)
        {
            var record = _context.ProductMappings.Find(changevalue.Id);
            if (record != null)
            {
                record.ProductId = changevalue.ProductId;
                record.DrTypeId = changevalue.DrTypeId;
                record.IsActive = changevalue.IsActive;
                record.ModifyDate = DateTime.Now;
                record.ModifyBy = 2;

                _context.ProductMappings.Update(record);
                _context.SaveChanges();
                return record;
            }
            return record;
        }


    }
}
