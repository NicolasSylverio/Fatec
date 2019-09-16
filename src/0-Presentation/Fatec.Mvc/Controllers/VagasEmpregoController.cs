using Fatec.Application.Interface;
using System.Web.Mvc;

namespace Fatec.Mvc.Controllers
{
    public class VagasEmpregoController : Controller
    {
        private readonly IVagaEmpregoAppService _vagaEmpregoAppService;

        public VagasEmpregoController(IVagaEmpregoAppService vagaEmpregoAppService)
        {
            _vagaEmpregoAppService = vagaEmpregoAppService;
        }

        // GET: VagasEmprego
        public ActionResult Index()
        {
            ViewBag.Title = "Vagas de Emprego";
            var vagas = _vagaEmpregoAppService.GetAll();
            return View(vagas);
        }
    }
}