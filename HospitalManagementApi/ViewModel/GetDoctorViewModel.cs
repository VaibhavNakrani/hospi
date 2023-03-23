namespace HospitalManagementApi.ViewModel
{
    public class GetDoctorViewModel
    {
        public int Id { get; set; }
        public int DrTypeId { get; set; }
        public string DrTypeName { get; set; }
        public string DrLicenceNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PersonalMobileNo { get; set; }
        public string EmargencyMobileNo { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int GenderId { get; set; }
        public string Gender { get; set; }
        public string Qualification { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public string FullName { get; set; }
    }
}