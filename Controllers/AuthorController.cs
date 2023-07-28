using _01.EntityLayer;
using _02.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CelilCavus.MVC5.BlogApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly BaseRepository<Author> _repository;

        public AuthorController()
        {
            _repository = new BaseRepository<Author>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Author author)
        {
            if (author != null)
            {
                _repository.Add(author);
                _repository.SaveChanges();
                return View();
            }
            else
            {
                return View();
            }
        }

        public PartialViewResult GetAuthorView()
        {
            var GetAuthors = _repository.All();
            return PartialView("_PartialAuthor", GetAuthors);
        }
    }
}