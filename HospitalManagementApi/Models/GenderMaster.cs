using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalManagementApi.Models
{
    public partial class GenderMaster
    {
        public GenderMaster()
        {
            DoctorMasters = new HashSet<DoctorMaster>();
        }

        public int Id { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<DoctorMaster> DoctorMasters { get; set; }
    }
}
