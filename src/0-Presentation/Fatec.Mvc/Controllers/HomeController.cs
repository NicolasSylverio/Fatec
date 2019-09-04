using System.Web.Mvc;

namespace Fatec.Mvc.Controllers
{
    public class HomeController : Controller
    {
        [Route("Home")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }
    }
}