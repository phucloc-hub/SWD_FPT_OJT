using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public class JobService : BaseService<Job,int>,IJobService
    {

        public JobService(SWDContext context) : base(context)
        {
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

        public IEnumerable<Job> GetAllJob(int pageNum,int recordPerPage)
        {
            return GetAll(pageNum,recordPerPage);
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
