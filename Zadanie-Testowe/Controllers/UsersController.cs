using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Zadanie_Testowe.Models;
using Zadanie_Testowe.Services;

namespace Zadanie_Testowe.Controllers
{
    public class UsersController : Controller
    {

        private readonly ITreeService _treeService;
        public UsersController(ITreeService treeService)
        {
            _treeService = treeService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                if (_treeService.Login(user) != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return Redirect("/Home");
                }
                else
                    return View();
            }
            else
                return View();
        }


        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (_treeService.Register(user) != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return Redirect("/Home");
                }
                return View();
            }

            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home");
        }
    }
}