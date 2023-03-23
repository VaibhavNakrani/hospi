using System.ComponentModel.DataAnnotations;

namespace HospitalManagementApi.ViewModel
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class ResponseModel
    {
        public string Msg { get; set; }
        public object Data { get; set; }
        public string Token { get; set; }
    }
}
