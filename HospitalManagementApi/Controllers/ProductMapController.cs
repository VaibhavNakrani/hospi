using HospitalManagementApi.Reposetories.Interface;
using HospitalManagementApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductMapController : ControllerBase
    {
        private readonly IProductMappingRepository _productMappingRepository;

        public ProductMapController(IProductMappingRepository productMappingRepository)
        {
            _productMappingRepository = productMappingRepository;
        }
        [HttpGet]
        public IActionResult GetAllProductMapping()
        {
            var model = _productMappingRepository.GetAllProductMapping();
            return new JsonResult(model);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetProductMapping(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Is InCorrect");
            }
            var model = _productMappingRepository.GetProductMapping(id);
            return new JsonResult(model);
        }

        [HttpPost]
        public IActionResult Create(ProductMappingViewModel value)
        {
            var model = _productMappingRepository.Add(value);
            return new JsonResult(model);
        }

        [HttpPut]
        public IActionResult Update(ProductMappingViewModel value)
        {
            var model = _productMappingRepository.Update(value);
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
            var model = _productMappingRepository.Delete(id);
            return Ok(model);
        }
    }
}
