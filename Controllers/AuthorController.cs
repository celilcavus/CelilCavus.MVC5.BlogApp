using _01.EntityLayer;
using _02.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
            try
            {
                if (author != null)
                {
                    _repository.Add(author);
                    _repository.SaveChanges();
                    return View();
                }
            }
            catch (DbEntityValidationException ee)
            {
                foreach (var error in ee.EntityValidationErrors)
                {
                    foreach (var thisError in error.ValidationErrors)
                    {
                        var errorMessage = thisError.ErrorMessage;
                    }
                }
            }
            return View();
        }

        public PartialViewResult GetAuthorView()
        {
            var GetAuthors = _repository.All();
            return PartialView("_PartialAuthor", GetAuthors);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            if (id != 0)
            {
                var findValue = _repository.GetById(id);
                return View(findValue);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Update(Author author)
        {
            if (author != null)
            {
                try
                {
                    var findValue = _repository.GetById(author.Id);
                    findValue.AuthorName = author.AuthorName;
                    findValue.AuthorImage = author.AuthorImage;
                    findValue.AuthorAbout = author.AuthorAbout;
                    _repository.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbEntityValidationException ex)
                {

                    foreach (var error in ex.EntityValidationErrors)
                    {
                        foreach (var item in error.ValidationErrors)
                        {
                            var errorMessage = item.ErrorMessage;
                        }
                    }
                }
                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult Delete(int id)
        {
            if (id >= 0)
            {
                var findValue = _repository.GetById(id);
                _repository.Delete(findValue);
                _repository.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}