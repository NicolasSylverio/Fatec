using System.Web.Mvc;
using Fatec.Mvc.App_Start;

namespace Fatec.Mvc.Controllers
{
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
        [CustomAuthorize(Roles = "administrador, usuario")]
        public ActionResult Professores()
        {
            return View();
        }

        [HttpGet]
        [Route("AcessoNegado")]
        [AllowAnonymous]
        public ActionResult AcessoNegado()
        {
            return View();
        }
    }
}