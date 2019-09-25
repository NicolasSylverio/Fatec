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

        [Route("About")]
        public ActionResult About()
        {
            return View();
        }

        [Route("Contact")]
        public ActionResult Contact()
        {
            return View();
        }

        [Route("Privacy")]
        public ActionResult Privacy()
        {
            return View();
        }
    }
}