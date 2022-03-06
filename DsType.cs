using System;
using System.Collections.Generic;

namespace TestApp
{
    /// <summary>
    /// Типы
    /// </summary>
    public partial class DsType
    {
        public DsType()
        {
            StMains = new HashSet<StMain>();
        }

        public int InId { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string StName { get; set; }
        /// <summary>
        /// Является документом
        /// </summary>
        public byte? BiDocument { get; set; }

        public virtual ICollection<StMain> StMains { get; set; }
    }
}
