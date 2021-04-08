using CustomExceptions;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolTeacherManagement.Repository
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly SchoolTeacherDbContext _schoolTeacherDbContext;
        public SchoolRepository(SchoolTeacherDbContext schoolTeacherDbContext)
        {
            _schoolTeacherDbContext = schoolTeacherDbContext;
        }
        public async Task<bool> AddSchool(School school)
        {
            int rowAffected = 0;
            try
            {
                _schoolTeacherDbContext.Add(school);
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
            catch (DataNotFound ex)
            {
                throw new DataNotFound("School or subject with given id is not  present", ex);
            }
            catch (Exception ex)
            {
                throw new SqlException("Could Not Connect!", ex);
            }

        }

        public async Task<List<School>> GetAllSchool()
        {
            try
            {
                List<School> schools = await _schoolTeacherDbContext.Schools.ToListAsync();
                if (schools == null)
                {
                    throw new DataNotFound("No data is Present");
                }
                return schools;
            }
            catch (DataNotFound ex)
            {
                throw new DataNotFound("School or subject with given id is not  present", ex);
            }
            catch (Exception ex)
            {
                throw new SqlException("Could not Connect", ex);
            }
        }

        public async Task<bool> UpdateSchool(School school) 
        {
            try
            {
                School schoolTemp = await _schoolTeacherDbContext.Schools.FirstOrDefaultAsync(g => g.SchoolId == school.SchoolId);
                if (schoolTemp != null)
                {
                    schoolTemp.SchoolAddress = school.SchoolAddress;
                    int rowAffected = 0;
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
                    throw new DataNotFound("No Data is Present");
                } 
            }
            catch (DataNotFound ex)
            {
                throw new DataNotFound("School or subject with given id is not  present", ex);
            }
            catch (Exception ex)
            {
                throw new SqlException("Could Not Connect",ex);
            }
            
        }
    }
}
