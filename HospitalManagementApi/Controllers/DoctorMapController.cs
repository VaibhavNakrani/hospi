using HospitalManagementApi.Reposetories.Interface;
using HospitalManagementApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DoctorMapController : Controller
    {
        private readonly IDoctorMappingRepository _doctorMappingRepository;

        public DoctorMapController(IDoctorMappingRepository doctorMappingRepository)
        {
            _doctorMappingRepository = doctorMappingRepository;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetProductByDoctorId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Is InCorrect");
            }
            var model = _doctorMappingRepository.SearchProductByDoctorId(id);
            return new JsonResult(model);
        }

        [HttpGet]
        public IActionResult GetAllDoctorMapping()
        {
            var model = _doctorMappingRepository.GetAllDoctorMapping();
            return new JsonResult(model);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetDoctorMapping(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Is InCorrect");
            }
            var model = _doctorMappingRepository.GetDoctorMapping(id);
            return new JsonResult(model);
        }

        [HttpPost]
        public IActionResult Create(DoctorMappingViewModel value)
        {
            var model = _doctorMappingRepository.Add(value);
            return new JsonResult(model);
        }

        [HttpPut]
        public IActionResult Update(DoctorMappingViewModel value)
        {
            var model = _doctorMappingRepository.Update(value);
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
            var model = _doctorMappingRepository.Delete(id);
            return Ok(model);
        }

    }
}
