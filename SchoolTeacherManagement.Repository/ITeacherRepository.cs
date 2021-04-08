using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTeacherManagement.Repository
{
    public interface ITeacherRepository
    {
        Task<bool> AddTeacher(Teacher teacher);
        Task<List<Teacher>> GetTeacherBySchool(int schoolId);
        Task<bool> DeleteTeacher(int id);
        Task<List<Teacher>> GetAllTeacher();
    }
}
