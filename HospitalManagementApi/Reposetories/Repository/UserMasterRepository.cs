using HospitalManagementApi.Models;
using HospitalManagementApi.Reposetories.Interface;
using HospitalManagementApi.ViewModel;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace HospitalManagementApi.Reposetories.Repository
{
    public class UserMasterRepository : IUserMasterRepository
    {
        private readonly HospitalManagementDBContext _context;

        public UserMasterRepository(HospitalManagementDBContext context)
        {
            _context = context;
        }
        public UserMasterViewModelGet Login(LoginModel loginModel)
        {
            var model = _context.UserMasters.Where(x => x.UserName == loginModel.UserName && x.Password == loginModel.Password)
                            .Select(x => new UserMasterViewModelGet
                            {
                                Id = x.Id,
                                FirstName = x.FirstName,
                                LastName = x.LastName,
                                Email = x.Email,
                                MobileNo = x.MobileNo,
                                BirthDate = x.BirthDate,
                                UserName = x.UserName,
                                Password = x.Password,
                                Address = x.Address,
                                PinCode = x.PinCode,
                                IsActive = x.IsActive,
                                CreateDate = x.CreateDate,
                                CreateBy = x.CreateBy,
                                ModifyBy = x.ModifyBy,
                                ModifyDate = x.ModifyDate

                            }).FirstOrDefault();
            return model;
        }

        public IQueryable<UserMasterViewModelGet> GetAllUser()
        {
            var model = _context.UserMasters.Select(x => new UserMasterViewModelGet
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                MobileNo = x.MobileNo,
                BirthDate = x.BirthDate,
                UserName = x.UserName,
                Password = x.Password,
                Address = x.Address,
                PinCode = x.PinCode,
                IsActive = x.IsActive,
                CreateDate = x.CreateDate,
                CreateBy = x.CreateBy,
                ModifyBy = x.ModifyBy,
                ModifyDate = x.ModifyDate
            });
            return model;
        }

        public UserMaster Add(UserMasterViewModel value)
        {
            UserMaster user = new UserMaster
            {
                Id = value.Id,
                FirstName = value.FirstName,
                LastName = value.LastName,
                Email = value.Email,
                MobileNo = value.MobileNo,
                BirthDate = value.BirthDate,
                UserName = value.UserName,
                Password = value.Password,
                Address = value.Address,
                PinCode = value.PinCode,
                IsActive = value.IsActive,
                CreateDate = value.CreateDate,
                CreateBy = value.CreateBy
            };
            _context.Add(user);
            _context.SaveChanges();
            return user;
        }

        public UserMaster Update(UserMasterViewModel changeValue)
        {
            UserMaster user = new UserMaster
            {
                Id = changeValue.Id,
                FirstName = changeValue.FirstName,
                LastName = changeValue.LastName,
                Email = changeValue.Email,
                MobileNo = changeValue.MobileNo,
                BirthDate = changeValue.BirthDate,
                UserName = changeValue.UserName,
                Password = changeValue.Password,
                Address = changeValue.Address,
                PinCode = changeValue.PinCode,
                IsActive = changeValue.IsActive,
                CreateDate = changeValue.CreateDate,
                CreateBy = changeValue.CreateBy
            };
            _context.Add(user);
            _context.SaveChanges();
            return user;
        }

        public UserMaster Delete(int id)
        {
            var model = _context.UserMasters.Find(id);

            if (model == null)
            {
                return null;
            }

            _context.UserMasters.Remove(model);
            _context.SaveChanges();

            return model;
        }
    }
}
