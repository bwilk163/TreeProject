using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Zadanie_Testowe.Models;

namespace Zadanie_Testowe.Services
{
    public class TreeService : ITreeService
    {
        private readonly Models.DbModel Db;

        public TreeService(Zadanie_Testowe.Models.DbModel zadanieTestoweEntities)
        {
            Db = zadanieTestoweEntities;
        }

        public User Login(User u)
        {
            var dbUser = Db.Users.FirstOrDefault(x => x.Username == u.Username);
            if (dbUser != null)
            {
                if (dbUser.Password == u.Password)
                {
                    return dbUser;
                }
            }
            return null;
        }
        public User Register(User u)
        {
            var dbUser = Db.Users.FirstOrDefault(x => x.Username == u.Username);
            if (dbUser == null)
            {
                var newU = Db.Users.Add(u);
                Db.SaveChanges();
                return newU;
            }

            return null;
        }

        public IList<TreeElement> GetAll()
        {
            return Db.TreeElements.ToList();
        }

        public TreeElement GetById(Guid guid)
        {
            return Db.TreeElements.FirstOrDefault(x => x.Guid == guid);
        }

        public IList<TreeElement> GetChildrenByParentId(Guid? parentId)
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

        public  TreeElement DeleteElement(Guid guid)
        {
            var element = Db.TreeElements.FirstOrDefault(x => x.Guid == guid);
            if (element != null)
            {
              element=  Db.TreeElements.Remove(element);
                Db.SaveChanges();
            }
            return element;
        }
    }
}