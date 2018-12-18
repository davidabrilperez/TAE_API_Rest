
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAE.Models
{
    public class UsuarioRegistro
    {
        List<Usuario> studentList;
        static UsuarioRegistro stdregd = null;
        private UsuarioRegistro()
        {
            studentList = new List<Usuario>();
        }
        public static UsuarioRegistro getInstance()
        {
            if (stdregd == null)
            {
                stdregd = new UsuarioRegistro();
                return stdregd;
            }
            else
            {
                return stdregd;
            }
        }
        public void Add(Usuario student)
        {
            studentList.Add(student);
        }
        public String Remove(String registrationNumber)
        {
            /*for (int i = 0; i < studentList.Count; i++)
            {
                Usuario stdn = studentList.ElementAt(i);
                if (stdn.RegistrationNumber.Equals(registrationNumber))
                {
                    studentList.RemoveAt(i);//update the new record
                    return "Delete successful";
                }
            }*/
            return "Delete un-successful";
        }
        public List<Usuario> getAllStudent()
        {
            return studentList;
        }
        public String UpdateStudent(Usuario std)
        {
            for (int i = 0; i < studentList.Count; i++)
            {
                Usuario stdn = studentList.ElementAt(i);
                /*if (stdn.RegistrationNumber.Equals(std.RegistrationNumber))
                {
                    studentList[i] = std;//update the new record
                    return "Update successful";
                }*/
            }
            return "Update un-successful";
        }
    }
}