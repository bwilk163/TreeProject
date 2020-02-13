using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zadanie_Testowe.Models;

namespace Zadanie_Testowe.Services
{
    public class TreeService : ITreeService
    {
        private readonly Models.DbModel Db;
     
        public TreeService (Zadanie_Testowe.Models.DbModel zadanieTestoweEntities)
        {
            Db = zadanieTestoweEntities;
        }
    
        public IList<TreeElement> GetAll()
        {
            return Db.TreeElements.ToList();
        }
    
        public TreeElement GetById(Guid guid)
        {
            return Db.TreeElements.FirstOrDefault(x => x.Guid == guid);
        }
   
        public IList<TreeElement> GetChildren(Guid? parentId)
        {
            IList<TreeElement> children = Db.TreeElements.Where(x => x.ParentId == parentId).ToList();

            return children;
        }

        public TreeElement AddElement(TreeElement treeElement)
        {
            var addedElement = Db.TreeElements.Add(treeElement);
            Db.SaveChanges();

            return addedElement;
        }
    
        public TreeElement UpdateElement(Guid guid, TreeElement treeElement)
        {
            var element = Db.TreeElements.FirstOrDefault(x => x.Guid == guid);

            element.Value = treeElement.Value;
            element.ParentId = treeElement.ParentId;

            Db.SaveChanges();

            return element;
        }

        public TreeElement ChangeParent(Guid treeElement, Guid newParent)
        {
            var element = Db.TreeElements.FirstOrDefault(x => x.Guid == treeElement);
            element.ParentId = newParent;

            Db.SaveChanges();

            return element;
        }
    }
}