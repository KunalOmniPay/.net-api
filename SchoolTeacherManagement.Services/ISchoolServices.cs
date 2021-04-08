using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTeacherManagement.Services
{
    public interface ISchoolServices
    {
        Task<bool> AddSchool(School school);
        Task<bool> UpdatSchool(School school);
        Task<List<School>> GetAllSchool();
    }
}
