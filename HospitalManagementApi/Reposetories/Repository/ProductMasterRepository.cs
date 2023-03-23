using System;
using System.Linq;
using HospitalManagementApi.Models;
using HospitalManagementApi.Reposetories.Interface;
using HospitalManagementApi.ViewModel;

namespace HospitalManagementApi.Reposetories.Repository
{
    public class ProductMasterRepository : IProductMasterRepository
    {
        private readonly HospitalManagementDBContext _context;

        public ProductMasterRepository(HospitalManagementDBContext context)
        {
            _context = context;
        }
        public ProductMaster Add(ProductMasterViewModelCreaate value)
        {
            /*var fileName = string.Join(null, Guid.NewGuid().ToString().Split('-')) + Path.GetExtension(file.FileName);

            value.ProductImage.SaveAsync($"{_environment.WebRootPath}\\Images\\{fileName}", System.Threading.CancellationToken.None).GetAwaiter().GetResult();*/

            ProductMaster productMaster = new()
            {
                ProductName = value.ProductName,
                ProductPrice = value.ProductPrice,
                ProductImage = value.ProductImage,
                Size = value.Size,
                Weight = value.Weight,
                Quantity = value.Quantity,
                Description = value.Description,
                ManufactureDate = value.ManufactureDate,
                ExpiryDate = value.ExpiryDate,
                Manufacturer = value.Manufacturer,
                IsActive = value.IsActive,
                CreateDate = DateTime.Now,
                CreateBy = 1
            };

            _context.ProductMasters.Add(productMaster);
            _context.SaveChanges();

            return productMaster;
        }

        public ProductMaster? Delete(int id)
        {
            var model = _context.ProductMasters.Find(id);

            if (model == null)
            {
                return null;
            }

            _context.ProductMasters.Remove(model);
            _context.SaveChanges();

            return model;
        }

        public IQueryable<ProductMasterViewModelGet> GetAllProduct()
        {
            return _context.ProductMasters
                 .Select(x => new ProductMasterViewModelGet
                 {
                     Id = x.Id,
                     ProductName = x.ProductName,
                     ProductPrice = x.ProductPrice,
                     ProductImage = x.ProductImage,
                     Size = x.Size,
                     Weight = x.Weight,
                     Quantity = x.Quantity,
                     Description = x.Description,
                     ManufactureDate = x.ManufactureDate,
                     ExpiryDate = x.ExpiryDate,
                     Manufacturer = x.Manufacturer,
                     IsActive = x.IsActive
                 });

        }

        public ProductMasterViewModelGet? GetProduct(int id)
        {
            return _context.ProductMasters
                .Where(x => x.Id == id)
                .Select(x => new ProductMasterViewModelGet
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    ProductPrice = x.ProductPrice,
                    ProductImage = x.ProductImage,
                    Size = x.Size,
                    Weight = x.Weight,
                    Quantity = x.Quantity,
                    Description = x.Description,
                    ManufactureDate = x.ManufactureDate,
                    ExpiryDate = x.ExpiryDate,
                    Manufacturer = x.Manufacturer,
                    IsActive = x.IsActive,
                }).FirstOrDefault();
        }

        public IQueryable<ProductMasterViewModelGet> SearchProduct(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return _context.ProductMasters
                .Where(x => x.ProductName.Contains(name))
                .Select(x => new ProductMasterViewModelGet
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    ProductPrice = x.ProductPrice,
                    ProductImage = x.ProductImage,
                    Size = x.Size,
                    Weight = x.Weight,
                    Quantity = x.Quantity,
                    Description = x.Description,
                    ManufactureDate = x.ManufactureDate,
                    ExpiryDate = x.ExpiryDate,
                    Manufacturer = x.Manufacturer,
                    IsActive = x.IsActive

                });
            }
            return null!;
        }

        public ProductMaster Update(ProductMasterViewModelCreaate changeValue)
        {
            /*var fileName = string.Join(null, Guid.NewGuid().ToString().Split('-')) + Path.GetExtension(file.FileName);

            file.SaveAsync($"{_environment.WebRootPath}\\Images\\{fileName}", System.Threading.CancellationToken.None).GetAwaiter().GetResult();
            */
            var record = _context.ProductMasters.Find(changeValue.Id);

            if (record == null)
            {
                return null!;
            }
            record.ProductName = changeValue.ProductName;
            record.ProductPrice = changeValue.ProductPrice;
            record.ProductImage = changeValue.ProductImage;
            record.Size = changeValue.Size;
            record.Weight = changeValue.Weight;
            record.Quantity = changeValue.Quantity;
            record.Description = changeValue.Description;
            record.ManufactureDate = changeValue.ManufactureDate;
            record.ExpiryDate = changeValue.ExpiryDate;
            record.Manufacturer = changeValue.Manufacturer;
            record.IsActive = changeValue.IsActive;
            record.ModifyDate = DateTime.Now;
            record.ModifyBy = 2;
            _context.ProductMasters.Update(record);
            _context.SaveChanges();
            return record;
        }
    }
}
