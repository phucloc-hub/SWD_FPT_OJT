using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public class FalcutyService : BaseService<Falcuty,string>,IFalcutyService
    {

        public FalcutyService(SWDContext context) : base(context)
        {
        }

        public Falcuty CreateFalcuty(Falcuty _entity)
        {
            Add(_entity);
            return _entity;
        }

        public Falcuty DeleteFalcuty(string _id)
        {
            return Delete(_id);
        }

        public IEnumerable<Falcuty> GetAllFalcuty()
        {
            return GetAll();
        }

        public Falcuty GetFalcutyByID(string _id)
        {
            return GetByID(_id);
        }

        public Falcuty UpdateFalcuty(Falcuty _entity)
        {
            return Update(_entity);
        }
    }
}
