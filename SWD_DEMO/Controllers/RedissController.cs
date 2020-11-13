using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using EasyCaching.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using SWD_DEMO.DTOS;
using SWD_DEMO.Models;
using SWD_DEMO.Services;
using Umbraco.Core.Models.Entities;

namespace SWD_DEMO.Controllers
{
    [Route("api/redis")]
    [ApiController]
    public class RedissController : ControllerBase
    {
        private IEasyCachingProvider cachingProvider;
        private IRedisCachingProvider redisCachingProvider;
        private IEasyCachingProviderFactory cachingProviderFactory;
        private readonly IJobService _service;

        /*private readonly IMapper _mapper;*/
        private readonly SWDContext _context;

        public RedissController(IRedisCachingProvider provider, IEasyCachingProviderFactory cachingProviderFactory, IJobService service, SWDContext context)
        {
            this.cachingProviderFactory = cachingProviderFactory;
            this.redisCachingProvider = provider;
            this.cachingProvider = this.cachingProviderFactory.GetCachingProvider("redis1");
            _service = service;
            _context = context;

        }


        // GET api/jobs
        [HttpGet("jobAll/{pageNum}")]
        public IActionResult Get(int pageNum)
        {
            var result = _service.GetAllJob(pageNum);
            this.cachingProvider.Set("JobList1", "okvalue", TimeSpan.FromSeconds(30));
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("job1Name",result.ToList().ElementAt(1).Name);
            dic.Add("job1CompCode", result.ToList().ElementAt(1).CompCode);
            this.redisCachingProvider.HMSet("JobListHM", dic, TimeSpan.FromSeconds(60));
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        // GET api/jobs
        [HttpGet("Get/{pageNum}")]
        public IActionResult GetItemInQueue(int pageNum)
        {
            var item = this.cachingProvider.Get<string>("JobList1");
            var items = this.redisCachingProvider.HGetAll("JobListHM");

            return Ok(items);


        }


        }
}
