using System;
using System.Collections.Generic;

namespace TestApp
{
    /// <summary>
    /// Таблица связей между объектами
    /// </summary>
    public partial class StLink
    {
        public int InId { get; set; }
        /// <summary>
        /// Идентификатор родителя
        /// </summary>
        public int InIdParent { get; set; }
        /// <summary>
        /// Идентфиикатор потомка
        /// </summary>
        public int InIdChild { get; set; }
        /// <summary>
        /// Идентификатор типа связи
        /// </summary>
        public int InIdLinkType { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public double? InQuantity { get; set; }

        public virtual StVersion InIdChildNavigation { get; set; }
        public virtual DsLinkType InIdLinkTypeNavigation { get; set; }
        public virtual StVersion InIdParentNavigation { get; set; }
    }
}
