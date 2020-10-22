using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public class UniversitySemesterService : BaseService<UniversitySemester, string>, IUniversitySemesterService
    {
        public UniversitySemesterService(SWDContext context) : base(context)
        {
        }

        public UniversitySemester CreateUniversitySemester(UniversitySemester _entity)
        {
            Add(_entity);
            return _entity;
        }

        public UniversitySemester DeleteUniversitySemester(string _id)
        {
            return Delete(_id);
        }

        public IEnumerable<UniversitySemester> GetAllUniversitySemester()
        {
            return GetAll();
        }

        public UniversitySemester GetUniversitySemesterByID(string _id)
        {
            return GetByID(_id);
        }

        public UniversitySemester UpdateUniversitySemester(UniversitySemester _entity)
        {
            return Update(_entity);
        }
    }
}
