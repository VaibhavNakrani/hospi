using System.ComponentModel.DataAnnotations;

namespace HospitalManagementApi.ViewModel
{
    public class GenderMasterViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string Gender { get; set; }
    }
}
