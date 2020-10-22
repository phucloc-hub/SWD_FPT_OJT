using System;
using System.Collections.Generic;

namespace SWD_DEMO.Models
{
    public partial class University
    {
        public University()
        {
            Connection = new HashSet<Connection>();
            Student = new HashSet<Student>();
            UniFalcuty = new HashSet<UniFalcuty>();
            UniversityMajor = new HashSet<UniversityMajor>();
            UniversitySemester = new HashSet<UniversitySemester>();
        }

        public string Code { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public virtual Account EmailNavigation { get; set; }
        public virtual ICollection<Connection> Connection { get; set; }
        public virtual ICollection<Student> Student { get; set; }
        public virtual ICollection<UniFalcuty> UniFalcuty { get; set; }
        public virtual ICollection<UniversityMajor> UniversityMajor { get; set; }
        public virtual ICollection<UniversitySemester> UniversitySemester { get; set; }
    }
}
