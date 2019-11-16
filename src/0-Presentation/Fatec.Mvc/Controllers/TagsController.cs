using Fatec.Application.Interface;
using Fatec.Application.ViewModels;
using Fatec.CrossCutting.Models.PaginacaoHelper;
using PagedList;
using System;
using System.Web.Mvc;

namespace Fatec.Mvc.Controllers
{
    [Authorize]
    public class TagsController : Controller
    {
        private readonly ITagsAppService _tagsAppService;

        public TagsController(ITagsAppService tagsAppService)
        {
            _tagsAppService = tagsAppService;
        }

        [HttpGet]
        [Route("Index")]
        public ActionResult Index(PaginacaoViewModel<TagsViewModel> view)
        {
            try
            {
                var result = _tagsAppService.GetAll(new Paginacao(view.Pagina, view.TotalPorPagina));

                ViewBag.PagedList = new StaticPagedList<TagsViewModel>
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

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [Route("Cadastrar/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(TagsViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View();

                model.DataCadastro = DateTime.Now;
                _tagsAppService.Add(model);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.Error = "Erro ao cadastrar nova Tag";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            try
            {
                var tag = _tagsAppService.GetById(id);

                return View(tag);
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Erro ao carregar Tag Erro: {ex.Message}";
                return View();
            }
        }

        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TagsViewModel model)
        {
            try
            {
                _tagsAppService.Update(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Erro ao carregar Tag Erro: {ex.Message}";
                return View();
            }
        }

        [HttpPost]
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                _tagsAppService.Remove(id);

                ViewBag.Sucess = "Tags excluida com sucesso.";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Erro ao deletar Tag Erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}