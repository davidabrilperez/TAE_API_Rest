
using System;
using System.Collections.Generic;

namespace TAE.Models
{
    public class Respuestas
    {
        public class Respuesta
        {
            public int codigo;
            public string mensaje;
            public string funcion;
            public DateTime fecha;
        }
        public class RespuestaUsuario
        {
            public Respuesta respuesta = new Respuesta();

            public Usuario usuario = new Usuario();
        }
        public class RespuestaUsuarios
        {
            public Respuesta respuesta = new Respuesta();

            public List<Usuario> usuarios = new List<Usuario>();
        }
        public class RespuestaUsuarioLogin
        {
            public Respuesta respuesta = new Respuesta();

            public Usuario usuario = new Usuario();
        }
        public class RespuestaTecnica
        {
            public Respuesta respuesta = new Respuesta();

            public Tecnica tecnica = new Tecnica();
        }
        public class RespuestaTecnicas
        {
            public Respuesta respuesta = new Respuesta();

            public List<Tecnica> tecnicas = new List<Tecnica>();
        }
        public class RespuestaFotografia
        {
            public Respuesta respuesta = new Respuesta();

            public Fotografia fotografia = new Fotografia();
        }
        public class RespuestaFotografias
        {
            public Respuesta respuesta = new Respuesta();

            public List<Fotografia> fotografias = new List<Fotografia>();
        }
    }
}