using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();
        public ActionResult Index()
        {
            var egitimler = repo.List();
            return View(egitimler);
        }

        [HttpGet]
        public ActionResult YeniEgitim()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniEgitim(TblEgitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniEgitim");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }

        [HttpPost]
        public ActionResult EgitimGetir(TblEgitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimGetir");
            }
            var egitim = repo.Find(x => x.ID == p.ID);
            egitim.BASLIK = p.BASLIK;
            egitim.ALTBASLIK1 = p.ALTBASLIK1;
            egitim.ALTBASLIK2 = p.ALTBASLIK2;
            egitim.GNO = p.GNO;
            egitim.TARIH = p.TARIH;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }
    }
}