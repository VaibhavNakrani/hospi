using System.Linq;
using HospitalManagementApi.Models;
using HospitalManagementApi.ViewModel;

namespace HospitalManagementApi.Reposetories.Interface
{
    public interface IProductMasterRepository
    {
        ProductMasterViewModelGet GetProduct(int id);
        IQueryable<ProductMasterViewModelGet> GetAllProduct();
        IQueryable<ProductMasterViewModelGet> SearchProduct(string name);
        ProductMaster Add(ProductMasterViewModelCreaate value);
        ProductMaster Update(ProductMasterViewModelCreaate changeValue);
        ProductMaster Delete(int id);
    }
}
//, IFormFile file