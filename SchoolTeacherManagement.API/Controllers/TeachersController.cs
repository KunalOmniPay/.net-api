using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using SchoolTeacherManagement.Services;
using SchoolTeacherManagement.Repository;
using CustomExceptions;

namespace SchoolTeacherManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherServices _TeacherServices;

        public TeachersController(ITeacherServices teacherServices)
        {
            _TeacherServices = teacherServices;
        }
        [HttpPost]
        public async Task<IActionResult> AddTeacher(Teacher teacher)
        {
            try
            {
                return Ok(await _TeacherServices.AddTeacher(teacher));
            }
            catch(SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DataNotFound ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetAllTeachers()
        {
            try
            {
                return Ok(await _TeacherServices.GetAllTeacher());
            }
            catch(SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(DataNotFound ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("{schoolId}")]

        public async Task<IActionResult> GetTeacherBySchool(int schoolId)
        {
            try
            {
                return Ok(await _TeacherServices.GetTeacherBySchool(schoolId));
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DataNotFound ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteTeacher(int id)
        {
            try
            {
                return Ok(await _TeacherServices.DeleteTeacher(id));
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DataNotFound ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





    }

       
}
