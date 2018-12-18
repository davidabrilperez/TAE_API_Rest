using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TAE.Models;
using System.Data;

namespace TAE.Context
{
    public class BBDDContext
    {
        public string ConnectionString { get; set; }

        public BBDDContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public Administrador GetWebLogin(string email, string password)
        {
            Administrador administrador = new Administrador();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbladministradores WHERE email=@email AND password=@password", conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        administrador = new Administrador()
                        {
                            id = reader.GetInt32("id"),
                            email = reader.GetString("email"),
                            password = reader.GetString("password")
                        };
                    }
                }
            }

            return administrador;
        }

        public List<Usuario> GetAllUsuarios()
        {
            List<Usuario> list = new List<Usuario>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblusuarios", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Usuario()
                        {
                            id = reader.GetInt32("id"),
                            email = reader.GetString("email"),
                            password = reader.GetString("password"),
                            activo = reader.GetBoolean("activo"),
                            idioma = reader.GetInt32("idioma"),
                            imagen = reader.GetString("imagen")
                        });
                    }
                }
            }

            return list;
        }
        

        public bool setUsuarioActivo(string email)
        {
            int filasUpdated = 0;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE tblusuarios SET activo = 1 WHERE email=@email", conn);
                cmd.Parameters.AddWithValue("@email", email);
                filasUpdated = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            return (filasUpdated == 0) ? false : true;
        }

        public Usuario GetUsuario(int id)
        {
            Usuario usuario = new Usuario();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblusuarios WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id",id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuario = new Usuario()
                        {
                            id = reader.GetInt32("id"),
                            email = reader.GetString("email"),
                            password = reader.GetString("password"),
                            activo = reader.GetBoolean("activo"),
                            idioma = reader.GetInt32("idioma"),
                            imagen = reader.GetString("imagen")
                        };
                    }
                }
            }

            return usuario;
        }

        public Usuario GetUsuario(string email)
        {
            Usuario usuario = new Usuario();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblusuarios WHERE email=@email", conn);
                cmd.Parameters.AddWithValue("@email", email);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuario = new Usuario()
                        {
                            id = reader.GetInt32("id"),
                            email = reader.GetString("email"),
                            password = reader.GetString("password"),
                            activo = reader.GetBoolean("activo"),
                            idioma = reader.GetInt32("idioma"),
                            imagen = reader.GetString("imagen")
                        };
                    }
                }
            }

            return usuario;
        }

        public Usuario GetUsuarioLogin(string email, string password)
        {
            Usuario usuario = new Usuario();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblusuarios WHERE email=@email AND password=@password", conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuario = new Usuario()
                        {
                            id = reader.GetInt32("id"),
                            email = reader.GetString("email"),
                            password = reader.GetString("password"),
                            activo = reader.GetBoolean("activo"),
                            idioma = reader.GetInt32("idioma"),
                            imagen = reader.GetString("imagen")
                        };
                    }
                }
            }

            return usuario;
        }
        

        public Usuario GetUsuarioEmail(string email)
        {
            Usuario usuario = new Usuario();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblusuarios WHERE email=@email LIMIT 1", conn);
                cmd.Parameters.AddWithValue("@email", email);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuario = new Usuario()
                        {
                            id = reader.GetInt32("id"),
                            email = reader.GetString("email"),
                            password = reader.GetString("password"),
                            activo = reader.GetBoolean("activo"),
                            idioma = reader.GetInt32("idioma"),
                            imagen = reader.GetString("imagen")
                        };
                    }
                }
            }

            return usuario;
        }

        public List<Tecnica> GetAllTecnicas()
        {
            List<Tecnica> list = new List<Tecnica>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM qrytecnicas", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Tecnica()
                        {
                            idCinturon = reader.GetInt32("idCinturon"),
                            cinturon = reader.GetString("cinturon"),
                            idTipotecnica = reader.GetInt32("idTipotecnica"),
                            tipotecnica = reader.GetString("tipotecnica"),
                            idtecnica = reader.GetInt32("idtecnica"),
                            tecnica = reader.GetString("tecnica")
                        });
                    }
                }
            }

            return list;
        }

        public Usuario setUsuario(int? id, string email, string password, bool? activo, int idioma, string imagen)
        {
            Usuario usuario = new Usuario();

            using (MySqlConnection conn = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "insertarusuario";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_id", id);
                    cmd.Parameters["@_id"].Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@_email", email);
                    cmd.Parameters["@_email"].Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@_password", password);
                    cmd.Parameters["@_password"].Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@_activo", activo);
                    cmd.Parameters["@_activo"].Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@_idioma", idioma);
                    cmd.Parameters["@_idioma"].Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@_imagen", imagen);
                    cmd.Parameters["@_imagen"].Direction = ParameterDirection.Input;
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuario = new Usuario()
                            {
                                id = reader.GetInt32("id"),
                                email = reader.GetString("email"),
                                password = reader.GetString("password"),
                                activo = reader.GetBoolean("activo"),
                                idioma = reader.GetInt32("idioma"),
                                imagen = reader.GetString("imagen")
                            };
                        }
                    }
                }
            }

            return usuario;
        }

        public Tecnica GetTecnica(int idtecnica)
        {
            Tecnica tecnica = new Tecnica();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM qrytecnicas WHERE idtecnica=@idtecnica", conn);
                cmd.Parameters.AddWithValue("@idtecnica", idtecnica);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tecnica = new Tecnica()
                        {
                            idCinturon = reader.GetInt32("idCinturon"),
                            cinturon = reader.GetString("cinturon"),
                            idTipotecnica = reader.GetInt32("idTipotecnica"),
                            tipotecnica = reader.GetString("tipotecnica"),
                            idtecnica = reader.GetInt32("idtecnica"),
                            tecnica = reader.GetString("tecnica")
                        };
                    }
                }
            }

            return tecnica;
        }

        public Fotografia GetFotografia(int idfoto)
        {
            Fotografia fotografia = new Fotografia();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM qryfotos WHERE idfoto=@idfoto", conn);
                cmd.Parameters.AddWithValue("@idfoto", idfoto);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fotografia = new Fotografia()
                        {
                            idFoto = reader.GetInt32("idfoto"),
                            foto = reader.GetString("foto"),
                            idCinturon = reader.GetInt32("idCinturon"),
                            cinturon = reader.GetString("cinturon"),
                            idTipotecnica = reader.GetInt32("idTipotecnica"),
                            tipotecnica = reader.GetString("tipotecnica"),
                            idtecnica = reader.GetInt32("idtecnica"),
                            tecnica = reader.GetString("tecnica"),
                            idusuario = reader.GetInt32("idusuario"),
                            email = reader.GetString("email"),
                            idioma = reader.GetInt32("idioma"),
                            imagen = reader.GetString("imagen")
                        };
                    }
                }
            }

            return fotografia;
        }

        public List<Fotografia> GetAllFotografias()
        {
            List<Fotografia> list = new List<Fotografia>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM qryfotos", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Fotografia()
                        {
                            idFoto = reader.GetInt32("idfoto"),
                            foto = reader.GetString("foto"),
                            idCinturon = reader.GetInt32("idCinturon"),
                            cinturon = reader.GetString("cinturon"),
                            idTipotecnica = reader.GetInt32("idTipotecnica"),
                            tipotecnica = reader.GetString("tipotecnica"),
                            idtecnica = reader.GetInt32("idtecnica"),
                            tecnica = reader.GetString("tecnica"),
                            idusuario = reader.GetInt32("idusuario"),
                            email = reader.GetString("email"),
                            idioma = reader.GetInt32("idioma"),
                            imagen = reader.GetString("imagen")
                        });
                    }
                }
            }

            return list;
        }

        
        public bool DeleteUsuario(int id)
        {
            Tecnica tecnica = new Tecnica();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM tblusuarios WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                int resultado = cmd.ExecuteNonQuery();
                if(resultado == 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}