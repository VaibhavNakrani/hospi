using System.ComponentModel.DataAnnotations;

namespace HospitalManagementApi.ViewModel
{
    public class DoctorMasterViewModel
    {
        public int Id { get; set; }
        [Required]
        public int DrTypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string DrLicenceNo { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        [StringLength(13, MinimumLength = 10)]
        public string PersonalMobileNo { get; set; }
        [Required]
        [StringLength(13, MinimumLength = 10)]
        public string EmargencyMobileNo { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(100)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string Email { get; set; }
        [Required]
        [Range(23, 120, ErrorMessage = "Age must be between 23-120 in years.")]
        public int Age { get; set; }
        [Required]
        public int GenderId { get; set; }
        [Required]
        [StringLength(100)]
        public string Qualification { get; set; }
        [Required]
        [StringLength(500)]
        public string Address { get; set; }
        public bool IsActive { get; set; }

    }
}
