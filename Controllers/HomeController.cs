using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            ViewBag.Message = "This is a test page.";
            return View();
        }

        public ActionResult Test2()
        {
            ViewBag.Message = "An error occurred.";
            return View();
        }
    }
}