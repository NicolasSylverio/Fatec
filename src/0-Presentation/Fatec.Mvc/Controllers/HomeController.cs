using System.Web.Mvc;

namespace Fatec.Mvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [Route("Home")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [Route("About")]
        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }

        [Route("Contact")]
        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View();
        }

        [Route("Privacy")]
        [AllowAnonymous]
        public ActionResult Privacy()
        {
            return View();
        }
    }
}