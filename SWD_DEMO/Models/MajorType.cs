using System;
using System.Collections.Generic;

namespace SWD_DEMO.Models
{
    public partial class MajorType
    {
        public string MajorCode { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public virtual Major MajorCodeNavigation { get; set; }
    }
}
