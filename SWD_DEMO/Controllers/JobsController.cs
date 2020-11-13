﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWD_DEMO.Constants;
using SWD_DEMO.DTOS;
using SWD_DEMO.Models;
using SWD_DEMO.Services;
using Umbraco.Core.Models.Entities;

namespace SWD_DEMO.Controllers
{
    [Route("api/jobs")]
    [ApiController]
    public class JobsController : ControllerBase
    {

        private readonly IJobService _service;

        private readonly IMapper _mapper;
        private readonly SWDContext _context;

        public JobsController(IJobService service, SWDContext context,IMapper mapper)
        {
            _service = service;
            _context = context;
            _mapper = mapper;
 
        }


        // GET api/jobs
        [HttpGet("jobAll/{pageNum}")]
        public IActionResult Get(int pageNum)
        {
            var result = _service.GetAllJob(pageNum);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        // GET api/jobs
        [HttpGet("{pageNum}/{uniCode}/{majorCode}/{subject}")]
        public IActionResult Get(int pageNum,string uniCode,string majorCode,string subject)
        {
            var result = _service.GetAllJob(pageNum, uniCode, majorCode, subject);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        

        // GET api/jobs
        [HttpGet("{uniCode}/{majorCode}/{subject}")]
        public IActionResult GetAllJobForListOptions(string uniCode, string majorCode, string subject)
        {
            List<JobResponseForListOption> asd = new List<JobResponseForListOption>();
            var result = _service.GetAllJobForListOptions(uniCode, majorCode, subject);

            foreach(var rs in result)
            {
                var jobResponse = _mapper.Map<JobResponseForListOption>(rs);
                 asd.Add(jobResponse);
               
            }

            IEnumerable<JobResponseForListOption> rsl = asd;

            if (result != null)
            {
                return Ok(rsl);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetJobId(int id)
        {
            var result = _service.GetByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateJobById(int id,[FromBody] Job jobDTO)
        {
           /* var config = new MapperConfiguration(cfg => cfg.CreateMap<JobDTOResponse, Job> ());
            var mapper = new Mapper(config);
            var dto = mapper.Map<Job>(jobDTO);*/

            /*var job = _mapper.Map<Job>(jobDTO);*/// mapping object to a row in db


            /*  if (_id != job.Code)
              {
                  return BadRequest();
              }*/

            var jobCheckingExist = _service.GetJobByID(id);
            if(jobCheckingExist != null)
            {
                _service.UpdateJob(jobDTO);
                try
                {
                    /*this._context.Job.Update(jobDTO);*/
                    _service.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsExistJob(id))
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
        // POST: JobsController/Create
        [HttpPost]
        public IActionResult Post([FromBody] Job _entity)
        {
            _service.CreateJob(_entity);
            _service.Commit();
            return Created("Get", _entity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJobByID(int id)
        {
            var job = _service.GetJobByID(id);
            if(job != null)
            {
                _service.DeleteJob(id);
                _service.Commit();
                return Ok(job);
            }
            else
            {
                return NotFound();
            }
        }



        private bool IsExistJob(int id)
        {
            return _context.Job.Any(e => e.Id == id);
        }
    }
}
