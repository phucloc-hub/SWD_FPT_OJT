using System;
using System.Collections.Generic;

namespace SWD_DEMO.Models
{
    public partial class Connection
    {
        public string CompCode { get; set; }
        public string UniCode { get; set; }
        public long Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Duration { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }

        public virtual Company CompCodeNavigation { get; set; }
        public virtual University UniCodeNavigation { get; set; }
    }
}
