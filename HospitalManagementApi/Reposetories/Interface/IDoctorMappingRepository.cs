using System.Linq;
using HospitalManagementApi.Models;
using HospitalManagementApi.ViewModel;

namespace HospitalManagementApi.Reposetories.Interface
{
    public interface IDoctorMappingRepository
    {
        IQueryable<ProductMasterViewModelGet> SearchProductByDoctorId(int id);
        IQueryable<DrProductViewModel> GetDoctorMapping(int id);
        IQueryable<DrProductViewModel> GetAllDoctorMapping();
        DoctorMapping Add(DoctorMappingViewModel value);
        DoctorMapping Update(DoctorMappingViewModel changeValue);
        DoctorMapping Delete(int id);
    }
}
