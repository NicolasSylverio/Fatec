using System.Web.Mvc;

namespace Fatec.Mvc.Controllers
{
    public class OfflineController : Controller
    {
        // GET: offline
        /// <summary>
        /// Index Offline
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}