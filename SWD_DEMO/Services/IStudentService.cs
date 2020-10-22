using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public interface IStudentService : IBaseService<Student,string>
    {
        Student CreateStudent(Student _entity);
        Student UpdateStudent(Student _entity);
        Student DeleteStudent(string _id);

        Student GetStudentByID(string _id);
        IEnumerable<Student> GetAllStudent();
    }
}
