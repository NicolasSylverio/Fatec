using Fatec.Application.Interface;
using System.Linq;
using System.Web.Mvc;

namespace Fatec.Mvc.Controllers
{
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


        // GET: Estagio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Estagio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estagio/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estagio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Estagio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estagio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Estagio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
