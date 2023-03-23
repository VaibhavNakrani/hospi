using System;
using HospitalManagementApi.Reposetories.Interface;
using HospitalManagementApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DoctorController : Controller
    {
        private readonly IDoctorMasterRepository _doctorMasterRepository;

        public DoctorController(IDoctorMasterRepository doctorMasterRepository)
        {
            _doctorMasterRepository = doctorMasterRepository;
        }

        [HttpGet]
        [Route("Search")]
        public IActionResult SearchDoctorByName(string drName)
        {
            var result = _doctorMasterRepository.SearchDr(drName);
            return new JsonResult(result);
        }

        [HttpGet]
        public IActionResult GetAllDoctor()
        {
            var model = _doctorMasterRepository.GetAllDoctor();
            return new JsonResult(model);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetDoctor(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Is InCorrect");
            }
            var model = _doctorMasterRepository.GetDoctor(id);
            return new JsonResult(model);
        }

        [HttpPost]
        public IActionResult Create(DoctorMasterViewModel value)
        {
            var model = _doctorMasterRepository.Add(value);
            return new JsonResult(model);
        }


        [HttpPut]
        public IActionResult Update(DoctorMasterViewModel value)
        {
            var model = _doctorMasterRepository.Update(value);
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
            var model = _doctorMasterRepository.Delete(id);
            return Ok(model);
        }
    }
}
