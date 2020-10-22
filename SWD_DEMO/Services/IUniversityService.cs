using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public interface IUniversityService : IBaseService<University,string>
    {
        University CreateUniversity(University _entity);
        University UpdateUniversity(University _entity);
        University DeleteUniversity(string _id);

        University GetUniversityByID(string _id);
        IEnumerable<University> GetAllUniversity();


    }
}
