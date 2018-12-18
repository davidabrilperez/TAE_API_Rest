using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace TAE.Models
{
    public class EnvioMail
    {
        public string email { get; set; }
        public string pass { get; set; }
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

        public EnvioMail(string email, string pass, string altaES, string altaEN, string altaFR, string altaIT, string altaPT,
            string recuperarES, string recuperarEN, string recuperarFR, string recuperarIT, string recuperarPT)
        {
            this.email = email;
            this.pass = pass;
            this.altaES = altaES;
            this.altaEN = altaEN;
            this.altaFR = altaFR;
            this.altaIT = altaIT;
            this.altaPT = altaPT;
            this.recuperarES = recuperarES;
            this.recuperarEN = recuperarEN;
            this.recuperarFR = recuperarFR;
            this.recuperarIT = recuperarIT;
            this.recuperarPT = recuperarPT;
        }

        public void EnviarEmail(string to, string tipo, int idioma)
        {
            SmtpClient clienteEnvio = new SmtpClient("smtp.gmail.com");
            clienteEnvio.Port = 587;
            clienteEnvio.EnableSsl = true;
            clienteEnvio.UseDefaultCredentials = false;
            clienteEnvio.Credentials = new NetworkCredential(email, pass);

            MailMessage mensaje = new MailMessage();
            mensaje.From = new MailAddress(email);
            mensaje.Sender = new MailAddress(email);
            mensaje.To.Add(to);
            mensaje.Subject = "TAE APP";

            var body = new StringBuilder();
            try
            {
                using (StreamReader sr = new StreamReader("Pages/Correo/" + tipo + ".html"))
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
                    if (tipo == "alta")
                    {
                        plantillaIdioma = altaEN;
                    }
                    else
                    {
                        plantillaIdioma = recuperarEN;
                    }
                    break;
                case 3:
                    if (tipo == "alta")
                    {
                        plantillaIdioma = altaFR;
                    }
                    else
                    {
                        plantillaIdioma = recuperarFR;
                    }
                    break;
                case 4:
                    if (tipo == "alta")
                    {
                        plantillaIdioma = altaIT;
                    }
                    else
                    {
                        plantillaIdioma = recuperarIT;
                    }
                    break;
                case 5:
                    if (tipo == "alta")
                    {
                        plantillaIdioma = altaPT;
                    }
                    else
                    {
                        plantillaIdioma = recuperarPT;
                    }
                    break;
                default:
                    if (tipo == "alta")
                    {
                        plantillaIdioma = altaES;
                    }
                    else
                    {
                        plantillaIdioma = recuperarES;
                    }
                    break;
            }

            body.Replace("@@cuerpo@@", plantillaIdioma);
            string destino = "";
            if (tipo == "alta")
            {
                destino = "Registro";
            }
            else
            {
                destino = "Recuperar";
            }
            string url = "http://localhost:24614/Web/"+ destino + "?fecha=" + Uri.EscapeDataString(Encriptador.EncryptString(DateTime.Now.ToString())) + "&idioma=" + idioma + "&email=" + Uri.EscapeDataString(Encriptador.EncryptString(to));
            body.Replace("@@url@@", url);
            body .Replace("@@correo@@", to);
            mensaje.IsBodyHtml = true;
            mensaje.Body = body.ToString();

            //TAE.Controllers.WebController controladorInicializar = HttpContext.RequestServices.GetService(typeof(TAE.Controllers.WebController)) as WebController;

            clienteEnvio.Send(mensaje);
        }
    }
}
