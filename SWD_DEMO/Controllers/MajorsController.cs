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
    [Route("api/majors")]
    [ApiController]
    public class MajorsController : ControllerBase
    {

        private readonly IMajorService _service;

        /*private readonly IMapper _mapper;*/
        private readonly SWDContext _context;

        public MajorsController(IMajorService service, SWDContext context)
        {
            _service = service;
            _context = context;
        }



        // GET api/jobs
        [HttpGet]
        public IActionResult Get()
        {
            var result = _service.GetAllMajor();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetMajorId(string id)
        {
            var result = _service.GetByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }


        [HttpPut ("{id}")]
        public IActionResult UpdateMajorById(string id,[FromBody] Major majorDTO)
        {
       /*     var major = _mapper.Map<Major>(majorDTO);// mapping object to a row in db
            if(_id != major.Code)
            {
                return BadRequest();
            }*/

            var majorCheckingExist = _service.GetMajorByID(id);
            if(majorCheckingExist != null)
            {
                _service.UpdateMajor(majorDTO);
                try
                {
                    _service.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsExistMajor(id))
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
        // POST: MajorsController/Create
        [HttpPost]
        public IActionResult Post([FromBody] Major _entity)
        {
            _service.CreateMajor(_entity);
            _service.Commit();
            return Created("Get", _entity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMajorByID(string id)
        {
            var major = _service.GetMajorByID(id);
            if(major != null)
            {
                _service.DeleteMajor(id);
                _service.Commit();
                return Ok(major);
            }
            else
            {
                return NotFound();
            }
        }


      
        private bool IsExistMajor(string id)
        {
            return _context.Major.Any(e => e.Code == id);
        }
    }
}
