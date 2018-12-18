using Microsoft.AspNetCore.Mvc;
using TAE.Context;
using TAE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TAE.Controllers
{
    [ApiController]
    public class UsuarioRecuperarController : Controller
    {
        [Route("api/usuariosrecuperar")]
        [HttpGet]
        public JsonResult GetAllUsuarios()
        {
            BBDDContext context = HttpContext.RequestServices.GetService(typeof(TAE.Context.BBDDContext)) as BBDDContext;

            List<Usuario> listaUsuarios = context.GetAllUsuarios();

            Respuestas.RespuestaUsuarios respuestaUsuarios = new Respuestas.RespuestaUsuarios();
            respuestaUsuarios.respuesta.funcion = "api/usuariosrecuperar";
            respuestaUsuarios.respuesta.fecha = DateTime.Now;
            respuestaUsuarios.usuarios = listaUsuarios;

            if (respuestaUsuarios.usuarios.Count > 0)
            {
                respuestaUsuarios.respuesta.codigo = 1;
                respuestaUsuarios.respuesta.mensaje = "Usuarios encontrados";
                
                return Json(respuestaUsuarios);
            }
            else
            {
                respuestaUsuarios.respuesta.codigo = 0;
                respuestaUsuarios.respuesta.mensaje = "Usuarios no encontrados";

                return Json(respuestaUsuarios);
            }

        }
        [Route("api/usuariorecuperar/{id}")]
        [HttpGet]
        public JsonResult GetUsuario(int id)
        {
            BBDDContext context = HttpContext.RequestServices.GetService(typeof(TAE.Context.BBDDContext)) as BBDDContext;

            Usuario usuario = context.GetUsuario(id);

            Respuestas.RespuestaUsuario respuestaUsuario = new Respuestas.RespuestaUsuario();
            respuestaUsuario.respuesta.funcion = "api/usuariorecuperar";
            respuestaUsuario.respuesta.fecha = DateTime.Now;
            respuestaUsuario.usuario = usuario;

            if (usuario.id != 0)
            {
                respuestaUsuario.respuesta.codigo = 1;
                respuestaUsuario.respuesta.mensaje = "Usuario encontrado";
                
                return Json(respuestaUsuario);
            }
            else
            {
                respuestaUsuario.respuesta.codigo = 0;
                respuestaUsuario.respuesta.mensaje = "Usuario no encontrado";

                return Json(respuestaUsuario);
            }
        }
        [Route("api/usuariorecuperarLogin/{email}/{password}")]
        [HttpPost]
        public JsonResult PostUsuarioLogin(string email, string password)
        {
            BBDDContext context = HttpContext.RequestServices.GetService(typeof(TAE.Context.BBDDContext)) as BBDDContext;

            //password = Encriptador.Encriptar(password);

            Usuario usuario = context.GetUsuarioLogin(email, password);

            Respuestas.RespuestaUsuarioLogin respuestaUsuarioLogin = new Respuestas.RespuestaUsuarioLogin();
            respuestaUsuarioLogin.respuesta.funcion = "api/usuariorecuperarLogin";
            respuestaUsuarioLogin.respuesta.fecha = DateTime.Now;
            respuestaUsuarioLogin.usuario = usuario;

            if (usuario.id != 0 && usuario.activo == true)
            {
                respuestaUsuarioLogin.respuesta.codigo = 1;
                respuestaUsuarioLogin.respuesta.mensaje = "Usuario encontrado";

                return Json(respuestaUsuarioLogin);
            }   
            else if(usuario.id != 0 && usuario.activo == false)
            {
                respuestaUsuarioLogin.respuesta.codigo = 0;
                respuestaUsuarioLogin.respuesta.mensaje = "Usuario no activo";

                return Json(respuestaUsuarioLogin);
            }
            else
            {
                respuestaUsuarioLogin.respuesta.codigo = 0;
                respuestaUsuarioLogin.respuesta.mensaje = "Usuario no encontrado";

                return Json(respuestaUsuarioLogin);
            }
        }
        [Route("api/usuariorecuperarEmail/{email}")]
        [HttpPost]
        public JsonResult PostUsuarioEmail(string email)
        {
            BBDDContext context = HttpContext.RequestServices.GetService(typeof(TAE.Context.BBDDContext)) as BBDDContext;

            //password = Encriptador.Encriptar(password);

            Usuario usuario = context.GetUsuarioEmail(email);

            Respuestas.RespuestaUsuarioLogin respuestaUsuarioLogin = new Respuestas.RespuestaUsuarioLogin();
            respuestaUsuarioLogin.respuesta.funcion = "api/usuariorecuperarEmail";
            respuestaUsuarioLogin.respuesta.fecha = DateTime.Now;
            respuestaUsuarioLogin.usuario = usuario;

            if (usuario.id != 0 && usuario.activo == true)
            {
                respuestaUsuarioLogin.respuesta.codigo = 1;
                respuestaUsuarioLogin.respuesta.mensaje = "Usuario encontrado";

                EnvioMail envioMail = HttpContext.RequestServices.GetService(typeof(TAE.Models.EnvioMail)) as EnvioMail;
                envioMail.EnviarEmail(usuario.email, "recuperar", usuario.idioma);

                return Json(respuestaUsuarioLogin);
            }
            else if (usuario.id != 0 && usuario.activo == false)
            {
                respuestaUsuarioLogin.respuesta.codigo = 0;
                respuestaUsuarioLogin.respuesta.mensaje = "Usuario no activo";

                return Json(respuestaUsuarioLogin);
            }
            else
            {
                respuestaUsuarioLogin.respuesta.codigo = 0;
                respuestaUsuarioLogin.respuesta.mensaje = "Usuario no encontrado";

                return Json(respuestaUsuarioLogin);
            }
        }
        [Route("api/usuarioregistrar/{email}/{password}/{idioma}/{imagen}")]
        [HttpPost]
        public JsonResult PostUsuarioRegistrar(string email, string password, int idioma, string imagen)
        {
            BBDDContext context = HttpContext.RequestServices.GetService(typeof(TAE.Context.BBDDContext)) as BBDDContext;
            
            Usuario usuario = context.setUsuario(null, email, password, null, idioma, imagen);

            Respuestas.RespuestaUsuario respuestaUsuarioLogin = new Respuestas.RespuestaUsuario();
            respuestaUsuarioLogin.respuesta.funcion = "api/usuarioregistrar";
            respuestaUsuarioLogin.respuesta.fecha = DateTime.Now;
            respuestaUsuarioLogin.usuario = usuario;

            if (usuario.id != 0)
            {
                respuestaUsuarioLogin.respuesta.codigo = 1;
                respuestaUsuarioLogin.respuesta.mensaje = "Usuario registrado";

                EnvioMail envioMail = HttpContext.RequestServices.GetService(typeof(TAE.Models.EnvioMail)) as EnvioMail;
                envioMail.EnviarEmail(usuario.email, "alta", usuario.idioma);

                return Json(respuestaUsuarioLogin);
            }
            else
            {
                respuestaUsuarioLogin.respuesta.codigo = 0;
                respuestaUsuarioLogin.respuesta.mensaje = "Usuario no registrado";

                return Json(respuestaUsuarioLogin);
            }
        }
        [Route("api/usuariomodificar/{id}/{email}/{password}/{activo}/{idioma}/{imagen}")]
        [HttpPost]
        public JsonResult PostUsuarioRegistrar(int id, string email, string password, bool activo, int idioma, string imagen)
        {
            BBDDContext context = HttpContext.RequestServices.GetService(typeof(TAE.Context.BBDDContext)) as BBDDContext;

            Usuario usuario = context.setUsuario(id, email, password, activo, idioma, imagen);

            Respuestas.RespuestaUsuario respuestaUsuarioLogin = new Respuestas.RespuestaUsuario();
            respuestaUsuarioLogin.respuesta.funcion = "api/usuariomodificar";
            respuestaUsuarioLogin.respuesta.fecha = DateTime.Now;
            respuestaUsuarioLogin.usuario = usuario;

            if (usuario.id != 0)
            {
                respuestaUsuarioLogin.respuesta.codigo = 1;
                respuestaUsuarioLogin.respuesta.mensaje = "Usuario modificado";

                return Json(respuestaUsuarioLogin);
            }
            else
            {
                respuestaUsuarioLogin.respuesta.codigo = 0;
                respuestaUsuarioLogin.respuesta.mensaje = "Usuario no modificado";

                return Json(respuestaUsuarioLogin);
            }
        }
    }
}