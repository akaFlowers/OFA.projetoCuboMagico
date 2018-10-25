using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetoCuboMagico.Controllers
{
    public class GerentesController : Controller
    {
        // GET: Gerentes
        public ActionResult Index()
        {
            return View();
        }

        // GET: Gerentes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Gerentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gerentes/Create
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

        // GET: Gerentes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Gerentes/Edit/5
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

        // GET: Gerentes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Gerentes/Delete/5
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
