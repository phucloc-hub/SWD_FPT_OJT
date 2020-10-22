using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public interface IUniversitySemesterService : IBaseService<UniversitySemester,string>
    {
        UniversitySemester CreateUniversitySemester(UniversitySemester _entity);
        UniversitySemester UpdateUniversitySemester(UniversitySemester _entity);
        UniversitySemester DeleteUniversitySemester(string _id);

        UniversitySemester GetUniversitySemesterByID(string _id);
        IEnumerable<UniversitySemester> GetAllUniversitySemester();


    }
}
