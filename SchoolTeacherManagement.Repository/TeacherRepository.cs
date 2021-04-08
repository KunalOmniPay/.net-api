using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomExceptions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolTeacherManagement.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        public readonly SchoolTeacherDbContext _schoolTeacherDbContext;
        public TeacherRepository(SchoolTeacherDbContext schoolTeacherDbContext)
        {
            _schoolTeacherDbContext = schoolTeacherDbContext;
        }
        public async Task<bool> AddTeacher(Teacher teacher)
        {
            int rowAffected = 0;
            try
            {
                School school = await _schoolTeacherDbContext.Schools.FirstOrDefaultAsync(g => g.SchoolId == teacher.SchoolId);
                Subjects subjects = await _schoolTeacherDbContext.Subjetcs.FirstOrDefaultAsync(g => g.SubjectId == teacher.SubjectId);
                if (school != null && subjects != null)
                {
                    _schoolTeacherDbContext.Add(teacher);
                    rowAffected = await _schoolTeacherDbContext.SaveChangesAsync();
                    if (rowAffected == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    throw new DataNotFound("No data is Present");
                }
            }
            catch (DataNotFound ex)
            {
                throw new DataNotFound("School or subject with given id is not  present", ex);
            }
            catch (Exception ex)
            {
                throw new SqlException("Could Not Connect!", ex);
            }
        }

        public async Task<bool> DeleteTeacher(int id)
        {
            try
            {
                Teacher teacher = await _schoolTeacherDbContext.Teachers.FirstOrDefaultAsync(g => g.TeacherId == id);
                if (teacher != null)
                {
                    int rowAffected = 0;
                    _schoolTeacherDbContext.Remove(teacher);
                    rowAffected = await _schoolTeacherDbContext.SaveChangesAsync();
                    if (rowAffected != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    throw new DataNotFound("No data is Present");
                }
            }
            catch (DataNotFound ex)
            {
                throw new DataNotFound("School or subject with given id is not  present", ex);
            }
            catch (Exception ex)
            {
                throw new SqlException("Failed to Coonect", ex);
            }
        }

        public async Task<List<Teacher>> GetAllTeacher()
        {
            try
            {
                List<Teacher> teachers = await _schoolTeacherDbContext.Teachers.ToListAsync();
                if (teachers == null)
                {
                    throw new DataNotFound("No data is Present");
                }
                return teachers;
            }
            catch (DataNotFound ex)
            {
                throw new DataNotFound("School or subject with given id is not  present", ex);
            }
            catch (Exception ex)
            {
                throw new DataNotFound("Could Not Connect", ex);
            }
        }

        public async Task<List<Teacher>> GetTeacherBySchool(int schoolId)
        {
            try
            {
                List<Teacher> teacherList = await _schoolTeacherDbContext.Teachers.Where(g => g.SchoolId == schoolId).ToListAsync();
                if (teacherList == null)
                {
                    throw new DataNotFound("No Data is Present");
                }
                return teacherList;
            }
            catch (DataNotFound ex)
            {
                throw new DataNotFound("School or subject with given id is not  present", ex);
            }
            catch (Exception ex)
            {
                throw new SqlException("Failed to connect", ex);
            }
        }
    }
}
