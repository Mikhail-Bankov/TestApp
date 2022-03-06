using System;
using System.Collections.Generic;

namespace TestApp
{
    /// <summary>
    /// Состояния
    /// </summary>
    public partial class DsState
    {
        public DsState()
        {
            StVersions = new HashSet<StVersion>();
        }

        public int InId { get; set; }
        public string StName { get; set; }

        public virtual ICollection<StVersion> StVersions { get; set; }
    }
}
