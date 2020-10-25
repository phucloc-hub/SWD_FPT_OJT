using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SWD_DEMO.DTOS;
using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public class StudentService : BaseService<Student,string>,IStudentService
    {
        SWDContext context;
        DbSet<Student> dbSet;
       
        public StudentService(SWDContext context) : base(context)
        {
            this.context = context;
            this.dbSet = context.Set<Student>();
        }
        public IQueryable<Student> Entity()
        {
            return dbSet;
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

        public Student GetStudentByEmail(string _email)
        {
            var studentinfo = context.Student.Include(a => a.MajorCodeNavigation).Where(s => s.Email == _email).FirstOrDefault();
            return studentinfo;

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
