using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.Mvc.Controllers
{
    public class VagasEstagioController : Controller
    {
        // GET: Estagio
        public ActionResult Index()
        {
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
