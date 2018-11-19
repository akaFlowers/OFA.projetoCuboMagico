using projetoCuboMagico.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetoCuboMagico.Controllers
{
    public class UnboxingsController : Controller
    {
        UnboxingsRepository unboxingsRepository = new UnboxingsRepository();
        // GET: Unboxing
        public ActionResult Index()
        {
            return View();
        }

        // GET: Unboxing/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Unboxing/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Unboxing/Create
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

        // GET: Unboxing/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Unboxing/Edit/5
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

        // GET: Unboxing/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Unboxing/Delete/5
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


        [HttpPost]
        public ActionResult AleatorizarBox(int id)
        {
            try
            {
                var assinatura = unboxingsRepository.trazerAssinaturaCliente(id);
                if (assinatura.Tipo.Equals("basica"))
                {
                    if (assinatura.Nome.Contains("Mensal"))
                    {




                    }
                    else if(assinatura.Nome.Contains("Semestral"))
                    {

                    }
                    else
                    {

                    }
                }
                else if (assinatura.Tipo.Equals("premium"))
                {
                    if (assinatura.Nome.Contains("Mensal"))
                    {

                    }
                    else if (assinatura.Nome.Contains("Semestral"))
                    {

                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            catch(Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }
            return View();
        }

    }
}
