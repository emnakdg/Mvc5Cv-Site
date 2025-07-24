using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        GenericRepository<Tbliletisim> iletisimRepository = new GenericRepository<Tbliletisim>();
        public ActionResult Index()
        {
            var iletisim = iletisimRepository.List();
            return View(iletisim);
        }
    }
}