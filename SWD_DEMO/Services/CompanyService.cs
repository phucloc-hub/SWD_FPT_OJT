using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public class CompanyService : BaseService<Company,string>,ICompanyService
    {

        public CompanyService(SWDContext context) : base(context)
        {
        }

       
        public IEnumerable<Company> GetAll()
        {
            return GetAll();
        }
    }
}
