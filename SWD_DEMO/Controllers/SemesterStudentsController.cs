using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWD_DEMO.Models;
using SWD_DEMO.Services;

namespace SWD_DEMO.Controllers
{
    [Route("api/semesterStudentStudents")]
    [ApiController]
    public class SemesterStudentsController : ControllerBase
    {

        private readonly ISemesterStudentService _service;

        /*private readonly IMapper _mapper;*/
        private readonly SWDContext _context;

        public SemesterStudentsController(ISemesterStudentService service, SWDContext context)
        {
            _service = service;
            _context = context;
        }



        // GET api/jobs
        [HttpGet]
        public IActionResult Get()
        {
            var result = _service.GetAllSemesterStudent();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}/{stuCode}")]
        public IActionResult GetSemesterStudentId(string id,string stuCode)
        {
            Expression<Func<SemesterStudent, bool>> expression = u => u.StuCode == stuCode && u.SemesterCode == id;

            var result = _service.GetByTwoID(expression);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }


        [HttpPut ("{id}/{stucode}")]
        public IActionResult UpdateSemesterStudentById(string id,string stucode, [FromBody] SemesterStudent semesterStudentDTO)
        {
       /*     var semesterStudent = _mapper.Map<SemesterStudent>(semesterStudentDTO);// mapping object to a row in db
            if(_id != semesterStudent.Code)
            {
                return BadRequest();
            }*/

            var semesterStudentCheckingExist = _service.GetSemesterStudentByID(id);
            if(semesterStudentCheckingExist != null)
            {
                _service.UpdateSemesterStudent(semesterStudentDTO);
                try
                {
                    _service.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsExistSemesterStudent(id, stucode))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return NoContent();
          
        }
        // POST: SemesterStudentsController/Create
        [HttpPost]
        public IActionResult Post([FromBody] SemesterStudent _entity)
        {
            _service.CreateSemesterStudent(_entity);
            _service.Commit();
            return Created("Get", _entity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSemesterStudentByID(string id)
        {
            var semesterStudent = _service.GetSemesterStudentByID(id);
            if(semesterStudent != null)
            {
                _service.DeleteSemesterStudent(id);
                _service.Commit();
                return Ok(semesterStudent);
            }
            else
            {
                return NotFound();
            }
        }


      
        private bool IsExistSemesterStudent(string id,string stucode)
        {
            return _context.SemesterStudent.Any(e => e.SemesterCode == id && e.StuCode == stucode);
        }
    }
}
