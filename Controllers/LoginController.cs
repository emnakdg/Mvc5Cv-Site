using MvcCv.Models.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    [AllowAnonymous] // Allow anonymous access to the login page
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {
            DbCvEntities db = new DbCvEntities();
            var adminUser = db.TblAdmin.FirstOrDefault(x => x.KULLANICIADI == p.KULLANICIADI && x.SIFRE == p.SIFRE);
            if (adminUser != null)
            {
                FormsAuthentication.SetAuthCookie(adminUser.KULLANICIADI, false);
                Session["KULLANICIADI"] = adminUser.KULLANICIADI.ToString();
                return RedirectToAction("Index", "Hakkimda");
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre yanlış.";
                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}