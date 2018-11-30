using projetoCuboMagico.Models;
using projetoCuboMagico.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetoCuboMagico.Controllers
{
    public class UnboxingsController : Controller
    {
        UnboxingsRepository unboxingsRepository = new UnboxingsRepository();
        DataTable dt;
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

        [HttpGet]
        public ActionResult AleatorizarBox(int id)
        {
            try
            {
                var assinatura = unboxingsRepository.trazerAssinaturaCliente(id);
                List<GeneroLivro> generoLivros = new List<GeneroLivro>();
                generoLivros = unboxingsRepository.buscarGeneroCliente(id).ToList();
                dt = new DataTable();
                dt = unboxingsRepository.trazerLivros(generoLivros);
                if (assinatura.Tipo.Equals("Mensal"))
                {   //Assinatura básica mensal
                    if (assinatura.Nome.Contains("Básica"))
                    {
                        Unboxing unboxing = new Unboxing();
                        int[] aleatorio = new int[1];
                        int iDataTable = dt.Rows.Count;
                        Random random = new Random();
                        aleatorio[0] = random.Next(iDataTable);
                        aleatorio[1] = random.Next(iDataTable);
                        while (aleatorio[0] == aleatorio[1])
                        {
                            aleatorio[1] = random.Next(iDataTable);
                        }
                        unboxing.DataGerada = DateTime.Now;


                    }
                    //Assinatura básica semestral
                    else if(assinatura.Nome.Contains("Premium"))
                    {

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Erro ao analisar assinatura entre em contanto com um administrador");
                    }
                }
                else if (assinatura.Tipo.Equals("Semestral"))
                {
                    //Assinatura Premium Mensal
                    if (assinatura.Nome.Contains("Básica"))
                    {

                    }
                    //Assinatura Premium Semestral
                    else if (assinatura.Nome.Contains("Premium"))
                    {

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Erro ao analisar assinatura entre em contanto com um administrador");
                    }
                }
                //Assinatura Anual
                else if(assinatura.Tipo.Equals("Anual"))
                {
                    //Assinatura Anual Básica
                    if (assinatura.Nome.Contains("Básica"))
                    {

                    }
                    //Assinatura Anual Premium
                    else if (assinatura.Nome.Contains("Premium"))
                    {

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Erro ao analisar assinatura entre em contanto com um administrador");
                    }
                }
                //Tratamento de erro
                else
                {
                    ModelState.AddModelError(string.Empty, "Tipo de assinatura invalida");
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
