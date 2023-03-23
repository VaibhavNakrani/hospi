using System.Linq;
using HospitalManagementApi.Models;
using HospitalManagementApi.ViewModel;

namespace HospitalManagementApi.Reposetories.Interface
{
    public interface IGenderMasterRepository
    {
        GenderMasterViewModel GetGender(int id);
        IQueryable<GenderMasterViewModel> GetAllGender();
        GenderMaster Add(GenderMasterViewModel value);
        GenderMaster Update(GenderMasterViewModel changevalue);
        GenderMaster Delete(int id);
    }
}
