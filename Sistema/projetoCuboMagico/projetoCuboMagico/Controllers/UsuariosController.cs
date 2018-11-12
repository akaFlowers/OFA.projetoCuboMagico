using projetoCuboMagico.Models;
using projetoCuboMagico.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = usuariosRepository.autenticarPorUsuario(usuario);
                    if(user.Usuarioo != null)
                    {
                       if(usuario.Senha == user.Senha)
                        {
                            Session["usuarioLogado"] = user;
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Senha incorreta");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Usuario não encotrado!");
                    }
                }               
            }
            catch(Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }
            return View();
        }

        [HttpGet]
        public ActionResult RedefinirSenha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RedefinirSenha(Cliente cliente)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario = usuariosRepository.consultaPorEmail(cliente.Email);
                if(usuario.Usuarioo != null)
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        //Adicione os emails que você vai mandar a mensagem
                        mail.From = new MailAddress("joao.vitor9524@gmail.com");
                        mail.To.Add(cliente.Email);

                        //Conteudo do email
                        mail.Subject = ("Redefinição de senha"); //Assunto
                        mail.Body = ("Redefina sua senha clicando no link http://localhost:54502/AlterarSenha?usuarioo=" + usuario.Usuarioo); //Corpo do email

                        //Enviar o email
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("joao.vitor9524@gmail.com", "MinhaSenhashaushauas");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email invalido!!");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }
            return View();
        }

        [HttpGet]
        public ActionResult AlterarSenha(string usuario)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AlterarSenha(Usuario usuario)
        {
            try
            {
                return View("Login");
            }
            catch(Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }
            return View();
        }
    }
}
