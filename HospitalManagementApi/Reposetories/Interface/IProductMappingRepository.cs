using System.Linq;
using HospitalManagementApi.Models;
using HospitalManagementApi.ViewModel;

namespace HospitalManagementApi.Reposetories.Interface
{
    public interface IProductMappingRepository
    {
        DrTypeProductViewModel GetProductMapping(int id);
        IQueryable<DrTypeProductViewModel> GetAllProductMapping();
        ProductMapping Add(ProductMappingViewModel value);
        ProductMapping Update(ProductMappingViewModel changevalue);
        ProductMapping Delete(int id);
    }
}
