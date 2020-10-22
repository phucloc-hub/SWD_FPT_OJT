using System;
using System.Collections.Generic;

namespace SWD_DEMO.Models
{
    public partial class Application
    {
        public int Id { get; set; }
        public string StuCode { get; set; }
        public int JobId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public DateTime? AcceptDate { get; set; }

        public virtual Job Job { get; set; }
        public virtual Student StuCodeNavigation { get; set; }
    }
}
