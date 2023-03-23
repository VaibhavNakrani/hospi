using HospitalManagementApi.Reposetories.Interface;
using HospitalManagementApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace HospitalManagementApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserMasterRepository _userMasterRepository;

        public UserController(IUserMasterRepository userMasterRepository)
        {
            _userMasterRepository = userMasterRepository;
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            var model = _userMasterRepository.GetAllUser().ToList();
            return new JsonResult(model);
        }        

        [HttpPost]
        public IActionResult Create(UserMasterViewModel userMaster)
        {
            var user = _userMasterRepository.Add(userMaster);
            return new JsonResult(user);
        }
        
        [HttpPost]
        public IActionResult Update(UserMasterViewModel userMaster)
        {
            var user = _userMasterRepository.Add(userMaster);
            return new JsonResult(user);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Is InCorrect");
            }
            var model = _userMasterRepository.Delete(id);
            return Ok(model);
        }
    }
}
