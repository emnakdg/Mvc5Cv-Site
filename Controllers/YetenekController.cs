using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        GenericRepository<TblYeteneklerim> repo = new GenericRepository<TblYeteneklerim>();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }

        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniYetenek(TblYeteneklerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniYetenek");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            return View(yetenek);
        }

        [HttpPost]
        public ActionResult YetenekGetir(TblYeteneklerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("YetenekGetir");
            }
            var yetenek = repo.Find(x => x.ID == p.ID);
            yetenek.YETENEK = p.YETENEK;
            yetenek.ORAN = p.ORAN;
            repo.TUpdate(yetenek);
            return RedirectToAction("Index");
        }
    }
}