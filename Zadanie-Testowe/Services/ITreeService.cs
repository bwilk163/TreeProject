using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zadanie_Testowe.Models;

namespace Zadanie_Testowe.Services
{
    public interface ITreeService
    {
        IList<TreeElement> GetAll();
        TreeElement GetById(Guid guid);
        IList<TreeElement> GetChildrenByParentId(Guid? parentId);

        TreeElement AddElement(TreeElement treeElement);

        TreeElement UpdateElement(Guid elementGuid, TreeElement treeElement);

        TreeElement ChangeParent(Guid treeElement, Guid newParent);

        TreeElement DeleteElement(Guid guid);
    }
}