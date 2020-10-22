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
    [Route("api/universitySemesters")]
    [ApiController]
    public class UniversitySemestersController : ControllerBase
    {

        private readonly IUniversitySemesterService _service;

        /*private readonly IMapper _mapper;*/
        private readonly SWDContext _context;

        public UniversitySemestersController(IUniversitySemesterService service, SWDContext context)
        {
            _service = service;
            _context = context;
        }

        // GET api/jobs
        [HttpGet]
        public IActionResult Get()
        {
            var result = _service.GetAllUniversitySemester();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}/{uniCode}")]
        public IActionResult GetUniversitySemesterId(string id,string uniCode)
        {
            Expression<Func<UniversitySemester, bool>> expression = u => u.UniCode == uniCode && u.SemesterCode == id;


            var result = _service.GetByTwoID(expression);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }


        [HttpPut("{id}/{uniCode}")]
        public IActionResult UpdateStudentById(string _id, string uniCode, [FromBody] UniversitySemester universitySemesterDTO)
        {
            /*var universitySemester = _mapper.Map<UniversitySemester>(universitySemesterDTO);// mapping object to a row in db
            if (_id != universitySemester.Code)
            {
                return BadRequest();
            }*/

            var universitySemesterCheckingExist = _service.GetUniversitySemesterByID(_id);
            if (universitySemesterCheckingExist != null)
            {
                _service.UpdateUniversitySemester(universitySemesterDTO);
                try
                {
                    _service.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsExistUniversitySemester(_id, uniCode))
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
        // POST: UniversitySemestersController/Create
        [HttpPost]
        public IActionResult Post([FromBody] UniversitySemester _entity)
        {
            _service.CreateUniversitySemester(_entity);
            _service.Commit();
            return Created("Get", _entity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUniversitySemesterByID(string _id)
        {
            var universitySemester = _service.GetUniversitySemesterByID(_id);
            if (universitySemester != null)
            {
                _service.DeleteUniversitySemester(_id);
                _service.Commit();
                return Ok(universitySemester);
            }
            else
            {
                return NotFound();
            }
        }



        private bool IsExistUniversitySemester(string id,string uniCode)
        {
            return _context.UniversitySemester.Any(e => e.SemesterCode == id && e.UniCode == uniCode);
        }
    }
}
