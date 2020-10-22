using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public class StudentService : BaseService<Student,string>,IStudentService
    {

        public StudentService(SWDContext context) : base(context)
        {
        }

        public Student CreateStudent(Student _entity)
        {
            Add(_entity);
            return _entity;
        }

        public Student DeleteStudent(string _id)
        {
            return Delete(_id);
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return GetAll();
        }

        public Student GetStudentByID(string _id)
        {
            return GetByID(_id);
        }

        public Student UpdateStudent(Student _entity)
        {
            return Update(_entity);
        }
    }
}
