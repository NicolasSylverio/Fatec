using Fatec.Application.Interface;
using Fatec.Application.ViewModels;
using Fatec.CrossCutting.Constants;
using Fatec.CrossCutting.Models.PaginacaoHelper;
using Fatec.Mvc.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Fatec.Mvc.App_Start;

namespace Fatec.Mvc.Controllers
{
    public class VagasEstagioController : Controller
    {
        private readonly IVagaEstagioAppService _vagaEstagioAppService;
        private readonly IEmpresaAppService _empresaAppService;
        private readonly ITagsAppService _tagsAppService;

        public VagasEstagioController
        (
            IVagaEstagioAppService vagaEmpregoAppService,
            IEmpresaAppService empresaAppService,
            ITagsAppService tagsAppService
        )
        {
            _vagaEstagioAppService = vagaEmpregoAppService;
            _empresaAppService = empresaAppService;
            _tagsAppService = tagsAppService;
        }

        [HttpGet]
        [Route("Index")]
        [AllowAnonymous]
        public ActionResult Index(VagasFiltroViewModel<VagaEstagioViewModel> view)
        {
            try
            {
                var tagsDisponiveis = new List<DropDownDto<int>> { new DropDownDto<int> { Descricao = "Tag", Id = 0 } };

                _tagsAppService.GetAll().ToList().ForEach(x => tagsDisponiveis.Add(new DropDownDto<int> { Descricao = x.Nome, Id = x.Id }));

                ViewBag.Tags = tagsDisponiveis;

                var pesquisa = view.PesquisaTitulo;
                var tags = view.Tags;

                var result = _vagaEstagioAppService.GetAllByTituloTags
                (
                    pesquisa,
                    tags,
                    new Paginacao(view.Pagina, Constants.NumeroVagasPorPagina)
                );

                ViewBag.PagedList = new StaticPagedList<VagaEstagioViewModel>
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
        [Route("Lista")]
        [CustomAuthorize(Roles = "administrador, usuario")]
        public ActionResult Lista(VagasFiltroViewModel<VagaEstagioViewModel> view)
        {
            try
            {
                var teste = new List<DropDownDto<int>> { new DropDownDto<int> { Descricao = "Tag", Id = 0 } };

                _tagsAppService.GetAll().ToList().ForEach(x => teste.Add(new DropDownDto<int> { Descricao = x.Nome, Id = x.Id }));

                ViewBag.Tags = teste;

                var pesquisa = view.PesquisaTitulo;
                var tags = view.Tags;

                var result = _vagaEstagioAppService.GetAllByTituloTags
                (
                    pesquisa,
                    tags,
                    new Paginacao(view.Pagina, Constants.NumeroPaginacaoListaDefault)
                );

                ViewBag.PagedList = new StaticPagedList<VagaEstagioViewModel>
                (
                    result.Resultado,
                    result.Pagina,
                    result.TotalPorPagina,
                    result.Total
                );

                ViewBag.TotalItens = result.Total;

                return View("Lista", result);
            }
            catch (Exception ex)
            {
                ViewBag.TotalItens = 0;
                ViewBag.Error = $"Erro ao pesquisar vaga. Erro: {ex.Message}";
                return View("Lista");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Detalhes/{id}")]
        public ActionResult Detalhes(int id)
        {
            try
            {
                var vagas = _vagaEstagioAppService.GetById(id);
                return View(vagas);
            }
            catch (Exception ex)
            {
                ViewBag.TotalItens = 0;
                ViewBag.Error = $"Erro ao pesquisar vaga. Erro: {ex.Message}";
                return View("Index");
            }
        }

        [HttpGet]
        [Route("Cadastrar")]
        [CustomAuthorize(Roles = "administrador, usuario")]
        public ActionResult Cadastrar()
        {
            ViewBag.Empresa = _empresaAppService.GetAll();

            ViewBag.Tags = _tagsAppService.GetAll().Select(x => new { x.Id, x.Nome });

            return View();
        }

        [HttpPost]
        [Route("Cadastrar")]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "administrador, usuario")]
        public ActionResult Cadastrar(VagaEstagioViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Empresa = _empresaAppService.GetAll();
                    ViewBag.Tags = _tagsAppService.GetAll();
                    return View("Cadastrar", model);
                }
                _vagaEstagioAppService.Add(model);

                return RedirectToAction("Lista");
            }
            catch (Exception)
            {
                ViewBag.Empresa = _empresaAppService.GetAll();
                ViewBag.Tags = _tagsAppService.GetAll();

                ViewBag.Error = "Erro ao cadastrar nova Vaga Emprego";
                return View("Cadastrar", model);
            }
        }

        [HttpGet]
        [Route("Edit/{id}")]
        [CustomAuthorize(Roles = "administrador, usuario")]
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.Empresa = _empresaAppService.GetAll();
                ViewBag.Tags = _tagsAppService.GetAll();

                var vaga = _vagaEstagioAppService.GetById(id);

                return View("Edit", vaga);
            }
            catch (Exception ex)
            {

                ViewBag.Error = $"Erro ao carregar Vaga. Erro: {ex.Message}";
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "administrador, usuario")]
        public ActionResult Edit(VagaEstagioViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _vagaEstagioAppService.Update(model);

                    return RedirectToAction("Lista");
                }

                ViewBag.Empresa = _empresaAppService.GetAll();
                ViewBag.Tags = _tagsAppService.GetAll();

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Empresa = _empresaAppService.GetAll();
                ViewBag.Tags = _tagsAppService.GetAll();

                ViewBag.Error = $"Erro ao carregar Vaga. Erro: {ex.Message}";
                return View(model);
            }
        }

        [HttpGet]
        [Route("Delete/{id}")]
        [CustomAuthorize(Roles = "administrador")]
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _vagaEstagioAppService.GetById(id);

                ViewBag.Sucess = "Vaga excluida com sucesso.";

                return View("Delete", model);
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Erro ao deletar Vaga. Erro: {ex.Message}";
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "administrador")]
        public ActionResult Delete(VagaEstagioViewModel model)
        {
            try
            {
                _vagaEstagioAppService.Remove(model.Id);

                ViewBag.Sucess = "Vaga excluida com sucesso.";

                return RedirectToAction("Lista");
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Erro ao deletar Vaga. Erro: {ex.Message}";
                return View("Delete", model);
            }
        }
    }
}
