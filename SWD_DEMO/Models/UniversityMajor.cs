using System;
using System.Collections.Generic;

namespace SWD_DEMO.Models
{
    public partial class UniversityMajor
    {
        public string UniCode { get; set; }
        public string MajorCode { get; set; }

        public virtual Major MajorCodeNavigation { get; set; }
        public virtual University UniCodeNavigation { get; set; }
    }
}
