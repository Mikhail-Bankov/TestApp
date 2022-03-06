using System;
using System.Collections.Generic;

namespace TestApp
{
    /// <summary>
    /// Объекты
    /// </summary>
    public partial class StMain
    {
        public StMain()
        {
            StVersions = new HashSet<StVersion>();
        }

        public int InId { get; set; }
        /// <summary>
        /// Идентификатор типа
        /// </summary>
        public int InIdType { get; set; }
        /// <summary>
        /// Обозначение
        /// </summary>
        public string StName { get; set; }

        public virtual DsType InIdTypeNavigation { get; set; }
        public virtual ICollection<StVersion> StVersions { get; set; }
    }
}
