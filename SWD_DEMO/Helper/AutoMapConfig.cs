using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Helper
{
    public class AutoMapConfig : Profile
    {
        public AutoMapConfig()
        {
            // for student controller
            CreateMap<DTOS.StudentRespInfo, Models.Student>();
            CreateMap<Models.Student,DTOS.StudentRespInfo>();

            // for job controller
            CreateMap<DTOS.JobResponseForListOption, Models.Job>();
            CreateMap<Models.Job, DTOS.JobResponseForListOption>();
        }
    }
}
