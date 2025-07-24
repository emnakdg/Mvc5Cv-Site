using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [AllowAnonymous] // Ensure that only authenticated users can access this controller
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();
        public ActionResult Index()
        {
            var adminList = repo.List();
            return View(adminList);
        }

        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminEkle(TblAdmin p)
        {
            if (!ModelState.IsValid)
            {
                return View("AdminEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult AdminSil(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminGetir(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult AdminGetir(TblAdmin p)
        {
            if (!ModelState.IsValid)
            {
                return View("AdminGetir");
            }
            TblAdmin t = repo.Find(x => x.ID == p.ID);
            t.KULLANICIADI = p.KULLANICIADI;
            t.SIFRE = p.SIFRE;
            repo.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}