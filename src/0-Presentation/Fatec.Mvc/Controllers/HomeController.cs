using System.Web.Mvc;

namespace Fatec.Mvc.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("Home")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("About")]
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        [Route("Contact")]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        [Route("Privacy")]
        public ActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        [Route("Professores")]
        public ActionResult Professores()
        {
            return View();
        }

        [HttpGet]
        [Route("AcessoNegado")]
        public ActionResult AcessoNegado()
        {
            return View();
        }
    }
}