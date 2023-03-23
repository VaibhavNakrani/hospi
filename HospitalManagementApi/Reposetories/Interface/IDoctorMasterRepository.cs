using System.Linq;
using HospitalManagementApi.Models;
using HospitalManagementApi.ViewModel;

namespace HospitalManagementApi.Reposetories.Interface
{
    public interface IDoctorMasterRepository
    {
        IQueryable<GetDoctorViewModel> SearchDr(string name);
        GetDoctorViewModel GetDoctor(int id);
        IQueryable<GetDoctorViewModel> GetAllDoctor();
        DoctorMaster Add(DoctorMasterViewModel value);
        DoctorMaster Update(DoctorMasterViewModel model);
        DoctorMaster Delete(int id);
    }
}
