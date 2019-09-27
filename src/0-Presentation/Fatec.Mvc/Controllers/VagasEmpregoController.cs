using Fatec.Application.Interface;
using Fatec.Application.ViewModels;
using Fatec.CrossCutting.Models.PaginacaoHelper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Fatec.Mvc.Models;
using WebGrease.Css.Extensions;

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
        public ActionResult Index(VagasFiltroViewModel<VagaEmpregoViewModel> view)
        {
            try
            {
                var teste = new List<DropDownDto> { new DropDownDto { Descricao = "Tag", Id = 0 } };

                _tagsAppService.GetAll().ForEach(x => teste.Add(new DropDownDto { Descricao = x.Nome, Id = x.Id }));

                ViewBag.Tags = teste;

                var pesquisa = view.PesquisaTitulo;
                var tags = view.Tags;

                var result = _vagaEmpregoAppService.GetAllByTituloTags
                (
                    pesquisa,
                    tags,
                    new Paginacao(view.Pagina, view.TotalPorPagina)
                );

                ViewBag.PagedList = new StaticPagedList<VagaEmpregoViewModel>
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
    }
}