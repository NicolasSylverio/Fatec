using Fatec.Application.ViewModels;
using Fatec.CrossCutting.Constants;
using Fatec.Identity;
using Fatec.Identity.Identity;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.Mvc.Controllers
{
    public class PermissaoController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public PermissaoController()
        {
            UserManager = null;
            SignInManager = null;
        }

        public PermissaoController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            try
            {
                var usuarios = UserManager.Users.ToList();

                var permissao = usuarios
                    .Select(s => new PermissaoViewModel
                    {
                        IdUsuario = s.Id,
                        EmailUsuario = s.Email,
                        NomeUsuario = s.UserName,
                        Role = "administrador"
                    })
                    .ToList();

                var result = new PermissaoFiltroViewModel
                {
                    Resultado = permissao
                };

                ViewBag.PagedList = new StaticPagedList<PermissaoViewModel>
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
                ViewBag.Error = $"Erro ao pesquisar usuários. Erro: {ex.Message}";
                return View("Index");
            }
        }

        [HttpGet]
        [Route("Details")]
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PermissaoViewModel model)
        {
            try
            {
                UserManager.RemoveFromRolesAsync(model.IdUsuario, Constants.SystemRoles);

                UserManager.AddToRoleAsync(model.IdUsuario, model.Role);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(string id)
        {
            try
            {
                var usuario = UserManager.Users.First(x => x.Id == id);

                var permissao = new PermissaoViewModel
                {
                    IdUsuario = usuario.Id,
                    NomeUsuario = usuario.UserName,
                    EmailUsuario = usuario.Email,
                    Role = "Administrador",
                };

                return View("Edit", permissao);
            }
            catch (Exception)
            {
                ViewBag.Error = "Usuário não encontrados";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public ActionResult Edit(string id, FormCollection collection)
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

        [HttpGet]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [Route("Delete/{id}")]
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
