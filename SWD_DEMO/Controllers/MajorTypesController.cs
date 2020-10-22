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
    [Route("api/majorTypes")]
    [ApiController]
    public class MajorTypesController : ControllerBase
    {

        private readonly IMajorTypeService _service;

        /*private readonly IMapper _mapper;*/
        private readonly SWDContext _context;

        public MajorTypesController(IMajorTypeService service, SWDContext context)
        {
            _service = service;
            _context = context;
        }



        // GET api/jobs
        [HttpGet]
        public IActionResult Get()
        {
            var result = _service.GetAllMajorType();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetMajorTypeId(string id)
        {
            var result = _service.GetByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }


        [HttpPut ("{id}")]
        public IActionResult UpdateMajorTypeById(string id,[FromBody] MajorType majorTypeDTO)
        {
       /*     var majorType = _mapper.Map<MajorType>(majorTypeDTO);// mapping object to a row in db
            if(_id != majorType.Code)
            {
                return BadRequest();
            }*/

            var majorTypeCheckingExist = _service.GetMajorTypeByID(id);
            if(majorTypeCheckingExist != null)
            {
                _service.UpdateMajorType(majorTypeDTO);
                try
                {
                    _service.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsExistMajorType(id))
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
        // POST: MajorTypesController/Create
        [HttpPost]
        public IActionResult Post([FromBody] MajorType _entity)
        {
            _service.CreateMajorType(_entity);
            _service.Commit();
            return Created("Get", _entity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMajorTypeByID(string id)
        {
            var majorType = _service.GetMajorTypeByID(id);
            if(majorType != null)
            {
                _service.DeleteMajorType(id);
                _service.Commit();
                return Ok(majorType);
            }
            else
            {
                return NotFound();
            }
        }


      
        private bool IsExistMajorType(string id)
        {
            return _context.MajorType.Any(e => e.MajorCode == id);
        }
    }
}
