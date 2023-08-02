using _01.EntityLayer;
using _02.DataAccessLayer.Repository;
using System.Web.Mvc;

namespace CelilCavus.MVC5.BlogApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly BaseRepository<Contact> _repository;

        public ContactController()
        {
            _repository = new BaseRepository<Contact>();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(Contact contact)
        {
            if (contact != null)
            {
                _repository.Add(contact);
                _repository.SaveChanges();
                return RedirectToAction("Home", "Home");
            }
            else
                return RedirectToAction("Home", "Home");
        }
    }
}