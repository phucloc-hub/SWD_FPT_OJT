﻿using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public interface ICompanyService : IBaseService<Company,string>
    {
       
        IEnumerable<Company> GetAll();


    }
}
