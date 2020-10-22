using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public interface IUniFalcutyService : IBaseService<UniFalcuty,string>
    {
        UniFalcuty CreateUniFalcuty(UniFalcuty _entity);
        UniFalcuty UpdateUniFalcuty(UniFalcuty _entity);
        UniFalcuty DeleteUniFalcuty(string _id);

        UniFalcuty GetUniFalcutyByID(string _id);
        IEnumerable<UniFalcuty> GetAllUniFalcuty();
    }
}
