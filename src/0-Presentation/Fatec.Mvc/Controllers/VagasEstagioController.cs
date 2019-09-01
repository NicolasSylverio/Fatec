using Fatec.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Fatec.Application.Interface;
using System.Linq;

namespace Fatec.Mvc.Controllers
{
    public class VagasEstagioController : Controller
    {
        private readonly IVagaEstagioAppService _vagaEstagioAppService;

        public VagasEstagioController(IVagaEstagioAppService vagaEstagioAppService)
        {
            _vagaEstagioAppService = vagaEstagioAppService;
        }
     
        // GET: Estagio
        public ActionResult Index()
        {

            //VagaEstagioViewModel vaga1 = new VagaEstagioViewModel
            //{
            //    Id = 1,
            //    Titulo = "VAGA DE ESTÁGIO PARA ÁREA DE TI",
            //    Subtitulo = "Vaga para Estagiário de TI",
            //    Empresa = "Vaga para Estagiário de TI",
            //    Descricao = "Estamos compondo nossa equipe de suporte/ Infraestrutura e buscamos alunos com potencial para crescimento Oferecemos bolsa auxilio," + Environment.NewLine +
            //    " refeição, vale transporte, seguro de vida" + Environment.NewLine +
            //    "É imprescindível que o candidato resida ou tenha fácil acesso a região de Cajamar(Lapa, Barueri, Osasco, Carapicuíba, Campo Limpo Paulista, Franco da Rocha, Francisco Morato e Jundiaí)" + Environment.NewLine +
            //    "Os interessados deverão encaminhar curriculum para: recrutamentoblue @bgdigital.com.br" + Environment.NewLine + Environment.NewLine +
            //    "Mencionar no assunto do e - mail(Vaga Estágio FATEC)"
            //};
            //VagaEstagioViewModel vaga2 = new VagaEstagioViewModel
            //{
            //    Id = 1,
            //    Titulo = "Android developer",
            //    Subtitulo = "Irá atuar no desenvolvimento de aplicativos mobile",
            //    Descricao = "STUB de vaga de estágio"
            //};
            //List<VagaEstagioViewModel> lstVagasView = new List<VagaEstagioViewModel>() { vaga1, vaga2 };
            ////List<VagaEstagio> lstVagas = new List<VagaEstagio>() { vaga1, vaga2 };
            ////List<VagaEstagioViewModel> lstVagasView = new List<VagaEstagioViewModel>();
            ////foreach(VagaEstagio vaga in lstVagas)
            ////{
            ////    lstVagasView.Add(Mapper.Map<VagaEstagio, VagaEstagioViewModel>(vaga));
            ////}
            //var listaUsuario = _vagaEstagioAppService.GetAllVagaEstagioViewModel();

            //return View(listaUsuario);
            var vagas = _vagaEstagioAppService.GetAllVagaEstagioViewModel().AsEnumerable();
            return View(vagas);
        }

        public ActionResult Cadastro()
        {
            //VagaEstagioViewModel vaga1 = new VagaEstagioViewModel
            //{
            //    Id = 1,
            //    Titulo = "VAGA DE ESTÁGIO PARA ÁREA DE TI",
            //    Subtitulo = "Vaga para Estagiário de TI",
            //    Empresa = "Vaga para Estagiário de TI",
            //    Descricao = "Estamos compondo nossa equipe de suporte/ Infraestrutura e buscamos alunos com potencial para crescimento Oferecemos bolsa auxilio," + Environment.NewLine +
            //     " refeição, vale transporte, seguro de vida" + Environment.NewLine +
            //     "É imprescindível que o candidato resida ou tenha fácil acesso a região de Cajamar(Lapa, Barueri, Osasco, Carapicuíba, Campo Limpo Paulista, Franco da Rocha, Francisco Morato e Jundiaí)" + Environment.NewLine +
            //     "Os interessados deverão encaminhar curriculum para: recrutamentoblue @bgdigital.com.br" + Environment.NewLine + Environment.NewLine +
            //     "Mencionar no assunto do e - mail(Vaga Estágio FATEC)"
            //};
            //VagaEstagioViewModel vaga2 = new VagaEstagioViewModel
            //{
            //    Id = 1,
            //    Titulo = "Android developer",
            //    Subtitulo = "Irá atuar no desenvolvimento de aplicativos mobile",
            //    Descricao = "STUB de vaga de estágio"
            //};
            //List<VagaEstagioViewModel> lstVagasView = new List<VagaEstagioViewModel>() { vaga1, vaga2 };
            ////List<VagaEstagioViewModel> lstVagasView = new List<VagaEstagioViewModel>();
            ////foreach (VagaEstagio vaga in lstVagas)
            ////{
            ////    lstVagasView.Add(Mapper.Map<VagaEstagio, VagaEstagioViewModel>(vaga));
            ////}

            var vagas = _vagaEstagioAppService.GetAllVagaEstagioViewModel().AsEnumerable();

            return View(vagas);
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
