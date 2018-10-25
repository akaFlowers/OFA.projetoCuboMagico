using projetoCuboMagico.Models;
using projetoCuboMagico.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetoCuboMagico.Controllers
{
    public class BrindesController : Controller
    {
        BrindesRepository brindesRepository = new BrindesRepository();
        // GET: Brindes
        public ActionResult Index()
        {
            List<Brinde> brinde = brindesRepository.listarTodos().ToList();
            return View(brinde);
        }

        // GET: Brindes/Details/5
        public ActionResult Details(int id)
        {
            return View(brindesRepository.consultaPorID(id));
        }

        // GET: Brindes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brindes/Create
        [HttpPost]
        public ActionResult Create(Brinde brinde)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    brindesRepository.incluirBrinde(brinde);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
            }
            return View(brinde);
        }

        // GET: Brindes/Edit/5
        public ActionResult Edit(int id)
        {
            return View(brindesRepository.consultaPorID(id));
        }

        // POST: Brindes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Brinde brinde)
        {
            try
            {
                brindesRepository.alterarBrinde(brinde);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }
            return View(brinde);
        }

        // GET: Brindes/Delete/5
        public ActionResult Delete(int id)
        {
            return View(brindesRepository.consultaPorID(id));
        }

        // POST: Brindes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Brinde brinde)
        {
            try
            {
                brindesRepository.deletarBrinde(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
