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
        private int id { get; set; }

        [Display(Name = "Nome"), MaxLength(100)]
        private string nome { get; set; }

        [Display(Name = "E-Mail"), MaxLength(100)]
        private string email { get; set; }

        [Display(Name = "Telefone "), MaxLength(14)]
        private string telefone { get; set; }

        [Display(Name = "CNPJ"), Key]
        private string cnpj { get; set; }

        [Display(Name = "País"), Key]
        private string pais { get; set; }
    }
}