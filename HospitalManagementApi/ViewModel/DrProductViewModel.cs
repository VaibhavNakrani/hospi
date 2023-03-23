namespace HospitalManagementApi.ViewModel
{
    public class DrProductViewModel
    {
        public int Id { get; set; }
        public int DrId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public bool IsActive { get; set; }
    }
}
