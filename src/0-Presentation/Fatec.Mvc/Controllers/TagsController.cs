using Fatec.Application.Interface;
using Fatec.Application.ViewModels;
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

        public ActionResult Index()
        {
            var tags = _tagsAppService.GetAll();
            return View(tags);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        // GET: Tags/Edit/id
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

        // POST: Estagio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var tags = _tagsAppService.GetById(id);
                _tagsAppService.Update(tags);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Erro ao carregar Tag Erro: {ex.Message}";
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(TagsViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View();

                model.DataHoraCadastro = DateTime.Now;
                _tagsAppService.Add(model);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.Error = "Erro ao cadastrar nova Tag";
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var tag = _tagsAppService.GetById(id);
                _tagsAppService.Remove(tag);

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