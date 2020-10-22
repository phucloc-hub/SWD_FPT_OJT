using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public interface IFalcutyService : IBaseService<Falcuty,string>
    {
        Falcuty CreateFalcuty(Falcuty _entity);
        Falcuty UpdateFalcuty(Falcuty _entity);
        Falcuty DeleteFalcuty(string _id);

        Falcuty GetFalcutyByID(string _id);
        IEnumerable<Falcuty> GetAllFalcuty();
    }
}
