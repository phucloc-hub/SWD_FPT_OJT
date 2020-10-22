using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public class MajorTypeService : BaseService<MajorType,string>,IMajorTypeService
    {

        public MajorTypeService(SWDContext context) : base(context)
        {
        }

        public MajorType CreateMajorType(MajorType _entity)
        {
            Add(_entity);
            return _entity;
        }

        public MajorType DeleteMajorType(string _id)
        {
            return Delete(_id);
        }

        public IEnumerable<MajorType> GetAllMajorType()
        {
            return GetAll();
        }

        public MajorType GetMajorTypeByID(string _id)
        {
            return GetByID(_id);
        }

        public MajorType UpdateMajorType(MajorType _entity)
        {
            return Update(_entity);
        }
    }
}
