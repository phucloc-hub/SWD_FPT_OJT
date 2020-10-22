using System;
using System.Collections.Generic;

namespace SWD_DEMO.Models
{
    public partial class Semester
    {
        public Semester()
        {
            SemesterStudent = new HashSet<SemesterStudent>();
            UniversitySemester = new HashSet<UniversitySemester>();
        }

        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SemesterStudent> SemesterStudent { get; set; }
        public virtual ICollection<UniversitySemester> UniversitySemester { get; set; }
    }
}
