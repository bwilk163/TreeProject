using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public HomeController(ITreeService treeService)
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
        public PartialViewResult GetRootsPartial()
        {
            var result = _treeService.GetChildrenByParentId(null);
            return PartialView("_TreeElements", new TreeElementView(null, result));
        }
        //public JsonResult GetRoots()
        //{
        //    return Json(_treeService.GetChildrenByParentId(null), JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult GetById(Guid guid)
        //{
        //    return Json(_treeService.GetById(guid), JsonRequestBehavior.AllowGet);
        //}
        public PartialViewResult GetChildrenByParentId(Guid parentId)
        {
            var result = _treeService.GetChildrenByParentId(parentId);
            var element = _treeService.GetById(parentId);
            return PartialView("_TreeElements", new TreeElementView(element, result));
        }

        public PartialViewResult AddElement([FromBody] TreeElement treeElement)
        {
            if (ModelState.IsValid)
            {
                treeElement.Guid = Guid.NewGuid();
                var newElement = _treeService.AddElement(treeElement);
                return PartialView("_TreeElement", newElement);
            }
            return null;
        }

        public JsonResult UpdateElement(Guid elementGuid, TreeElement treeElement)
        {
            if (ModelState.IsValid)
                return Json(_treeService.UpdateElement(elementGuid, treeElement), JsonRequestBehavior.AllowGet);
            return null;
        }

        public TreeElement ChangeParent(Guid treeElement, Guid newParent)
        {
            return _treeService.ChangeParent(treeElement, newParent);
        }
        public JsonResult DeleteElement(Guid treeElementGuid)
        {
            var result = _treeService.DeleteElement(treeElementGuid);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}