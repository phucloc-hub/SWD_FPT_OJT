using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD_DEMO.DTOS;
using SWD_DEMO.Models;
using SWD_DEMO.Services;

namespace SWD_DEMO.Controllers
{
    //[EnableCors("CorsPolicy")]
    [Route("api/googleChart")]
    [ApiController]
    public class GoogleChartsController : ControllerBase
    {

        private readonly IGoogleChartService _service;

        private readonly ICompanyService _comService;

        private readonly IMapper _mapper;
        private readonly SWDContext _context;

        public GoogleChartsController(IGoogleChartService service,ICompanyService companyService, SWDContext context, IMapper mapper)
        {
            _service = service;
            _comService = companyService;
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult Get()
        {
            //var listComp = _comService.GetAll();
            //var listresponse =new List<HotCompanyDTO>();
            //foreach(Company a in listComp)
            //{
            //    HotCompanyDTO hotCompany = new HotCompanyDTO();
            //    hotCompany.Code = a.Code;
            //    hotCompany.NumberOfapplication = _service.GetReportForHotCompany(a.Code);
            //    listresponse.Add(hotCompany);

            //}
            var resul = _service.GetReportForHotCompany();
            if (resul != null)
            {
                return Ok(resul);
            }
            return NotFound();
        }
    }
}
