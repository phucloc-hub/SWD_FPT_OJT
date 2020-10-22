using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public class MajorService : BaseService<Major,string>,IMajorService
    {

        public MajorService(SWDContext context) : base(context)
        {
        }

        public Major CreateMajor(Major _entity)
        {
            Add(_entity);
            return _entity;
        }

        public Major DeleteMajor(string _id)
        {
            return Delete(_id);
        }

        public IEnumerable<Major> GetAllMajor()
        {
            return GetAll();
        }

        public Major GetMajorByID(string _id)
        {
            return GetByID(_id);
        }

        public Major UpdateMajor(Major _entity)
        {
            return Update(_entity);
        }
    }
}
