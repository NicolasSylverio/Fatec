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

namespace Fatec.Mvc.Controllers
{
    [Authorize]
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
                var teste = new List<DropDownDto> { new DropDownDto { Descricao = "Tag", Id = 0 } };

                _tagsAppService.GetAll().ToList().ForEach(x => teste.Add(new DropDownDto { Descricao = x.Nome, Id = x.Id }));

                ViewBag.Tags = teste;

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
        public ActionResult Lista(VagasFiltroViewModel<VagaEstagioViewModel> view)
        {
            try
            {
                var teste = new List<DropDownDto> { new DropDownDto { Descricao = "Tag", Id = 0 } };

                _tagsAppService.GetAll().ToList().ForEach(x => teste.Add(new DropDownDto { Descricao = x.Nome, Id = x.Id }));

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
        public ActionResult Cadastrar()
        {
            ViewBag.EmpresaId = _empresaAppService.GetAll();

            ViewBag.Tags = _tagsAppService.GetAll().Select(x => new { x.Id, x.Nome });

            return View();
        }

        [HttpPost]
        [Route("Cadastrar")]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(VagaEstagioViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View("Cadastrar", model);

                _vagaEstagioAppService.Add(model);

                return RedirectToAction("Lista");
            }
            catch (Exception)
            {
                ViewBag.EmpresaId = _empresaAppService.GetAll();
                ViewBag.Tags = _tagsAppService.GetAll();

                ViewBag.Error = "Erro ao cadastrar nova Vaga Emprego";
                return View("Cadastrar", model);
            }
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            try
            {
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
        public ActionResult Edit(VagaEstagioViewModel model)
        {
            try
            {
                _vagaEstagioAppService.Update(model);

                return RedirectToAction("Lista");
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Erro ao carregar Vaga. Erro: {ex.Message}";
                return View(model);
            }
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _vagaEstagioAppService.Remove(id);

                ViewBag.Sucess = "Vaga excluida com sucesso.";

                return RedirectToAction("Lista");
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Erro ao deletar Vaga. Erro: {ex.Message}";
                return RedirectToAction("Lista");
            }
        }
    }
}
