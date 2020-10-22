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
    [Route("api/uniFalcutys")]
    [ApiController]
    public class UniFalcutysController : ControllerBase
    {

        private readonly IUniFalcutyService _service;

        /*private readonly IMapper _mapper;*/
        private readonly SWDContext _context;

        public UniFalcutysController(IUniFalcutyService service, SWDContext context)
        {
            _service = service;
            _context = context;
        }



        // GET api/jobs
        [HttpGet]
        public IActionResult Get()
        {
            var result = _service.GetAllUniFalcuty();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}/{uniCode}")]
        public IActionResult GetUniFalcutyId(string id,string uniCode)
        {
            Expression<Func<UniFalcuty, bool>> expression = u => u.UniCode == uniCode && u.FalcutyCode == id;
            var result = _service.GetByTwoID(expression);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }


        [HttpPut ("{id}/{uniCode}")]
        public IActionResult UpdateUniFalcutyById(string id,string uniCode, [FromBody] UniFalcuty uniFalcutyDTO)
        {
       /*     var uniFalcuty = _mapper.Map<UniFalcuty>(uniFalcutyDTO);// mapping object to a row in db
            if(_id != uniFalcuty.Code)
            {
                return BadRequest();
            }*/

            var uniFalcutyCheckingExist = _service.GetUniFalcutyByID(id);
            if(uniFalcutyCheckingExist != null)
            {
                _service.UpdateUniFalcuty(uniFalcutyDTO);
                try
                {
                    _service.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsExistUniFalcuty(id, uniCode))
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
        // POST: UniFalcutysController/Create
        [HttpPost]
        public IActionResult Post([FromBody] UniFalcuty _entity)
        {
            _service.CreateUniFalcuty(_entity);
            _service.Commit();
            return Created("Get", _entity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUniFalcutyByID(string id)
        {
            var uniFalcuty = _service.GetUniFalcutyByID(id);
            if(uniFalcuty != null)
            {
                _service.DeleteUniFalcuty(id);
                _service.Commit();
                return Ok(uniFalcuty);
            }
            else
            {
                return NotFound();
            }
        }


      
        private bool IsExistUniFalcuty(string id,string uniCode)
        {
            return _context.UniFalcuty.Any(e => e.FalcutyCode == id && e.UniCode == uniCode);
        }
    }
}
