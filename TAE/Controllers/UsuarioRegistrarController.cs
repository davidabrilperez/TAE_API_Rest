using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TAE.Models;
namespace TAE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioRegistrarController : Controller
    {
        // POST: api/<controller>
        [HttpPost]
        public UsuarioRegistroRespuesta RegisterStudent(Usuario studentregd)
        {
            Console.WriteLine("In registerStudent");
            UsuarioRegistroRespuesta stdregreply = new UsuarioRegistroRespuesta();
            UsuarioRegistro.getInstance().Add(studentregd);
            //stdregreply.Name = studentregd.Name;
            //stdregreply.Age = studentregd.Age;
            //stdregreply.RegistrationNumber = studentregd.RegistrationNumber;
            stdregreply.RegistrationStatus = "Successful";
            return stdregreply;
        }
        [HttpPost("InsertStudent")]
        public IActionResult InsertStudent(Usuario studentregd)
        {
            Console.WriteLine("In registerStudent");
            UsuarioRegistroRespuesta stdregreply = new UsuarioRegistroRespuesta();
            UsuarioRegistro.getInstance().Add(studentregd);
            //stdregreply.Name = studentregd.Name;
            //stdregreply.Age = studentregd.Age;
            //stdregreply.RegistrationNumber = studentregd.RegistrationNumber;
            stdregreply.RegistrationStatus = "Successful";
            return Ok(stdregreply);
        }
        [Route("student/")]
        [HttpPost("AddStudent")]
        public JsonResult AddStudent(Usuario studentregd)
        {
            Console.WriteLine("In registerStudent");
            UsuarioRegistroRespuesta stdregreply = new UsuarioRegistroRespuesta();
            UsuarioRegistro.getInstance().Add(studentregd);
            //stdregreply.Name = studentregd.Name;
            //stdregreply.Age = studentregd.Age;
            //stdregreply.RegistrationNumber = studentregd.RegistrationNumber;
            stdregreply.RegistrationStatus = "Successful";
            return Json(stdregreply);
        }
    }
}