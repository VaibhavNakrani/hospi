using HospitalManagementApi.Reposetories.Interface;
using HospitalManagementApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IProductMasterRepository _productMasterRepository;

        public ProductController(IProductMasterRepository productMasterRepository)
        {
            _productMasterRepository = productMasterRepository;
        }

        [HttpGet]
        [Route("Search")]
        public IActionResult SearchProductByName(string productName)
        {
            var result = _productMasterRepository.SearchProduct(productName);
            return new JsonResult(result);
        }

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            var model = _productMasterRepository.GetAllProduct();
            return new JsonResult(model);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetProduct(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Is InCorrect");
            }
            var model = _productMasterRepository.GetProduct(id);
            return new JsonResult(model);
        }

        [HttpPost]
        public IActionResult Create(ProductMasterViewModelCreaate value)
        {
            /*if (!ModelState.IsValid)
            {
                var message = ModelState.Values
                    .SelectMany(x => x.Errors.Select(c => c.ErrorMessage))
                    .ToArray();

                return BadRequest(message);
            }

            var extension = Path.GetExtension(value.ProductImage.FileName);

            var list = new[] { ".Png", ".Jpg", ".Jpeg", ".Bmp" };

            var success = false;

            foreach (var item in list)
            {
                success = string.Equals(extension, item, StringComparison.InvariantCultureIgnoreCase);

                if (success)
                {
                    break;
                }
            }

            if (!success)
            {
                return BadRequest("select valid file");
            }
            , value.ProductImage
             */

            var model = _productMasterRepository.Add(value);
            return new JsonResult(model);
        }

        [HttpPut]
        public IActionResult Update(ProductMasterViewModelCreaate value)
        {
            var model = _productMasterRepository.Update(value);
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
            var model = _productMasterRepository.Delete(id);
            return Ok(model);
        }
    }
}
