using HospitalManagementApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System;
using HospitalManagementApi.Reposetories.Interface;

namespace HospitalManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserMasterRepository _userMasterRepository;
        private readonly IConfiguration _configuration;

        public AccountController(IUserMasterRepository userMasterRepository, IConfiguration configuration)
        {
            _userMasterRepository = userMasterRepository;
            _configuration = configuration;
        }
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            var user = _userMasterRepository.Login(loginModel);
            if (user is null)
            {
                return BadRequest("user not found");
            }
            var token = new JwtSecurityToken
               (
                   issuer: _configuration.GetValue<string>("Jwt:Issuer"),
            audience: _configuration.GetValue<string>("Jwt:Audience"),
                   expires: DateTime.UtcNow.AddMinutes(10),
                   signingCredentials: new SigningCredentials(
                       new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Jwt:Key"))),
                       SecurityAlgorithms.HmacSha256)
               );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            ResponseModel response = new();
            response.Msg = "Login Sucessfully";
            response.Data = user;
            response.Token = tokenString;
            return Ok(response);
        }
    }
}
