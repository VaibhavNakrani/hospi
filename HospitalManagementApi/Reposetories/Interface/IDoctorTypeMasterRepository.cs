using System.Linq;
using HospitalManagementApi.Models;
using HospitalManagementApi.ViewModel;

namespace HospitalManagementApi.Reposetories.Interface
{
    public interface IDoctorTypeMasterRepository
    {
        DoctorTypeMasterViewModel GetDoctorType(int id);
        IQueryable<DoctorTypeMasterViewModel> GetAllDoctorType();
        IQueryable<DoctorTypeMasterViewModel> SearchDoctorType(string name);
        DoctorTypeMaster Add(DoctorTypeMasterViewModel value);
        DoctorTypeMaster Update(DoctorTypeMasterViewModel changevalue);
        DoctorTypeMaster Delete(int id);
    }
}
