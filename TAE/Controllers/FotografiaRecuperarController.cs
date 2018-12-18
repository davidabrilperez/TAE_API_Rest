using Microsoft.AspNetCore.Mvc;
using TAE.Context;
using TAE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TAE.Controllers
{
    [ApiController]
    public class FotografiaRecuperarController : Controller
    {
        [Route("api/fotografiasrecuperar")]
        [HttpGet]
        public JsonResult GetAllTecnicas()
        {
            BBDDContext context = HttpContext.RequestServices.GetService(typeof(TAE.Context.BBDDContext)) as BBDDContext;

            List<Fotografia> listaFotografias = context.GetAllFotografias();

            Respuestas.RespuestaFotografias respuestaTecnicas = new Respuestas.RespuestaFotografias();
            respuestaTecnicas.respuesta.funcion = "api/fotografiasrecuperar";
            respuestaTecnicas.respuesta.fecha = DateTime.Now;
            respuestaTecnicas.fotografias = listaFotografias;

            if (respuestaTecnicas.fotografias.Count > 0)
            {
                respuestaTecnicas.respuesta.codigo = 1;
                respuestaTecnicas.respuesta.mensaje = "Fotografias encontradas";
                
                return Json(respuestaTecnicas);
            }
            else
            {
                respuestaTecnicas.respuesta.codigo = 0;
                respuestaTecnicas.respuesta.mensaje = "Fotografias no encontradas";

                return Json(respuestaTecnicas);
            }

        }
        [Route("api/fotografiarecuperar/{idfoto}")]
        [HttpGet]
        public JsonResult GetTecnica(int idfoto)
        {
            BBDDContext context = HttpContext.RequestServices.GetService(typeof(TAE.Context.BBDDContext)) as BBDDContext;

            Fotografia fotografia = context.GetFotografia(idfoto);

            Respuestas.RespuestaFotografia respuestaFotografia = new Respuestas.RespuestaFotografia();
            respuestaFotografia.respuesta.funcion = "api/fotografiarecuperar";
            respuestaFotografia.respuesta.fecha = DateTime.Now;
            respuestaFotografia.fotografia = fotografia;

            if (fotografia.idFoto != 0)
            {
                respuestaFotografia.respuesta.codigo = 1;
                respuestaFotografia.respuesta.mensaje = "Fotografia encontrada";
                
                return Json(respuestaFotografia);
            }
            else
            {
                respuestaFotografia.respuesta.codigo = 0;
                respuestaFotografia.respuesta.mensaje = "Fotografia no encontrada";

                return Json(respuestaFotografia);
            }
        }
    }
}