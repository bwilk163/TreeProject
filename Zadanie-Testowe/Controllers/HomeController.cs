using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Zadanie_Testowe.Models;
using Zadanie_Testowe.Services;

namespace Zadanie_Testowe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITreeService _treeService;

        public HomeController (ITreeService treeService)
        {
            _treeService = treeService;
        }
        public ActionResult Index()
        {
            return View(_treeService.GetAll());
            //return Json(_treeService.GetAll(), JsonRequestBehavior.AllowGet); ;
        }

        public JsonResult GetAll()
        {
            return Json(_treeService.GetAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetRoots()
        {
            return Json(_treeService.GetChildren(null), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetById(Guid guid)
        {
            return Json(_treeService.GetById(guid), JsonRequestBehavior.AllowGet);
        }
        public IList<TreeElement> GetChildren(Guid parentId)
        {
            return _treeService.GetChildren(parentId);
        }

        public TreeElement AddElement([FromBody] TreeElement treeElement)
        {
            return _treeService.AddElement(treeElement);
        }

        public TreeElement UpdateElement(Guid elementGuid, TreeElement treeElement)
        {
            return _treeService.UpdateElement(elementGuid, treeElement);
        }

        public TreeElement ChangeParent(Guid treeElement, Guid newParent)
        {
            return _treeService.ChangeParent(treeElement, newParent);
        }
    }
}