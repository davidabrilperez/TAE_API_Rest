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
    public class WebAlmacen
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

        public WebAlmacen(string altaES, string altaEN, string altaFR, string altaIT, string altaPT,
            string recuperarES, string recuperarEN, string recuperarFR, string recuperarIT, string recuperarPT,
            string recuperarFinalES, string recuperarFinalEN, string recuperarFinalFR, string recuperarFinalIT, string recuperarFinalPT)
        {
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
            this.recuperarFinalES = recuperarFinalES;
            this.recuperarFinalEN = recuperarFinalEN;
            this.recuperarFinalFR = recuperarFinalFR;
            this.recuperarFinalIT = recuperarFinalIT;
            this.recuperarFinalPT = recuperarFinalPT;
        }        
    }
}
