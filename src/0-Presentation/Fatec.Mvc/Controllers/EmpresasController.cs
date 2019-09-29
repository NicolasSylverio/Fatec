using Fatec.Application.Interface;
using Fatec.Application.ViewModels;
using Fatec.CrossCutting.Models.PaginacaoHelper;
using PagedList;
using System;
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
        public ActionResult Index(PaginacaoViewModel<EmpresaViewModel> view)
        {
            try
            {
                var result = _empresaAppService.GetAll(new Paginacao(view.Pagina, view.TotalPorPagina));

                ViewBag.PagedList = new StaticPagedList<EmpresaViewModel>
                (
                    result.Resultado,
                    result.Pagina,
                    result.TotalPorPagina,
                    result.Total
                );

                ViewBag.TotalItens = result.Total;

                return View("Index", result);
            }
            catch (Exception ex)
            {
                ViewBag.TotalItens = 0;
                ViewBag.Error = $"Erro ao pesquisar vaga. Erro: {ex.Message}";
                return View("Index");
            }
        }


        [HttpGet]
        [Route("Cadastro")]
        public ActionResult Cadastro()
        {
            try
            {
                var vagas = _empresaAppService.GetAll();
                return View(vagas);
            }
            catch
            {
                //todo: retornar erro.
                return View();
            }
        }

        [HttpGet]
        [Route("Cadastrar")]
        public ActionResult Cadastrar()
        {
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
                    _empresaAppService.Add(model);
                    return RedirectToAction("Cadastro");
                }

                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            var empresa = _empresaAppService.GetById(id);
            return View(empresa);
        }

        [HttpGet]
        [Route("Alterar/{id}")]
        public ActionResult Alterar(int id)
        {
            EmpresaViewModel empresaViewModel = _empresaAppService.GetById(id);
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
                    _empresaAppService.Update(model);
                    return RedirectToAction("Cadastro");
                }
                return View(model);
            }
            catch
            {
                return View(model);
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
