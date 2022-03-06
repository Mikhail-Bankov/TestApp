using System;
using System.Collections.Generic;

namespace TestApp
{
    /// <summary>
    /// Версии объектов
    /// </summary>
    public partial class StVersion
    {
        public StVersion()
        {
            StAttributes = new HashSet<StAttribute>();
            StLinkInIdChildNavigations = new HashSet<StLink>();
            StLinkInIdParentNavigations = new HashSet<StLink>();
        }

        public int InId { get; set; }
        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public int InIdMain { get; set; }
        /// <summary>
        /// Идентификатор состояния
        /// </summary>
        public int InIdState { get; set; }
        /// <summary>
        /// Версия
        /// </summary>
        public string StNumber { get; set; }

        public virtual StMain InIdMainNavigation { get; set; }
        public virtual DsState InIdStateNavigation { get; set; }
        public virtual ICollection<StAttribute> StAttributes { get; set; }
        public virtual ICollection<StLink> StLinkInIdChildNavigations { get; set; }
        public virtual ICollection<StLink> StLinkInIdParentNavigations { get; set; }
    }
}
