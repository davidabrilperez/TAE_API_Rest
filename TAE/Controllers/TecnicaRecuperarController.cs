using Microsoft.AspNetCore.Mvc;
using TAE.Context;
using TAE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TAE.Controllers
{
    [ApiController]
    public class TecnicaRecuperarController : Controller
    {
        [Route("api/tecnicasrecuperar")]
        [HttpGet]
        public JsonResult GetAllTecnicas()
        {
            BBDDContext context = HttpContext.RequestServices.GetService(typeof(TAE.Context.BBDDContext)) as BBDDContext;

            List<Tecnica> listaTecnicas = context.GetAllTecnicas();

            Respuestas.RespuestaTecnicas respuestaTecnicas = new Respuestas.RespuestaTecnicas();
            respuestaTecnicas.respuesta.funcion = "api/tecnicasrecuperar";
            respuestaTecnicas.respuesta.fecha = DateTime.Now;
            respuestaTecnicas.tecnicas = listaTecnicas;

            if (respuestaTecnicas.tecnicas.Count > 0)
            {
                respuestaTecnicas.respuesta.codigo = 1;
                respuestaTecnicas.respuesta.mensaje = "Tecnicas encontradas";
                
                return Json(respuestaTecnicas);
            }
            else
            {
                respuestaTecnicas.respuesta.codigo = 0;
                respuestaTecnicas.respuesta.mensaje = "Tecnicas no encontradas";

                return Json(respuestaTecnicas);
            }

        }
        [Route("api/tecnicarecuperar/{idtecnica}")]
        [HttpGet]
        public JsonResult GetTecnica(int idtecnica)
        {
            BBDDContext context = HttpContext.RequestServices.GetService(typeof(TAE.Context.BBDDContext)) as BBDDContext;

            Tecnica tecnica = context.GetTecnica(idtecnica);

            Respuestas.RespuestaTecnica respuestaTecnica = new Respuestas.RespuestaTecnica();
            respuestaTecnica.respuesta.funcion = "api/tecnicarecuperar";
            respuestaTecnica.respuesta.fecha = DateTime.Now;
            respuestaTecnica.tecnica = tecnica;

            if (tecnica.idtecnica != 0)
            {
                respuestaTecnica.respuesta.codigo = 1;
                respuestaTecnica.respuesta.mensaje = "Tecnica encontrada";
                
                return Json(respuestaTecnica);
            }
            else
            {
                respuestaTecnica.respuesta.codigo = 0;
                respuestaTecnica.respuesta.mensaje = "Tecnica no encontrada";

                return Json(respuestaTecnica);
            }
        }
    }
}