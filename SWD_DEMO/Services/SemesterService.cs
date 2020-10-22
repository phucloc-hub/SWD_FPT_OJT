using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public class SemesterService : BaseService<Semester,string>,ISemesterService
    {

        public SemesterService(SWDContext context) : base(context)
        {
        }

        public Semester CreateSemester(Semester _entity)
        {
            Add(_entity);
            return _entity;
        }

        public Semester DeleteSemester(string _id)
        {
            return Delete(_id);
        }

        public IEnumerable<Semester> GetAllSemester()
        {
            return GetAll();
        }

        public Semester GetSemesterByID(string _id)
        {
            return GetByID(_id);
        }

        public Semester UpdateSemester(Semester _entity)
        {
            return Update(_entity);
        }
    }
}
