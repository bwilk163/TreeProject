using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            return Json(_treeService.GetAll(), JsonRequestBehavior.AllowGet); ;
        }

    }
}