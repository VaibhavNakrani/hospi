using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalManagementApi.Models
{
    public partial class ProductMaster
    {
        public ProductMaster()
        {
            DoctorMappings = new HashSet<DoctorMapping>();
            ProductMappings = new HashSet<ProductMapping>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public string Size { get; set; }
        public decimal? Weight { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Manufacturer { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyBy { get; set; }

        public virtual ICollection<DoctorMapping> DoctorMappings { get; set; }
        public virtual ICollection<ProductMapping> ProductMappings { get; set; }
    }
}
