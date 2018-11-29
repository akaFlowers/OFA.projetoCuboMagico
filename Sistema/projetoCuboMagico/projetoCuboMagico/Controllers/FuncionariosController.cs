using projetoCuboMagico.Models;
using projetoCuboMagico.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetoCuboMagico.Controllers
{
    public class FuncionariosController : Controller
    {
        FuncionariosRepository funcionariosRepository = new FuncionariosRepository();
        // GET: Funcionarios
        public ActionResult Index()
        {
            List<Funcionario> funcionario = funcionariosRepository.listarTodos().ToList();
            return View(funcionario);
        }
        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }

        // GET: Funcionarios/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(funcionariosRepository.consultaPorID(id));
        }

        // GET: Funcionarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        [HttpPost]
        public ActionResult Create(Funcionario funcionario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    funcionariosRepository.incluirFuncionario(funcionario);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(funcionariosRepository.consultaPorID(id));
        }

        // POST: Funcionarios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Funcionario funcionario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    funcionariosRepository.alterarFuncionario(funcionario);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(funcionariosRepository.consultaPorID(id));
        }

        // POST: Funcionarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Funcionario funcionario)
        {
            try
            {

                funcionariosRepository.deletarFuncionario(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
