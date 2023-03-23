using HospitalManagementApi.Models;
using HospitalManagementApi.ViewModel;
using System.Linq;

namespace HospitalManagementApi.Reposetories.Interface
{
    public interface IUserMasterRepository
    {
        UserMasterViewModelGet Login(LoginModel loginModel);
        IQueryable<UserMasterViewModelGet> GetAllUser();
        UserMaster Add(UserMasterViewModel value);
        UserMaster Update(UserMasterViewModel changeValue);
        UserMaster Delete(int id);

    }
}
