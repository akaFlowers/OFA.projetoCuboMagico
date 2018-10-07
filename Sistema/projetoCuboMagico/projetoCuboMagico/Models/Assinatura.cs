using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Models
{
    public class Assinatura
    {
        [Display(Name = "ID"), Key]
        private int id { get; set; }

        [Display(Name = "Nome"), MaxLength(100)]
        private string name { get; set; }

        [Display(Name = "Tipo"), MaxLength(80)]
        private string tipo { get; set; }

        [Display(Name = "Valor"), MaxLength(6)]
        private decimal valor { get; set; }

    }
}