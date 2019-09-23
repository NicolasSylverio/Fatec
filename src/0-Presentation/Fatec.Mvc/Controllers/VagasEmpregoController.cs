using Fatec.Application.Interface;
using Fatec.Application.ViewModels;
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

        // GET: VagasEmprego
        public ActionResult Index()
        {
            ViewBag.Title = "Vagas de Emprego";
            var vagas = _vagaEmpregoAppService.GetAll();
            return View(vagas);
        }

        public ActionResult Cadastrar()
        {
            ViewBag.EmpresaId = _empresaAppService.GetAll();
            ViewBag.Tags = new MultiSelectList(_tagsAppService.GetAll(), "Id", "Nome");

            ViewBag.Tags = _tagsAppService.GetAll().Select(x => new { x.Id, x.Nome });

            return View();
        }

        // GET: Tags/Edit/id
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

        // POST: Estagio/Edit/5
        [HttpPost]
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
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(VagaEmpregoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return RedirectToAction("Cadastrar");

                _vagaEmpregoAppService.Add(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.EmpresaId = _empresaAppService.GetAll();
                ViewBag.Tags = _tagsAppService.GetAll();

                ViewBag.Error = "Erro ao cadastrar nova Vaga Emprego";
                return RedirectToAction("Cadastrar");
            }
        }

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