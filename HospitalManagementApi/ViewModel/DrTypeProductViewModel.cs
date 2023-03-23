namespace HospitalManagementApi.ViewModel
{
    public class DrTypeProductViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int DrTypeId { get; set; }
        public string DrTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
