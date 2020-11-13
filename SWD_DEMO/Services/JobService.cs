using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SWD_DEMO.Constants;
using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Core;

namespace SWD_DEMO.Services
{
    public class JobService : BaseService<Job,int>,IJobService
    {
  
        SWDContext context;
        public JobService(SWDContext context) : base(context)
        {
           
            this.context = context;
        }

        public Job CreateJob(Job _entity)
        {
            Add(_entity);
            return _entity;
        }

        public Job DeleteJob(int _id)
        {
            return Delete(_id);
        }

        public IEnumerable<Job> GetAllJob(int pageNum)
        {
            return GetAll(pageNum);
        }

        public IEnumerable<Job> GetAllJob(int pageNum, string uniCode, string majorCode, string subject)
        {
            /* string qr= 
           var query = from st in context.Job join Company
                       where st.StudentName == "Bill"
                       select st;

           var student = query.FirstOrDefault<Student>();*/
            string sql = "select * from job where job.CompCode in (select c.CompCode from connection c inner join company ca on ca.Code = c.CompCode where c.[unicode] = @uniCode)";




            return context.Job.FromSqlRaw(sql, new SqlParameter("@uniCode", uniCode)).Where(a => a.MajorCode == majorCode && a.Subject == subject).Skip((pageNum -1 ) * ConstantParameter.DataPerPage).Take(ConstantParameter.DataPerPage)
                              .ToList();
        }

        public IEnumerable<Job> GetAllJobForListOptions(string uniCode, string majorCode, string subject)
        {
            string sql = "select * from job where job.CompCode in (select c.CompCode from connection c inner join company ca on ca.Code = c.CompCode where c.[unicode] = @uniCode)";




            return context.Job.FromSqlRaw(sql, new SqlParameter("@uniCode", uniCode)).Where(a => a.MajorCode == majorCode && a.Subject == subject)
                              .ToList();
        }

        public Job GetJobByID(int _id)
        {
            return GetByID(_id);
        }

        public Job UpdateJob(Job _entity)
        {
            return Update(_entity);
        }
    }
}
