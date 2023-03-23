using HospitalManagementApi.Reposetories.Interface;
using HospitalManagementApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DoctorTypeController : ControllerBase
    {
        private readonly IDoctorTypeMasterRepository _doctorTypeMasterRepository;

        public DoctorTypeController(IDoctorTypeMasterRepository doctorTypeMasterRepository)
        {
            _doctorTypeMasterRepository = doctorTypeMasterRepository;
        }

        [HttpGet]
        [Route("Search")]
        public IActionResult SearchDoctorType(string type)
        {
            var result = _doctorTypeMasterRepository.SearchDoctorType(type);
            return new JsonResult(result);
        }

        [HttpGet]
        public IActionResult GetAllDoctorType()
        {
            var model = _doctorTypeMasterRepository.GetAllDoctorType();
            return new JsonResult(model);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetDoctorType(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Is InCorrect");
            }
            var model = _doctorTypeMasterRepository.GetDoctorType(id);
            return new JsonResult(model);
        }

        [HttpPost]
        public IActionResult Create(DoctorTypeMasterViewModel value)
        {
            var model = _doctorTypeMasterRepository.Add(value);
            return new JsonResult(model);
        }

        [HttpPut]
        public IActionResult Update(DoctorTypeMasterViewModel value)
        {
            var model = _doctorTypeMasterRepository.Update(value);
            return Ok(model);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Is InCorrect");
            }
            var model = _doctorTypeMasterRepository.Delete(id);
            return Ok(model);
        }
    }
}
