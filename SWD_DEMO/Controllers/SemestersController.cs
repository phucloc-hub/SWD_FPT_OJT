using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWD_DEMO.Models;
using SWD_DEMO.Services;

namespace SWD_DEMO.Controllers
{
    [Route("api/semesters")]
    [ApiController]
    public class SemestersController : ControllerBase
    {

        private readonly ISemesterService _service;

        /*private readonly IMapper _mapper;*/
        private readonly SWDContext _context;

        public SemestersController(ISemesterService service, SWDContext context)
        {
            _service = service;
            _context = context;
        }



        // GET api/jobs
        [HttpGet]
        public IActionResult Get()
        {
            var result = _service.GetAllSemester();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetSemesterId(string id)
        {
            var result = _service.GetByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }


        [HttpPut ("{id}")]
        public IActionResult UpdateSemesterById(string id,[FromBody] Semester semesterDTO)
        {
       /*     var semester = _mapper.Map<Semester>(semesterDTO);// mapping object to a row in db
            if(_id != semester.Code)
            {
                return BadRequest();
            }*/

            var semesterCheckingExist = _service.GetSemesterByID(id);
            if(semesterCheckingExist != null)
            {
                _service.UpdateSemester(semesterDTO);
                try
                {
                    _service.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsExistSemester(id))
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
        // POST: SemestersController/Create
        [HttpPost]
        public IActionResult Post([FromBody] Semester _entity)
        {
            _service.CreateSemester(_entity);
            _service.Commit();
            return Created("Get", _entity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSemesterByID(string id)
        {
            var semester = _service.GetSemesterByID(id);
            if(semester != null)
            {
                _service.DeleteSemester(id);
                _service.Commit();
                return Ok(semester);
            }
            else
            {
                return NotFound();
            }
        }


      
        private bool IsExistSemester(string id)
        {
            return _context.Semester.Any(e => e.Code == id);
        }
    }
}
