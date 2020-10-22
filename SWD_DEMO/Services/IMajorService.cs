using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public interface IMajorService : IBaseService<Major,string>
    {
        Major CreateMajor(Major _entity);
        Major UpdateMajor(Major _entity);
        Major DeleteMajor(string _id);

        Major GetMajorByID(string _id);
        IEnumerable<Major> GetAllMajor();
    }
}
