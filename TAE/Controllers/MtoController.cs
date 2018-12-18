using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using TAE.Models;
using TAE.Context;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TAE.Controllers
{
    public class MtoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login()
        {
            BBDDContext context = HttpContext.RequestServices.GetService(typeof(TAE.Context.BBDDContext)) as BBDDContext;

            var email = HttpContext.Request.Form["email"];
            var password = HttpContext.Request.Form["password"];

            Administrador administrador = context.GetWebLogin(email, password);

            if (administrador.id != 0)
            {
                var admin = JsonConvert.SerializeObject(administrador);
                HttpContext.Session.SetString("email", email);
                
                return RedirectToAction("Landing");
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult Landing()
        {
            if (HttpContext.Session.GetString("email") != null){

                ViewBag.email = HttpContext.Session.GetString("email");

                return View();
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult Deslogear()
        {
            HttpContext.Session.Remove("email");

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Usuarios()
        {
            if (HttpContext.Session.GetString("email") != null)
            {
                BBDDContext context = HttpContext.RequestServices.GetService(typeof(TAE.Context.BBDDContext)) as BBDDContext;

                List<Usuario> usuarios = context.GetAllUsuarios();

                ViewBag.email = HttpContext.Session.GetString("email");

                return View(usuarios);
            }
            else
            {
                return View("Login");
            }
        }

        [HttpGet]
        [Route("Mto/Usuario/{id}")]
        public ActionResult Usuario(int id)
        {
            if (HttpContext.Session.GetString("email") != null)
            {
                BBDDContext context = HttpContext.RequestServices.GetService(typeof(TAE.Context.BBDDContext)) as BBDDContext;

                Usuario usuario = context.GetUsuario(id);

                ViewBag.email = HttpContext.Session.GetString("email");
                
                return View(usuario);   
            }
            else
            {
                return View("Login");
            }
        }

        [HttpGet]
        [Route("Mto/UsuarioBorrar/{id}")]
        public ActionResult UsuarioBorrar(int id)
        {
            if (HttpContext.Session.GetString("email") != null)
            {
                BBDDContext context = HttpContext.RequestServices.GetService(typeof(TAE.Context.BBDDContext)) as BBDDContext;

                bool correcto = context.DeleteUsuario(id);

                ViewBag.email = HttpContext.Session.GetString("email");

                return RedirectToAction("Usuarios");
            }
            else
            {
                return View("Login");
            }
        }

        [HttpPost]
        public IActionResult Usuario(int id, string email, string password, int idioma, bool activo, string imagen)
        {
            if (HttpContext.Session.GetString("email") != null)
            {
                BBDDContext context = HttpContext.RequestServices.GetService(typeof(TAE.Context.BBDDContext)) as BBDDContext;

                if (id != 0)
                {
                    Usuario usuario = context.setUsuario(id, email, Encriptador.EncriptarSHA1(password), activo, idioma, imagen);
                }
                else
                {
                    Usuario usuario = context.setUsuario(null, email, Encriptador.EncriptarSHA1(password), activo, idioma, imagen);
                }

                ViewBag.email = HttpContext.Session.GetString("email");

                return RedirectToAction("Usuarios");
            }
            else
            {
                return View("Login");
            }
        }
    }
}
