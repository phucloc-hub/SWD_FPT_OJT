using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public class SemesterStudentService : BaseService<SemesterStudent,string>,ISemesterStudentService
    {

        public SemesterStudentService(SWDContext context) : base(context)
        {
        }

        public SemesterStudent CreateSemesterStudent(SemesterStudent _entity)
        {
            Add(_entity);
            return _entity;
        }

        public SemesterStudent DeleteSemesterStudent(string _id)
        {
            return Delete(_id);
        }

        public IEnumerable<SemesterStudent> GetAllSemesterStudent()
        {
            return GetAll();
        }

        public SemesterStudent GetSemesterStudentByID(string _id)
        {
            return GetByID(_id);
        }

        public SemesterStudent UpdateSemesterStudent(SemesterStudent _entity)
        {
            return Update(_entity);
        }
    }
}
