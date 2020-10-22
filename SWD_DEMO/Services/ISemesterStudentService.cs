using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public interface ISemesterStudentService : IBaseService<SemesterStudent,string>
    {
        SemesterStudent CreateSemesterStudent(SemesterStudent _entity);
        SemesterStudent UpdateSemesterStudent(SemesterStudent _entity);
        SemesterStudent DeleteSemesterStudent(string _id);

        SemesterStudent GetSemesterStudentByID(string _id);
        IEnumerable<SemesterStudent> GetAllSemesterStudent();
    }
}
