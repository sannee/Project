using System.Web.Mvc;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Добро пожаловать!";
            return View();
        }

        public ActionResult Fake1()
        {
            return View();
        }

        public ActionResult Fake2()
        {
            return View();
        }

    }
}
