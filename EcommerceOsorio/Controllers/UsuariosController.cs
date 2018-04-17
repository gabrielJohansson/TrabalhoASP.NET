using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommerceOsorio.Models;
using EcommerceOsorio.DAL;
using System.Text;
using Newtonsoft.Json;
using System.Web.Security;

namespace EcommerceOsorio.Controllers
{
    public class UsuariosController : Controller
    {
        
        // GET: Usuarios
        public ActionResult Index()
        {
            return View(UsuarioDAO.ReturnList());
        }


        // GET: Usuarios/Create
        public ActionResult Create()
        {
            Usuario u = (Usuario)TempData["Usuario"];
            return View(u);
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Usuario,Nome,Email,Senha,ConfirmacaoSenha,Cep,Logradouro,Bairro,Localidade,Uf")] Usuario usuario)
        {
            Usuario u = (Usuario)TempData["Usuario"];
            usuario.Bairro = u.Bairro;
            usuario.Localidade = u.Localidade;
            usuario.Logradouro = u.Logradouro;
            usuario.Uf = u.Uf;
            if (ModelState.IsValid)
            {
                UsuarioDAO.Add(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        [HttpPost]

        public ActionResult PesquisarCep(Usuario usuario)
        {

            string url = "https://viacep.com.br/ws/"+ usuario.Cep +"/json/";

            WebClient client = new WebClient();
            try
            {
                //baixando os dados do webservice
                string resultado = client.DownloadString(@url);
                //converter
                byte[] bytes = Encoding.Default.GetBytes(resultado);
                resultado = Encoding.UTF8.GetString(bytes);

                //popular obj com a string

                usuario = JsonConvert.DeserializeObject<Usuario>(resultado);
                //passar o obj para outra action
                TempData["Usuario"] = usuario;

               
            }
            catch (Exception)
            {

                TempData["Mensagem"]="CEP INVÁLIDO";
            }
            return RedirectToAction("Create", "Usuarios");
        }



        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario u,bool chkConectado)
        {
            u = UsuarioDAO.Login(u);
            if(u!=null)
            {
                //Logarr
                FormsAuthentication.SetAuthCookie(u.Email,chkConectado);
                return RedirectToAction("Index", "Home");
            }
            //eRRO
            ModelState.AddModelError("", "Algo está errado...");
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Usuarios");
        }

        //ayyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy
    }
}
