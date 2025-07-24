using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();
        public ActionResult Index()
        {
            var sosyalmedya = repo.List();
            return View(sosyalmedya);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TblSosyalMedya p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var sosyalmedya = repo.TGetById(id);
            if (sosyalmedya != null)
            {
                repo.TDelete(sosyalmedya);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var sosyalmedya = repo.Find(x => x.ID == id);
            return View(sosyalmedya);

        }

        [HttpPost]
        public ActionResult SayfaGetir(TblSosyalMedya p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            var sosyalmedya = repo.TGetById(p.ID);
            if (sosyalmedya != null)
            {
                sosyalmedya.AD = p.AD;
                sosyalmedya.LINK = p.LINK;
                sosyalmedya.IKON = p.IKON;
                repo.TUpdate(sosyalmedya);
            }
            return RedirectToAction("Index");
        }
    }
}