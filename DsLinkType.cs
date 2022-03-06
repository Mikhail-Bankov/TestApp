using System;
using System.Collections.Generic;

namespace TestApp
{
    /// <summary>
    /// Типы связей
    /// </summary>
    public partial class DsLinkType
    {
        public DsLinkType()
        {
            StLinks = new HashSet<StLink>();
        }

        public int InId { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string StName { get; set; }

        public virtual ICollection<StLink> StLinks { get; set; }
    }
}
