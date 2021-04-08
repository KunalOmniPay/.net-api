using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using SchoolTeacherManagement.Repository;
using SchoolTeacherManagement.Services;
using CustomExceptions;

namespace SchoolTeacherManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolServices _schoolServices;

        public SchoolsController(ISchoolServices schoolServices)
        {
            _schoolServices = schoolServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddSchool(School school)
        {
            try
            {
                return Ok(await _schoolServices.AddSchool(school));
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetAllSchool()
        {
            try
            {
                return Ok(await _schoolServices.GetAllSchool());
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
        [HttpPut]
        public async Task<IActionResult> UpdateSchool(School school)
        {
            try
            {
                return Ok(await _schoolServices.UpdatSchool(school));
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(DataNotFound ex)
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
