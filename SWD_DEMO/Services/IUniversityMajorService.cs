using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public interface IUniversityMajorService : IBaseService<UniversityMajor,string>
    {
        UniversityMajor CreateUniversityMajor(UniversityMajor _entity);
        UniversityMajor UpdateUniversityMajor(UniversityMajor _entity);
        UniversityMajor DeleteUniversityMajor(string _id);

        UniversityMajor GetUniversityMajorByID(string _id);
        IEnumerable<UniversityMajor> GetAllUniversityMajor();


    }
}
