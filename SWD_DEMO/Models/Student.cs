using System;
using System.Collections.Generic;

namespace SWD_DEMO.Models
{
    public partial class Student
    {
        public Student()
        {
            Application = new HashSet<Application>();
            SemesterStudent = new HashSet<SemesterStudent>();
        }

        public string Code { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string PhoneNo { get; set; }
        public string Cv { get; set; }
        public double? Gpa { get; set; }
        public string MajorCode { get; set; }
        public string UniCode { get; set; }

        public string Graduation { get; set; }

        public virtual Account EmailNavigation { get; set; }
        public virtual Major MajorCodeNavigation { get; set; }
        public virtual University UniCodeNavigation { get; set; }
        public virtual ICollection<Application> Application { get; set; }
        public virtual ICollection<SemesterStudent> SemesterStudent { get; set; }
    }
}
