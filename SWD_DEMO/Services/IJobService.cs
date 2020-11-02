using AutoMapper.Configuration.Conventions;
using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public interface IJobService : IBaseService<Job,int>
    {
        Job CreateJob(Job _entity);
        Job UpdateJob(Job _entity);
        Job DeleteJob(int _id);

        Job GetJobByID(int _id);
        IEnumerable<Job> GetAllJob(int pageNum, int recordPerPage);

        IEnumerable<Job> GetAllJob(int pageNum, int recordPerPage, string uniCode,string majorCode);

    }
}
