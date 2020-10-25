using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SWD_DEMO.DTOS;
using SWD_DEMO.Models;
using SWD_DEMO.Services;

namespace SWD_DEMO.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly IStudentService _service;

        private readonly IMapper _mapper;
        private readonly SWDContext _context;
        

        public StudentsController(IStudentService service, SWDContext context, IMapper mapper)
        {
            _service = service;
            _context = context;
            _mapper = mapper;
        }




        [HttpGet("{id}")]
        public IActionResult GetStudentId(string _id)
        {
            var result = _service.GetByID(_id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }


        // GET api/jobs
        [HttpGet("student")]
        /*public IActionResult GetStudent([FromBody] Account accountReq) => accountReq.Email.IsNullOrEmpty() ? GetAllStudent() : GetStudentInFoByEmail(accountReq);*/
        public IActionResult GetAllStudent()
        {
            var result = _service.GetAllStudent();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetStudentInFoByEmail( Account accountReq)
        {

            if (!accountReq.Role.IsNullOrEmpty()  && accountReq.Role.Equals("Student"))
            {
                var result = _service.GetStudentByEmail(accountReq.Email);
               var studentinfp = _mapper.Map<StudentRespInfo>(result);
                studentinfp.Name = result.MajorCodeNavigation.Name;

                if (result != null)
                {
                    return Ok(studentinfp);
                }
                return NotFound();
            }
            else
            {
                return BadRequest();
            }
            
        }

        


        [HttpPut ("{id}")]
        public IActionResult UpdateStudentById(string _id,[FromBody] Student studentDTO)
        {
       /*     var student = _mapper.Map<Student>(studentDTO);// mapping object to a row in db
            if(_id != student.Code)
            {
                return BadRequest();
            }*/

            var studentCheckingExist = _service.GetStudentByID(_id);
            if(studentCheckingExist != null)
            {
                _service.UpdateStudent(studentDTO);
                try
                {
                    _service.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsExistStudent(_id))
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
        // POST: StudentsController/Create
        [HttpPost]
        public IActionResult Post([FromBody] Student _entity)
        {
            _service.CreateStudent(_entity);
            _service.Commit();
            return Created("Get", _entity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudentByID(string _id)
        {
            var student = _service.GetStudentByID(_id);
            if(student != null)
            {
                _service.DeleteStudent(_id);
                _service.Commit();
                return Ok(student);
            }
            else
            {
                return NotFound();
            }
        }


      
        private bool IsExistStudent(string id)
        {
            return _context.Student.Any(e => e.Code == id);
        }
    }
}
