using Fatec.Application.Interface;
using System.Linq;
using System.Web.Mvc;

namespace Fatec.Mvc.Controllers
{
    [Authorize]
    public class VagasEstagioController : Controller
    {
        private readonly IVagaEstagioAppService _vagaEstagioAppService;

        public VagasEstagioController(IVagaEstagioAppService vagaEstagioAppService)
        {
            _vagaEstagioAppService = vagaEstagioAppService;
        }

        [HttpGet]
        [Route("Index")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Title = "Vagas de Estágio";
            var vagas = _vagaEstagioAppService.GetAll().AsEnumerable();
            return View(vagas);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Detalhes/{id}")]
        public ActionResult Detalhes(int id)
        {
            return View();
        }

        [HttpGet]
        [Route("Cadastro")]
        public ActionResult Cadastro()
        {

            ViewBag.Title = "Cadastro";
            var vagas = _vagaEstagioAppService.GetAll().AsEnumerable();
            return View(vagas);
        }

        [HttpGet]
        [Route("Cadastrar")]
        public ActionResult Cadastrar()
        {
            ViewBag.Title = "Cadastrar Vaga de Estágio";
            var vagas = _vagaEstagioAppService.GetAll().AsEnumerable();
            return View(vagas);
        }

        [HttpGet]
        [Route("Edit")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
