using System.Linq;
using HospitalManagementApi.Models;
using HospitalManagementApi.Reposetories.Interface;
using HospitalManagementApi.ViewModel;

namespace HospitalManagementApi.Reposetories.Repository
{

    public class GenderMasterRepository : IGenderMasterRepository
    {
        private readonly HospitalManagementDBContext _context;

        public GenderMasterRepository(HospitalManagementDBContext context)
        {
            _context = context;
        }
        public GenderMaster Add(GenderMasterViewModel value)
        {
            GenderMaster gender = new()
            {
                Gender = value.Gender
            };
            _context.GenderMasters.Add(gender);
            _context.SaveChanges();
            return gender;
        }

        public GenderMaster Delete(int id)
        {
            var model = _context.GenderMasters.Find(id);
            if (model != null)
            {
                _context.GenderMasters.Remove(model);
                _context.SaveChanges();
            }
            return model;
        }

        public IQueryable<GenderMasterViewModel> GetAllGender()
        {
            return _context.GenderMasters
                .Select(x => new GenderMasterViewModel
                {
                    Id = x.Id,
                    Gender = x.Gender
                });
        }

        public GenderMasterViewModel GetGender(int id)
        {
            return _context.GenderMasters
                .Where(x => x.Id == id)
                .Select(x => new GenderMasterViewModel
                {
                    Id = x.Id,
                    Gender = x.Gender

                }).FirstOrDefault()!;
        }


        public GenderMaster Update(GenderMasterViewModel changevalue)
        {
            var record = _context.GenderMasters.Find(changevalue.Id);

            if (record != null)
            {
                record.Gender = changevalue.Gender;

                _context.GenderMasters.Update(record);
                _context.SaveChanges();
                return record;
            }
            return record;
        }
    }
}
