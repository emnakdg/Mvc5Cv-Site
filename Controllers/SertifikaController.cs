using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<TblSertifikalarım> repo = new GenericRepository<TblSertifikalarım>();
        public ActionResult Index()
        {
            var sertifikalar = repo.List();
            return View(sertifikalar);
        }

        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifikalarım p)
        {
            if (!ModelState.IsValid)
            {
                return View("SertifikaEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            return View(sertifika);
        }

        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifikalarım p)
        {
            if (!ModelState.IsValid)
            {
                return View("SertifikaGetir");
            }
            var sertifika = repo.Find(x => x.ID == p.ID);
            sertifika.TARIH = p.TARIH;
            sertifika.ACIKLAMA = p.ACIKLAMA;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }
    }
}