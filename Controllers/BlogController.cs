using _01.EntityLayer;
using _02.DataAccessLayer.Repository;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Web.Mvc;

namespace CelilCavus.MVC5.BlogApp.Controllers
{
    public class BlogController : Controller
    {

        private readonly BaseRepository<Blog> _repository;

        public BlogController()
        {
            _repository = new BaseRepository<Blog>();
        }
        private void GetCategory()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var item in _repository.All())
            {
                selectListItems.Add(new SelectListItem
                {
                    Text = item.Category.CategoryName,
                    Value = item.Category.Id.ToString()
                });
            }
            ViewBag.Category = selectListItems;
        }
        private void GetAuthor()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var item in _repository.All())
            {
                selectListItems.Add(new SelectListItem
                {
                    Text = item.Author.AuthorName,
                    Value = item.Author.Id.ToString()
                });
            }
            ViewBag.Author = selectListItems;
        }
        [HttpGet]
        public ActionResult Index()
        {
            GetCategory();
            GetAuthor();
            return View();
        }

        [HttpPost]
        public ActionResult Index(Blog blog)
        {
            try
            {
                if (blog != null)
                {
                    _repository.Add(blog);
                    _repository.SaveChanges();
                    return View();
                }
            }
            catch (DbEntityValidationException ex)
            {

                foreach (var item in ex.EntityValidationErrors)
                {
                    foreach (var valid in item.ValidationErrors)
                    {
                        var ErrorMessage = valid.ErrorMessage;
                    }
                }
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id.HasValue && id > 0)
            {
                var FindVal = _repository.GetById(id.Value);
                if (FindVal != null)
                {
                    return View(FindVal);
                }
                else
                    return HttpNotFound();
            }
            else
                return View();
        }
        public PartialViewResult GetBlogView()
        {
            var Values = _repository.All();
            return PartialView("_PartialBlog", Values);
        }

        [HttpGet]
        public ActionResult Update(int id)

        {
            if (id >= 1)
            {
                GetCategory();
                GetAuthor();
                var FindVal = _repository.GetById(id);
                return View(FindVal);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Update(Blog blog)
        {
            try
            {
                if (blog != null)
                {
                    var FindVal = _repository.GetById(blog.Id);
                    FindVal.BlogImage = blog.BlogImage;
                    FindVal.BlogTitle = blog.BlogTitle;
                    FindVal.BlogContent = blog.BlogContent;
                    FindVal.BlogDate = blog.BlogDate;
                    FindVal.CategoryId = blog.CategoryId;
                    FindVal.AuthorId = blog.AuthorId;
                    _repository.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return HttpNotFound();
                }
            }
            catch (DbEntityValidationException ex)
            {

                foreach (var item in ex.EntityValidationErrors)
                {
                    foreach (var valid in item.ValidationErrors)
                    {
                        var ErrorMessage = valid.ErrorMessage;
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)

        {
            if (id >= 1)
            {
                var FindVal = _repository.GetById(id);
                _repository.Delete(FindVal);
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