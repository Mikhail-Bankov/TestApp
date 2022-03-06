using System;
using System.Collections.Generic;

namespace TestApp
{
    /// <summary>
    /// Значения атрибутов
    /// </summary>
    public partial class StAttribute
    {
        public int InId { get; set; }
        /// <summary>
        /// Идентификатор версии объекта
        /// </summary>
        public int InIdVersion { get; set; }
        /// <summary>
        /// Идентификатор атрибута
        /// </summary>
        public int InIdAttr { get; set; }
        /// <summary>
        /// Значение атрибута
        /// </summary>
        public string StValue { get; set; }

        public virtual DsAttribute InIdAttrNavigation { get; set; }
        public virtual StVersion InIdVersionNavigation { get; set; }
    }
}
