using System;
using System.Collections.Generic;
using System.Numerics;

namespace SWD_DEMO.Models
{
    public partial class Job
    {
        public Job()
        {
            Application = new HashSet<Application>();
        }

        public int Id { get; set; }
        public string CompCode { get; set; }
        public string MajorCode { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Benefit { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; }

        public virtual Company CompCodeNavigation { get; set; }
        public virtual Major MajorCodeNavigation { get; set; }
        public virtual ICollection<Application> Application { get; set; }
    }
}
