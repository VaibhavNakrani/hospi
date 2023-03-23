using System.ComponentModel.DataAnnotations;

namespace HospitalManagementApi.ViewModel
{
    public class DoctorTypeMasterViewModel
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string DrTypeName { get; set; }
        public bool IsActive { get; set; }

    }
}
