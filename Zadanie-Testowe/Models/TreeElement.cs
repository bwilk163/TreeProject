using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zadanie_Testowe.Models
{
    public class TreeElement
    {
        public Guid Guid { get; set; }
        public string Value { get; set; }
        public Guid? ParentId { get; set; }
    }
}