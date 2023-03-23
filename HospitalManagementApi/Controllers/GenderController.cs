using HospitalManagementApi.Reposetories.Interface;
using HospitalManagementApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GenderController : ControllerBase
    {
        private readonly IGenderMasterRepository _genderMasterRepository;

        public GenderController(IGenderMasterRepository genderMasterRepository)
        {
            _genderMasterRepository = genderMasterRepository;
        }

        [HttpGet]
        public IActionResult GetAllGender()
        {
            var model = _genderMasterRepository.GetAllGender();
            return new JsonResult(model);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetGender(int id)
        {
            var model = _genderMasterRepository.GetGender(id);
            return new JsonResult(model);
        }

        [HttpPost]
        public IActionResult Create(GenderMasterViewModel value)
        {
            var model = _genderMasterRepository.Add(value);
            return new JsonResult(model);
        }

        [HttpPut]
        public IActionResult Update(GenderMasterViewModel value)
        {
            var model = _genderMasterRepository.Update(value);
            return Ok(model);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            var model = _genderMasterRepository.Delete(id);
            return Ok(model);
        }
    }
}
