using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zadanie_Testowe.Models
{
    public class TreeElement
    {
        public Guid Guid { get; set; }
        public string Value { get; set; }
        public Guid? ParentId { get; set; }

        [NotMapped]
        public IList<TreeElement> Children { get; set; }
    }
}