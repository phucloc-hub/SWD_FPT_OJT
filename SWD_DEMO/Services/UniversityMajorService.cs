using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public class UniversityMajorService : BaseService<UniversityMajor, string>, IUniversityMajorService
    {
        public UniversityMajorService(SWDContext context) : base(context)
        {
        }

        public UniversityMajor CreateUniversityMajor(UniversityMajor _entity)
        {
            Add(_entity);
            return _entity;
        }

        public UniversityMajor DeleteUniversityMajor(string _id)
        {
            return Delete(_id);
        }

        public IEnumerable<UniversityMajor> GetAllUniversityMajor()
        {
            return GetAll();
        }

        public UniversityMajor GetUniversityMajorByID(string _id)
        {
            return GetByID(_id);
        }

        public UniversityMajor UpdateUniversityMajor(UniversityMajor _entity)
        {
            return Update(_entity);
        }
    }
}
