using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalManagementApi.Models
{
    public partial class ProductMapping
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int DrTypeId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyBy { get; set; }

        public virtual DoctorTypeMaster DrType { get; set; }
        public virtual ProductMaster Product { get; set; }
    }
}
