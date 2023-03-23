using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalManagementApi.Models
{
    public partial class DoctorTypeMaster
    {
        public DoctorTypeMaster()
        {
            DoctorMasters = new HashSet<DoctorMaster>();
            ProductMappings = new HashSet<ProductMapping>();
        }

        public int Id { get; set; }
        public string DrTypeName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyBy { get; set; }

        public virtual ICollection<DoctorMaster> DoctorMasters { get; set; }
        public virtual ICollection<ProductMapping> ProductMappings { get; set; }
    }
}
