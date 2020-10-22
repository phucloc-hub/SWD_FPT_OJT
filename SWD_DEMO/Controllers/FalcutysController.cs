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
    [Route("api/falcutys")]
    [ApiController]
    public class FalcutysController : ControllerBase
    {

        private readonly IFalcutyService _service;

        /*private readonly IMapper _mapper;*/
        private readonly SWDContext _context;

        public FalcutysController(IFalcutyService service, SWDContext context)
        {
            _service = service;
            _context = context;
        }



        // GET api/jobs
        [HttpGet]
        public IActionResult Get()
        {
            var result = _service.GetAllFalcuty();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetFalcutyId(string id)
        {
            var result = _service.GetByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }


        [HttpPut ("{id}")]
        public IActionResult UpdateFalcutyById(string id,[FromBody] Falcuty falcutyDTO)
        {
       /*     var falcuty = _mapper.Map<Falcuty>(falcutyDTO);// mapping object to a row in db
            if(_id != falcuty.Code)
            {
                return BadRequest();
            }*/

            var falcutyCheckingExist = _service.GetFalcutyByID(id);
            if(falcutyCheckingExist != null)
            {
                _service.UpdateFalcuty(falcutyDTO);
                try
                {
                    _service.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsExistFalcuty(id))
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
        // POST: FalcutysController/Create
        [HttpPost]
        public IActionResult Post([FromBody] Falcuty _entity)
        {
            _service.CreateFalcuty(_entity);
            _service.Commit();
            return Created("Get", _entity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFalcutyByID(string id)
        {
            var falcuty = _service.GetFalcutyByID(id);
            if(falcuty != null)
            {
                _service.DeleteFalcuty(id);
                _service.Commit();
                return Ok(falcuty);
            }
            else
            {
                return NotFound();
            }
        }


      
        private bool IsExistFalcuty(string id)
        {
            return _context.Falcuty.Any(e => e.Code == id);
        }
    }
}
