using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceOsorio.Models
{
    public class Usuario
    {
        [Key]
        public int ID_Usuario { get; set; }
        public string Nome { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        [DataType(DataType.Password)]
        [Compare("Senha",ErrorMessage ="Campos não batem")]
        [NotMapped]
        public string ConfirmacaoSenha { get; set; }
    }
}