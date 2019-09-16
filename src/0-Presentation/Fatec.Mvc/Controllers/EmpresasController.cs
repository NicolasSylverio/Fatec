using Fatec.Application.Interface;
using Fatec.Application.ViewModels;
using Fatec.Domain.Models.Empresas;
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

        // GET: Estagio
        public ActionResult Index()
        {
            ViewBag.Title = "Empresas";
            var vagas = _empresaAppService.GetAllEmpresaViewModel().AsEnumerable();
            return View(vagas);
        }

        public ActionResult Cadastro()
        {

            ViewBag.Title = "Cadastro";
            var vagas = _empresaAppService.GetAllEmpresaViewModel().AsEnumerable();
            return View(vagas);
        }

        public ActionResult Cadastrar()
        {
            ViewBag.Title = "Cadastrar Empresa";
            //var vagas = _empresaAppService.GetAllVagaEstagioViewModel().AsEnumerable();
            //return View(vagas);
            return View();
        }

        [HttpPost]
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
               
        // GET: Estagio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Estagio/Edit/5
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

        // GET: Estagio/Delete/5
        public ActionResult Delete(int id)
        {
            Empresa empresa = _empresaAppService.GetById(id);
            _empresaAppService.Remove(empresa);
            return RedirectToAction("Cadastro");
        }
               
    }
}
