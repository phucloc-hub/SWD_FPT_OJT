using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public class UniversityService : BaseService<University, string>, IUniversityService
    {
        public UniversityService(SWDContext context) : base(context)
        {
        }

        public University CreateUniversity(University _entity)
        {
            Add(_entity);
            return _entity;
        }

        public University DeleteUniversity(string _id)
        {
            return Delete(_id);
        }

        public IEnumerable<University> GetAllUniversity()
        {
            return GetAll();
        }

        public University GetUniversityByID(string _id)
        {
            return GetByID(_id);
        }

        public University UpdateUniversity(University _entity)
        {
            return Update(_entity);
        }
    }
}
