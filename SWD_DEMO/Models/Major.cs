using System;
using System.Collections.Generic;

namespace SWD_DEMO.Models
{
    public partial class Major
    {
        public Major()
        {
            Job = new HashSet<Job>();
            Student = new HashSet<Student>();
            UniversityMajor = new HashSet<UniversityMajor>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string FalcutyCode { get; set; }

        public virtual Falcuty FalcutyCodeNavigation { get; set; }
        public virtual MajorType MajorType { get; set; }
        public virtual ICollection<Job> Job { get; set; }
        public virtual ICollection<Student> Student { get; set; }
        public virtual ICollection<UniversityMajor> UniversityMajor { get; set; }
    }
}
