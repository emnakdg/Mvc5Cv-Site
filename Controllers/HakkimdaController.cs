using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>();

        [HttpGet]
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpPost]
        public ActionResult Index(TblHakkimda p)
        {
            var degerler = repo.Find(x => x.ID == 1);
            if (degerler != null)
            {
                degerler.AD = p.AD;
                degerler.SOYAD = p.SOYAD;
                degerler.ADRES = p.ADRES;
                degerler.TELEFON = p.TELEFON;
                degerler.MAIL = p.MAIL;
                degerler.ACIKLAMA = p.ACIKLAMA;
                degerler.RESIM = p.RESIM;
                repo.TUpdate(degerler);
            }
            return RedirectToAction("Index");
        }


    }
}