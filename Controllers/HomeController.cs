using _01.EntityLayer;
using _02.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CelilCavus.MVC5.BlogApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly BaseRepository<Blog> _repository;
        private readonly BaseRepository<About> _aboutRep;

        public HomeController()
        {
            _repository = new BaseRepository<Blog>();
            _aboutRep = new BaseRepository<About>();
        }
        [AllowAnonymous]
        public ActionResult Home()
        {
            var values = _repository.All() != null ? _repository.All() : default(object);
            return View(values);
        }
        [AllowAnonymous]
        public ActionResult About()
        {
            var values = _aboutRep.All().LastOrDefault() != null ? _aboutRep.All().LastOrDefault() : default(object);
            return View(values);
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View();
        }
    }
}