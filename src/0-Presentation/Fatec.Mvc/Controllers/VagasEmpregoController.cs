using Fatec.Application.Interface;
using Fatec.Application.ViewModels;
using Fatec.CrossCutting.Models.PaginacaoHelper;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Fatec.Mvc.Controllers
{
    public class VagasEmpregoController : Controller
    {
        private readonly IVagaEmpregoAppService _vagaEmpregoAppService;
        private readonly IEmpresaAppService _empresaAppService;
        private readonly ITagsAppService _tagsAppService;

        public VagasEmpregoController
        (
            IVagaEmpregoAppService vagaEmpregoAppService,
            IEmpresaAppService empresaAppService,
            ITagsAppService tagsAppService
        )
        {
            _vagaEmpregoAppService = vagaEmpregoAppService;
            _empresaAppService = empresaAppService;
            _tagsAppService = tagsAppService;
        }

        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            try
            {
                ViewBag.Title = "Vagas de Emprego";
                ViewBag.Tags = _tagsAppService.GetAll().Select(x => new { x.Id, x.Nome });

                var viewModel = _vagaEmpregoAppService.GetAll(new Paginacao(1, 10));

                ViewBag.PagedList = new StaticPagedList<VagaEmpregoViewModel>
                (
                    viewModel.Objeto.Resultados,
                    viewModel.Objeto.Pagina,
                    viewModel.Objeto.TotalPorPagina,
                    viewModel.Objeto.Total
                );

                return View(viewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Erro ao pesquisar vagas. Erro: {ex.Message}";
                return View();
            }
        }

        [HttpPost]
        [Route("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult Index(VagasFiltroViewModel<VagaEmpregoViewModel> view)
        {
            try
            {
                ViewBag.Tags = _tagsAppService.GetAll().Select(x => new { x.Id, x.Nome });

                var result = _vagaEmpregoAppService.GetAllByTituloTags
                (
                    view.PesquisaTitulo,
                    view.Tags,
                    new Paginacao(view.Objeto.Pagina, view.Objeto.TotalPorPagina)
                );

                ViewBag.PagedList = new StaticPagedList<VagaEmpregoViewModel>
                (
                    result.Objeto.Resultados,
                    result.Objeto.Pagina,
                    result.Objeto.TotalPorPagina,
                    result.Objeto.Total
                );

                return View("Index", result);
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Erro ao pesquisar vaga. Erro: {ex.Message}";
                return View("Index");
            }
        }

        [Route("Detalhes/{id}")]
        public ActionResult Detalhes(int id)
        {
            ViewBag.Title = "Vagas de Emprego - Detalhes";
            var vagas = _vagaEmpregoAppService.GetById(id);
            return View(vagas);
        }

        [Route("Cadastrar")]
        public ActionResult Cadastrar()
        {
            ViewBag.EmpresaId = _empresaAppService.GetAll();

            ViewBag.Tags = _tagsAppService.GetAll().Select(x => new { x.Id, x.Nome });

            return View();
        }

        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            try
            {
                var tag = _vagaEmpregoAppService.GetById(id);

                return View(tag);
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Erro ao carregar Vaga. Erro: {ex.Message}";
                return View();
            }
        }

        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VagaEmpregoViewModel model)
        {
            try
            {
                _vagaEmpregoAppService.Update(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Erro ao carregar Vaga. Erro: {ex.Message}";
                return View();
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(VagaEmpregoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return RedirectToAction("Cadastrar");

                _vagaEmpregoAppService.Add(model);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.EmpresaId = _empresaAppService.GetAll();
                ViewBag.Tags = _tagsAppService.GetAll();

                ViewBag.Error = "Erro ao cadastrar nova Vaga Emprego";
                return RedirectToAction("Cadastrar");
            }
        }

        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                _vagaEmpregoAppService.Remove(id);

                ViewBag.Sucess = "Vaga excluida com sucesso.";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Erro ao deletar Vaga. Erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [Route("Paginacao")]
        public ActionResult Paginacao(VagasFiltroViewModel<VagaEmpregoViewModel> view)
        {
            try
            {
                ViewBag.Tags = _tagsAppService.GetAll().Select(x => new { x.Id, x.Nome });

                var result = _vagaEmpregoAppService.GetAllByTituloTags
                (
                    view.PesquisaTitulo,
                    view.Tags,
                    new Paginacao(view.Objeto.Pagina, view.Objeto.TotalPorPagina)
                );

                ViewBag.PagedList = new StaticPagedList<VagaEmpregoViewModel>
                (
                    result.Objeto.Resultados,
                    result.Objeto.Pagina,
                    result.Objeto.TotalPorPagina,
                    result.Objeto.Total
                );

                return View("Index", result);
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Erro ao pesquisar vaga. Erro: {ex.Message}";
                return View("Index");
            }
        }
    }
}