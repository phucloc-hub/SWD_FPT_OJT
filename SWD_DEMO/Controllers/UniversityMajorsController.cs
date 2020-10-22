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
    [Route("api/universityMajors")]
    [ApiController]
    public class UniversityMajorsController : ControllerBase
    {

        private readonly IUniversityMajorService _service;

        /*private readonly IMapper _mapper;*/
        private readonly SWDContext _context;

        public UniversityMajorsController(IUniversityMajorService service, SWDContext context)
        {
            _service = service;
            _context = context;
        }

        // GET api/jobs
        [HttpGet]
        public IActionResult Get()
        {
            var result = _service.GetAllUniversityMajor();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}/{uniCode}")]
        public IActionResult GetUniversityMajorId(string id,string uniCode)
        {
            Expression<Func<UniversityMajor, bool>> expression = u => u.UniCode == uniCode && u.MajorCode == id;

            var result = _service.GetByTwoID(expression);

            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }


        [HttpPut("{id}/{uniCode}")]
        public IActionResult UpdateStudentById(string _id, string uniCode, [FromBody] UniversityMajor universityMajorDTO)
        {
            /*var universityMajor = _mapper.Map<UniversityMajor>(universityMajorDTO);// mapping object to a row in db
            if (_id != universityMajor.Code)
            {
                return BadRequest();
            }*/

            var universityMajorCheckingExist = _service.GetUniversityMajorByID(_id);
            if (universityMajorCheckingExist != null)
            {
                _service.UpdateUniversityMajor(universityMajorDTO);
                try
                {
                    _service.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsExistUniversityMajor(_id, uniCode))
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
        // POST: UniversityMajorsController/Create
        [HttpPost]
        public IActionResult Post([FromBody] UniversityMajor _entity)
        {
            _service.CreateUniversityMajor(_entity);
            _service.Commit();
            return Created("Get", _entity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUniversityMajorByID(string _id)
        {
            var universityMajor = _service.GetUniversityMajorByID(_id);
            if (universityMajor != null)
            {
                _service.DeleteUniversityMajor(_id);
                _service.Commit();
                return Ok(universityMajor);
            }
            else
            {
                return NotFound();
            }
        }



        private bool IsExistUniversityMajor(string id,string uniCode)
        {
            return _context.UniversityMajor.Any(e => e.MajorCode == id && e.UniCode == uniCode);
        }
    }
}
