using System.ComponentModel.DataAnnotations;

namespace HospitalManagementApi.ViewModel
{
    public class ProductMappingViewModel
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int DrTypeId { get; set; }
        public bool IsActive { get; set; }

    }
}
