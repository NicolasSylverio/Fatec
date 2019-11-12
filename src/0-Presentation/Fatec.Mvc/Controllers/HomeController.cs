using System.Web.Mvc;

namespace Fatec.Mvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("Home")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("About")]
        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        [Route("Contact")]
        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        [Route("Privacy")]
        [AllowAnonymous]
        public ActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [Route("Professores")]
        public ActionResult Professores()
        {
            return View();
        }
    }
}