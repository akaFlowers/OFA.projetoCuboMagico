using projetoCuboMagico.Models;
using projetoCuboMagico.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetoCuboMagico.Controllers
{
    public class GerentesController : Controller
    {
        GerentesRepository gerentesRepository = new GerentesRepository();
        // GET: Gerentes
        public ActionResult Index()
        {
            List<Gerente> gerente = gerentesRepository.listarTodos().ToList();
            return View(gerente);
        }

        // GET: Gerentes/Details/5
        public ActionResult Details(int id)
        {
            return View(gerentesRepository.consultaPorID(id));
        }

        // GET: Gerentes/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gerentes/Create
        [HttpPost]
        public ActionResult Create(Gerente gerente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gerentesRepository.incluirGerente(gerente);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
            }
            return View(gerente);
        }

        // GET: Gerentes/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(gerentesRepository.consultaPorID(id));
        }

        // POST: Gerentes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Gerente gerente)
        {
            try
            {
                gerentesRepository.alterarGerente(gerente);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }
            return View(gerente);
        }

        // GET: Gerentes/Delete/5
        public ActionResult Delete(int id)
        {
            return View(gerentesRepository.consultaPorID(id));
        }

        // POST: Gerentes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Gerente gerente)
        {
            try
            {
                gerentesRepository.deletarGerente(id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }
            return View(gerente);
        }
    }
}
