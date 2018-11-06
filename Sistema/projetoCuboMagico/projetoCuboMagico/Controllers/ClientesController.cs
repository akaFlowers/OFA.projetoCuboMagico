using projetoCuboMagico.Models;
using projetoCuboMagico.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetoCuboMagico.Controllers
{
    public class ClientesController : Controller
    {
        ClientesRepository clientesRepository = new ClientesRepository();
        // GET: Clientes
        public ActionResult Index()
        {
            List<Cliente> cliente = clientesRepository.listarTodos().ToList();
            return View(cliente);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            return View(clientesRepository.consultaPorID(id));
        }

        // GET: Clientes/Create
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(ClienteUsuarioView clienteUsuario)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    //clientesRepository.incluirCliente(cliente);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
            }
            return View(clienteUsuario);
        }

        // GET: Clientes/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(clientesRepository.consultaPorID(id));
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                clientesRepository.alterarCliente(cliente);

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(clientesRepository.consultaPorID(id));
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Cliente cliente)
        {
            try
            {
                clientesRepository.deletarCliente(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
