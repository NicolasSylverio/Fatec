using Fatec.Application.Interface;
using Fatec.Application.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Fatec.Mvc.Controllers
{
    [Authorize]
    public class EmpresasController : Controller
    {
        private readonly IEmpresaAppService _empresaAppService;

        public EmpresasController(IEmpresaAppService empresaAppService)
        {
            _empresaAppService = empresaAppService;
        }

        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            ViewBag.Title = "Empresas";
            var vagas = _empresaAppService.GetAllEmpresaViewModel().AsEnumerable();
            return View(vagas);
        }

        [HttpGet]
        [Route("Cadastro")]
        public ActionResult Cadastro()
        {

            ViewBag.Title = "Cadastro";
            var vagas = _empresaAppService.GetAllEmpresaViewModel().AsEnumerable();
            return View(vagas);
        }

        [HttpGet]
        [Route("Cadastrar")]
        public ActionResult Cadastrar()
        {
            ViewBag.Title = "Cadastrar Empresa";
            //var vagas = _empresaAppService.GetAllVagaEstagioViewModel().AsEnumerable();
            //return View(vagas);
            return View();
        }

        [HttpPost]
        [Route("Cadastrar")]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(EmpresaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.DataHoraCadastro = System.DateTime.Now;
                    _empresaAppService.Cadastrar(model);
                    return RedirectToAction("Cadastro");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        [Route("Alterar/{id}")]
        public ActionResult Alterar(int id)
        {
            EmpresaViewModel empresaViewModel = _empresaAppService.GetViewModel(id);
            return View(empresaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(EmpresaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _empresaAppService.Alterar(model);
                    return RedirectToAction("Cadastro");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _empresaAppService.Remove(id);
            return RedirectToAction("Cadastro");
        }
               
    }
}
