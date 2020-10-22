using System;
using System.Collections.Generic;

namespace SWD_DEMO.Models
{
    public partial class Account
    {
        public Account()
        {
            Company = new HashSet<Company>();
            Student = new HashSet<Student>();
            University = new HashSet<University>();
        }

        public string Email { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Company> Company { get; set; }
        public virtual ICollection<Student> Student { get; set; }
        public virtual ICollection<University> University { get; set; }
    }
}
