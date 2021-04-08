using Entities;
using SchoolTeacherManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTeacherManagement.Services
{
   public  class TeacherServices : ITeacherServices
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherServices(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public async Task<bool> AddTeacher(Teacher teacher)
        {
            return await _teacherRepository.AddTeacher(teacher);
        }

  

        public async Task<List<Teacher>> GetTeacherBySchool(int schoolId)
        {
            return await _teacherRepository.GetTeacherBySchool(schoolId);
        }



        public async Task<bool> DeleteTeacher(int id)
        {
            return await _teacherRepository.DeleteTeacher(id);
        }

        public async Task<List<Teacher>> GetAllTeacher()
        {
            return await _teacherRepository.GetAllTeacher();
        }
    }
}
