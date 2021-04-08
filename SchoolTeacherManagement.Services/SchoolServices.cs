using Entities;
using SchoolTeacherManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTeacherManagement.Services
{
    public class SchoolServices : ISchoolServices
    {
        private readonly ISchoolRepository _Repository;
        public SchoolServices(ISchoolRepository schoolRepository)
        {
            _Repository = schoolRepository;
        }
        public async Task<bool> AddSchool(School school)
        {
            return await _Repository.AddSchool(school);
        }

        public async Task<List<School>> GetAllSchool()
        {
            return await _Repository.GetAllSchool();
        }

        public async Task<bool> UpdatSchool(School school)
        {
            return await _Repository.UpdateSchool(school);
        }
    }
}
