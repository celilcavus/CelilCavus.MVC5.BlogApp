using _01.EntityLayer;
using _02.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CelilCavus.MVC5.BlogApp.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        private readonly BaseRepository<Admin> _repository;

        public AdminController()
        {
            _repository = new BaseRepository<Admin>();
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (HttpContext.Request.IsAuthenticated)
            {
                return RedirectToAction(nameof(SignOut));
            }
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var FindUser = _repository.All().FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            FormsAuthentication.SetAuthCookie(FindUser.UserName, false);
            return RedirectToAction("Index","About");
        }

        [HttpGet]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Admin");
        }
    }
}