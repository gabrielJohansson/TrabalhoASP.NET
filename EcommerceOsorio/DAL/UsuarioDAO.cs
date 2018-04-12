using EcommerceOsorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceOsorio.DAL
{
    public class UsuarioDAO
    {
        private static Context ctx = Singleton.Instance.Context;
        public static List<Usuario> ReturnList()
        {
            return ctx.Usuarios.ToList();
        }

        public static void Add(Usuario usuario)
        {
            ctx.Usuarios.Add(usuario);
            ctx.SaveChanges();
        }

        public static Usuario Login(Usuario u)
        {
            return ctx.Usuarios.FirstOrDefault(X=>X.Senha.Equals(u.Senha) && X.Email.Equals(u.Email));
        }
    }
}