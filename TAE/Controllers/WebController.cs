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
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TAE.Controllers
{
    public class WebController : Controller
    {
        public string altaES { get; set; }
        public string altaEN { get; set; }
        public string altaFR { get; set; }
        public string altaIT { get; set; }
        public string altaPT { get; set; }
        public string recuperarES { get; set; }
        public string recuperarEN { get; set; }
        public string recuperarFR { get; set; }
        public string recuperarIT { get; set; }
        public string recuperarPT { get; set; }
        public string recuperarFinalES { get; set; }
        public string recuperarFinalEN { get; set; }
        public string recuperarFinalFR { get; set; }
        public string recuperarFinalIT { get; set; }
        public string recuperarFinalPT { get; set; }

        public WebController()
        {
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Plantilla()
        {
            return View();
        }

        public IActionResult Registro(string fecha, int idioma, string email)
        {
            WebAlmacen webAlmacen = HttpContext.RequestServices.GetService(typeof(TAE.Models.WebAlmacen)) as WebAlmacen;
            
            this.altaES = webAlmacen.altaES;
            this.altaEN = webAlmacen.altaEN;
            this.altaFR = webAlmacen.altaFR;
            this.altaIT = webAlmacen.altaIT;
            this.altaPT = webAlmacen.altaPT;
            this.recuperarES = webAlmacen.recuperarES;
            this.recuperarEN = webAlmacen.recuperarEN;
            this.recuperarFR = webAlmacen.recuperarFR;
            this.recuperarIT = webAlmacen.recuperarIT;
            this.recuperarPT = webAlmacen.recuperarPT;
            this.recuperarFinalES = webAlmacen.recuperarFinalES;
            this.recuperarFinalEN = webAlmacen.recuperarFinalEN;
            this.recuperarFinalFR = webAlmacen.recuperarFinalFR;
            this.recuperarFinalIT = webAlmacen.recuperarFinalIT;
            this.recuperarFinalPT = webAlmacen.recuperarFinalPT;

            DateTime _fecha;

            fecha = Encriptador.DecryptString(Uri.UnescapeDataString(fecha));
            email = Encriptador.DecryptString(Uri.UnescapeDataString(email));

            if (!DateTime.TryParse(fecha, out _fecha))
            {
                return View("Error");
            }
            else
            {
                _fecha = _fecha.AddDays(1);
                if (_fecha.CompareTo(DateTime.Now) > 0)
                {
                    BBDDContext context = HttpContext.RequestServices.GetService(typeof(TAE.Context.BBDDContext)) as BBDDContext;

                    bool correcto = context.setUsuarioActivo(email);

                    if (!correcto)
                    {
                        return View("Error");
                    }

                    var body = new StringBuilder();
                    try
                    {
                        using (StreamReader sr = new StreamReader("Pages/Correo/alta.html"))
                        {
                            body.Append(sr.ReadToEnd());
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    string plantillaIdioma = "";
                    switch (idioma)
                    {
                        case 2:
                                plantillaIdioma = altaEN;
                            break;
                        case 3:
                                plantillaIdioma = altaFR;
                            break;
                        case 4:
                                plantillaIdioma = altaIT;
                            break;
                        case 5:
                                plantillaIdioma = altaPT;
                            break;
                        default:
                                plantillaIdioma = altaES;
                            break;
                    }

                    body.Replace("@@cuerpo@@", plantillaIdioma);
                    body.Replace("@@correo@@", email);

                    ViewBag.HtmlStr = body;
                }
            }

            
            return View();
        }
        public IActionResult Recuperar(string fecha, int idioma, string email)
        {
            WebAlmacen webAlmacen = HttpContext.RequestServices.GetService(typeof(TAE.Models.WebAlmacen)) as WebAlmacen;

            this.altaES = webAlmacen.altaES;
            this.altaEN = webAlmacen.altaEN;
            this.altaFR = webAlmacen.altaFR;
            this.altaIT = webAlmacen.altaIT;
            this.altaPT = webAlmacen.altaPT;
            this.recuperarES = webAlmacen.recuperarES;
            this.recuperarEN = webAlmacen.recuperarEN;
            this.recuperarFR = webAlmacen.recuperarFR;
            this.recuperarIT = webAlmacen.recuperarIT;
            this.recuperarPT = webAlmacen.recuperarPT;
            this.recuperarFinalES = webAlmacen.recuperarFinalES;
            this.recuperarFinalEN = webAlmacen.recuperarFinalEN;
            this.recuperarFinalFR = webAlmacen.recuperarFinalFR;
            this.recuperarFinalIT = webAlmacen.recuperarFinalIT;
            this.recuperarFinalPT = webAlmacen.recuperarFinalPT;

            DateTime _fecha;

            string fechaEncriptada = fecha;
            fecha = Encriptador.DecryptString(Uri.UnescapeDataString(fecha));
            string emailEncriptado = email;
            email = Encriptador.DecryptString(Uri.UnescapeDataString(email));

            if (!DateTime.TryParse(fecha, out _fecha))
            {
                return View("Error");
            }
            else
            {
                _fecha = _fecha.AddDays(1);
                if (_fecha.CompareTo(DateTime.Now) > 0)
                {
                    BBDDContext context = HttpContext.RequestServices.GetService(typeof(TAE.Context.BBDDContext)) as BBDDContext;

                    Usuario usuario = context.GetUsuario(email);


                    bool correcto = false;

                    if (usuario.id != 0)
                    {
                        correcto = true;
                    }

                    if (!correcto)
                    {
                        return View("Error");
                    }

                    var body = new StringBuilder();
                    try
                    {
                        using (StreamReader sr = new StreamReader("Pages/Correo/recuperar.html"))
                        {
                            body.Append(sr.ReadToEnd());
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    string plantillaIdioma = "";
                    switch (idioma)
                    {
                        case 2:
                            plantillaIdioma = recuperarEN;
                            break;
                        case 3:
                            plantillaIdioma = recuperarFR;
                            break;
                        case 4:
                            plantillaIdioma = recuperarIT;
                            break;
                        case 5:
                            plantillaIdioma = recuperarPT;
                            break;
                        default:
                            plantillaIdioma = recuperarES;
                            break;
                    }

                    body.Replace("@@cuerpo@@", plantillaIdioma);

                    string inicio = body.ToString().Substring(0, body.ToString().IndexOf("@@pass@@"));
                    string fin = body.ToString().Substring(body.ToString().IndexOf("@@pass@@")+8);

                    ViewBag.HtmlIni = inicio;
                    ViewBag.HtmlFin = fin;
                }
            }


            return View();
        }

        [HttpPost]
        public IActionResult Recuperar(string fecha, int idioma, string email, string pass)
        {
            WebAlmacen webAlmacen = HttpContext.RequestServices.GetService(typeof(TAE.Models.WebAlmacen)) as WebAlmacen;

            this.altaES = webAlmacen.altaES;
            this.altaEN = webAlmacen.altaEN;
            this.altaFR = webAlmacen.altaFR;
            this.altaIT = webAlmacen.altaIT;
            this.altaPT = webAlmacen.altaPT;
            this.recuperarES = webAlmacen.recuperarES;
            this.recuperarEN = webAlmacen.recuperarEN;
            this.recuperarFR = webAlmacen.recuperarFR;
            this.recuperarIT = webAlmacen.recuperarIT;
            this.recuperarPT = webAlmacen.recuperarPT;
            this.recuperarFinalES = webAlmacen.recuperarFinalES;
            this.recuperarFinalEN = webAlmacen.recuperarFinalEN;
            this.recuperarFinalFR = webAlmacen.recuperarFinalFR;
            this.recuperarFinalIT = webAlmacen.recuperarFinalIT;
            this.recuperarFinalPT = webAlmacen.recuperarFinalPT;

            DateTime _fecha;

            var password = HttpContext.Request.Form["password"];

            fecha = Encriptador.DecryptString(Uri.UnescapeDataString(fecha));
            email = Encriptador.DecryptString(Uri.UnescapeDataString(email));

            if (!DateTime.TryParse(fecha, out _fecha))
            {
                return View("Error");
            }
            else
            {
                _fecha = _fecha.AddDays(1);
                if (_fecha.CompareTo(DateTime.Now) > 0)
                {
                    BBDDContext context = HttpContext.RequestServices.GetService(typeof(TAE.Context.BBDDContext)) as BBDDContext;

                    Usuario usuario = context.GetUsuario(email);
                    Usuario usuarioModificado = context.setUsuario(usuario.id, usuario.email, password, usuario.activo, usuario.idioma, usuario.imagen);
                    
                    bool correcto = false;

                    if (usuarioModificado.id != 0)
                    {
                        correcto = true;
                    }

                    if (!correcto)
                    {
                        return View("Error");
                    }

                    var body = new StringBuilder();
                    try
                    {
                        using (StreamReader sr = new StreamReader("Pages/Correo/recuperar.html"))
                        {
                            body.Append(sr.ReadToEnd());
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    string plantillaIdioma = "";
                    switch (idioma)
                    {
                        case 2:
                            plantillaIdioma = recuperarFinalES;
                            break;
                        case 3:
                            plantillaIdioma = recuperarFinalFR;
                            break;
                        case 4:
                            plantillaIdioma = recuperarFinalIT;
                            break;
                        case 5:
                            plantillaIdioma = recuperarFinalPT;
                            break;
                        default:
                            plantillaIdioma = recuperarFinalES;
                            break;
                    }

                    body.Replace("@@cuerpo@@", plantillaIdioma);
                    

                    ViewBag.HtmlIni = body;
                    ViewBag.HtmlFin = null;
                }
            }


            return View();
        }

    }
}
