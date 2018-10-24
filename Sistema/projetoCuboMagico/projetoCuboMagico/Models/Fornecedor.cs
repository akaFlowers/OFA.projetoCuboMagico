using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Models
{
    public class Fornecedor
    {
        [Display(Name = "ID"), Key]
        public int Id { get; set; }

        [Display(Name = "Nome"), MaxLength(100)]
        public string Nome { get; set; }

        [Display(Name = "E-Mail"), MaxLength(100)]
        public string Email { get; set; }

        [Display(Name = "Telefone "), MaxLength(14)]
        public string Telefone { get; set; }

        [Display(Name = "CNPJ"), Key]
        public string Cnpj { get; set; }

        [Display(Name = "País"), Key]
        public string Pais { get; set; }

       
    }
}