using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public interface ISemesterService : IBaseService<Semester,string>
    {
        Semester CreateSemester(Semester _entity);
        Semester UpdateSemester(Semester _entity);
        Semester DeleteSemester(string _id);

        Semester GetSemesterByID(string _id);
        IEnumerable<Semester> GetAllSemester();
    }
}
