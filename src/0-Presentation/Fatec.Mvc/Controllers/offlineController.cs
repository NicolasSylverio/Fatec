using System.Web.Mvc;

namespace Fatec.Mvc.Controllers
{
    [AllowAnonymous]
    public class OfflineController : Controller
    {
        /// <summary>
        /// Index Offline
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}