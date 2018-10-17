using projetoCuboMagico.Models;
using projetoCuboMagico.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetoCuboMagico.Controllers
{
    public class UsuariosController : Controller
    {
        UsuariosRepository usuariosRepository = new UsuariosRepository();
        // GET: Usuarios
        public ActionResult Index()
        {
            List<Usuario> usuario = usuariosRepository.listarTodos().ToList();
            return View(usuario);
        }

        // GET: Usuarios/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(usuariosRepository.consultaPorID(id));
        }

        // GET: Usuarios/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuariosRepository.incluirUsuario(usuario);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch(Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(usuariosRepository.consultaPorID(id));
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                usuariosRepository.alterarUsuario(usuario);

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(usuariosRepository.consultaPorID(id));
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Usuario usuario)
        {
            try
            {
                usuariosRepository.deletarUsuario(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
