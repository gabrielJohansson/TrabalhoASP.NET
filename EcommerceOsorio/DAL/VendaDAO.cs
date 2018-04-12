using EcommerceOsorio.Models;
using EcommerceOsorio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceOsorio.DAL
{
    public class VendaDAO
    {

        private static Context ctx = Singleton.Instance.Context;
        public static void AddVenda(string cl,string en)
        {
            Venda venda = new Venda
            {
                Data = DateTime.Now,
                Cliente = cl,
                Endereco=en,
                ItemVendaCarrinhoId = Sessao.RetornarCarrinhoId()
            };
            ctx.Vendas.Add(venda);
            ctx.SaveChanges();
        }
    }
}