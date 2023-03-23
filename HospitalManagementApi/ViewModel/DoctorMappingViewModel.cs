using System.ComponentModel.DataAnnotations;

namespace HospitalManagementApi.ViewModel
{
    public class DoctorMappingViewModel
    {
        public int Id { get; set; }
        [Required]
        public int DrId { get; set; }
        [Required]
        public int ProductId { get; set; }

        public bool IsActive { get; set; }

    }
}
