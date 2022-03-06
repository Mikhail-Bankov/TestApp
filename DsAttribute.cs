using System;
using System.Collections.Generic;

namespace TestApp
{
    /// <summary>
    /// Атриубты
    /// </summary>
    public partial class DsAttribute
    {
        public DsAttribute()
        {
            StAttributes = new HashSet<StAttribute>();
        }

        public int InId { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string StName { get; set; }

        public virtual ICollection<StAttribute> StAttributes { get; set; }
    }
}
