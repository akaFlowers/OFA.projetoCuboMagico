using projetoCuboMagico.Models;
using projetoCuboMagico.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetoCuboMagico.Controllers
{
    public class LivrosController : Controller
    {
        LivrosRepository livrosRepository = new LivrosRepository();
        // GET: Livros
        public ActionResult Index()
        {
            List<Livro> livro = livrosRepository.listarTodos().ToList();
            return View(livro);
        }

        // GET: Livros/Details/5
        public ActionResult Details(int id)
        {
            return View(livrosRepository.consultaPorID(id));
        }

        // GET: Livros/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livros/Create
        [HttpPost]
        public ActionResult Create(Livro livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    livrosRepository.incluirLivro(livro);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
            }
            return View(livro);
        }

        // GET: Livros/Edit/5
        public ActionResult Edit(int id)
        {
            return View(livrosRepository.consultaPorID(id));
        }

        // POST: Livros/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Livro livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    livrosRepository.alterarLivro(livro);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch(Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
            }
            return View(livro);
        }

        // GET: Livros/Delete/5
        public ActionResult Delete(int id)
        {
            return View(livrosRepository.consultaPorID(id));
        }

        // POST: Livros/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Livro livro)
        {
            try
            {
                livrosRepository.deletarLivro(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
