using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public interface IMajorTypeService : IBaseService<MajorType,string>
    {
        MajorType CreateMajorType(MajorType _entity);
        MajorType UpdateMajorType(MajorType _entity);
        MajorType DeleteMajorType(string _id);

        MajorType GetMajorTypeByID(string _id);
        IEnumerable<MajorType> GetAllMajorType();
    }
}
