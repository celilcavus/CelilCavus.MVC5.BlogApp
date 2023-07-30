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
    public class AboutController : Controller
    {

        private readonly BaseRepository<About> _repository;

        public AboutController()
        {
            _repository = new BaseRepository<About>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(About about)
        {
            try
            {
                if (about != null)
                {
                    _repository.Add(about);
                    _repository.SaveChanges();
                    return View();
                }
            }
            catch (DbEntityValidationException ex)
            {

                foreach (var item in ex.EntityValidationErrors)
                {
                    foreach (var err in item.ValidationErrors)
                    {
                        var error = err.ErrorMessage;
                    }
                }

            }
            return View();
        }
        public PartialViewResult GetAboutView()
        {
            var getValue = _repository.All();
            return PartialView("_PartialAbout",getValue);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            if (id > 0)
            {
                try
                {
                    var findValue = _repository.GetById(id);
                    return View(findValue);

                }
                catch (Exception ex)
                {

                    return View(ex.Message);
                }
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult Update(About about)
        {
            if (about.Id > 0)
            {
                try
                {
                    var findValue = _repository.GetById(about.Id);
                    findValue.AboutTitle = about.AboutTitle;
                    findValue.AboutImage = about.AboutImage;
                    findValue.AboutContent = about.AboutContent;
                    _repository.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch (DbEntityValidationException ex)
                {

                    foreach (var item in ex.EntityValidationErrors)
                    {
                        foreach (var err in item.ValidationErrors)
                        {
                            var error = err.ErrorMessage;
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
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                try
                {
                    var findValue = _repository.GetById(id);
                    _repository.Delete(findValue);
                    _repository.SaveChanges();
                    return RedirectToAction("Index");
                    

                }
                catch (Exception)
                {

                    return HttpNotFound();
                }
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}