using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Models
{
    public class Produto
    {
        [Display(Name = "ID"), Key]
        private int id { get; set; }

        [Display(Name = "Nome"), MaxLength(100)]
        private string nome { get; set; }

        [Display(Name = "Tipo"), Key]
        private string tipo { get; set; }

        [Display(Name = "Desgin"), Key]
        private string design { get; set; }
    }
}