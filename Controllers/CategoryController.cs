using _01.EntityLayer;
using _02.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CelilCavus.MVC5.BlogApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly BaseRepository<Category> _repository;

        public CategoryController()
        {
            _repository = new BaseRepository<Category>();
        }

        [Route("")]
        [Route("/")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Category category)
        {
            var NullOrDefault = category?.CategoryName;
            if (NullOrDefault != null)
            {
                _repository.Add(category);
                _repository.SaveChanges();
                return View();
            }
            else
            {
                return View();
            }
        }
        public ActionResult GetPartialViews()
        {
            var getCategoryValue = _repository.All();
            return PartialView("_PartialCategory", getCategoryValue);
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
                return View();
        }
        [HttpPost]
        public ActionResult Update(Category category)
        {
            if (category.Id != 0)
            {
                var findValue = _repository.GetById(category.Id);
                findValue.CategoryName = category.CategoryName;
                _repository.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id != 0)
            {
                var findValue = _repository.GetById(id);
                _repository.Delete(findValue);
                _repository.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index");
        }

    }
}