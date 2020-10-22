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
    [Route("api/universitys")]
    [ApiController]
    public class UniversitysController : ControllerBase
    {

        private readonly IUniversityService _service;

        /*private readonly IMapper _mapper;*/
        private readonly SWDContext _context;

        public UniversitysController(IUniversityService service, SWDContext context)
        {
            _service = service;
            _context = context;
        }

        // GET api/jobs
        [HttpGet]
        public IActionResult Get()
        {
            var result = _service.GetAllUniversity();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetUniversityId(string _id)
        {
            var result = _service.GetByID(_id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateStudentById(string _id, [FromBody] University universityDTO)
        {
            /*var university = _mapper.Map<University>(universityDTO);// mapping object to a row in db
            if (_id != university.Code)
            {
                return BadRequest();
            }*/

            var universityCheckingExist = _service.GetUniversityByID(_id);
            if (universityCheckingExist != null)
            {
                _service.UpdateUniversity(universityDTO);
                try
                {
                    _service.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsExistUniversity(_id))
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
        // POST: UniversitysController/Create
        [HttpPost]
        public IActionResult Post([FromBody] University _entity)
        {
            _service.CreateUniversity(_entity);
            _service.Commit();
            return Created("Get", _entity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUniversityByID(string _id)
        {
            var university = _service.GetUniversityByID(_id);
            if (university != null)
            {
                _service.DeleteUniversity(_id);
                _service.Commit();
                return Ok(university);
            }
            else
            {
                return NotFound();
            }
        }



        private bool IsExistUniversity(string id)
        {
            return _context.University.Any(e => e.Code == id);
        }
    }
}
