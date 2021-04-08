using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTeacherManagement.Repository
{
    public interface ISchoolRepository
    {
        Task<bool> AddSchool(School school);
        Task<bool> UpdateSchool(School school);

        Task<List<School>> GetAllSchool();
    }
}
