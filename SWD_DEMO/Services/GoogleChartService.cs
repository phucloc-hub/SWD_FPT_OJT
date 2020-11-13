using Microsoft.EntityFrameworkCore;
using SWD_DEMO.DTOS;
using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public class GoogleChartService : IGoogleChartService
    {
        SWDContext context;
        public GoogleChartService(SWDContext context)
        {

            this.context = context;
        }
        public IEnumerable<HotCompanyDTO> GetReportForHotCompany()
        {
            //using (SWDContext context = new SWDContext())
            //{

            //    var hotJob = (from p in context.Job
            //                  join e in context.Application
            //                  on p.Id equals e.JobId
            //                  group p by p.Id into g
            //                  select new
            //                  {
            //                      Code = g


            //                  }).ToList();

            //}



            //            select Company.Name,Company.Code,a.NumberOfapplication from Company inner join(
            //            select Job.CompCode, SUM(1) as NumberOfapplication from Job inner join Application on Application.JobID = Job.ID group by CompCode) as a on a.CompCode = Company.Code
            //order by NumberOfapplication Desc


            //return context.Job.Include(a => a.Application).Include(a => a.CompCodeNavigation).Where(a => a.CompCode == _comCode).Count();
            string sql = "select Company.Name,Company.Code,a.NumberOfapplication from Company inner join ( select Job.CompCode,SUM(1) as NumberOfapplication from Job inner join Application on Application.JobID = Job.ID group by CompCode ) as a on a.CompCode = Company.Code order by NumberOfapplication Desc";

            //return context.HotCompanyDTO.FromSqlRaw(sql).ToList();

            //return (from p in Job 
            //              join e in context.Application
            //              on  equals e.JobID
            //              select new
            //              {
            //                  Code = Job.CompCode,
            //                  FirstName = p.FirstName,
            //                  MiddleName = p.MiddleName,
            //                  LastName = p.LastName,
            //                  EmailID = e.EmailAddress1
            //              }).ToList();
           
                var rs = context.HotCompanyDTOQuery.FromSqlRaw(sql).ToList();

            
            return rs;
        }
    }
}
