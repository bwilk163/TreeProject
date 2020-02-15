using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zadanie_Testowe.Models
{
    public class TreeElementView
    {
        public TreeElementView(TreeElement element, IEnumerable<TreeElement> children)
        {
            Element = element;
            Children = children;
        }

        public TreeElement Element { get; set; }
        public IEnumerable<TreeElement> Children { get; set; }
    }
}