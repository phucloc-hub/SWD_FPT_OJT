using System;
using System.Collections.Generic;

namespace SWD_DEMO.Models
{
    public partial class Falcuty
    {
        public Falcuty()
        {
            Major = new HashSet<Major>();
            UniFalcuty = new HashSet<UniFalcuty>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string UniCode { get; set; }

        public virtual ICollection<Major> Major { get; set; }
        public virtual ICollection<UniFalcuty> UniFalcuty { get; set; }
    }
}
