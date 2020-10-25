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
            CreateMap<DTOS.StudentRespInfo, Models.Student>();
            CreateMap<Models.Student,DTOS.StudentRespInfo>();
        }
    }
}
