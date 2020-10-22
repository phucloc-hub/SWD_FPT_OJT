using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public class UniFalcutyService : BaseService<UniFalcuty,string>,IUniFalcutyService
    {

        public UniFalcutyService(SWDContext context) : base(context)
        {
        }

        public UniFalcuty CreateUniFalcuty(UniFalcuty _entity)
        {
            Add(_entity);
            return _entity;
        }

        public UniFalcuty DeleteUniFalcuty(string _id)
        {
            return Delete(_id);
        }

        public IEnumerable<UniFalcuty> GetAllUniFalcuty()
        {
            return GetAll();
        }

        public UniFalcuty GetUniFalcutyByID(string _id)
        {
            return GetByID(_id);
        }

        public UniFalcuty UpdateUniFalcuty(UniFalcuty _entity)
        {
            return Update(_entity);
        }
    }
}
