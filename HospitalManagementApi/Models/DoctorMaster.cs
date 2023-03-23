using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalManagementApi.Models
{
    public partial class DoctorMaster
    {
        public DoctorMaster()
        {
            DoctorMappings = new HashSet<DoctorMapping>();
        }

        public int Id { get; set; }
        public int DrTypeId { get; set; }
        public string DrLicenceNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PersonalMobileNo { get; set; }
        public string EmargencyMobileNo { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int GenderId { get; set; }
        public string Qualification { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyBy { get; set; }

        public virtual DoctorTypeMaster DrType { get; set; }
        public virtual GenderMaster Gender { get; set; }
        public virtual ICollection<DoctorMapping> DoctorMappings { get; set; }
    }
}
