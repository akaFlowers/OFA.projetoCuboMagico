using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Models
{
    public class Caixa
    {
        [Display(Name = "ID"), Key]
        private int id { get; set; }

        [Display(Name = "Data Gerada")]
        private DateTime dataGerada { get; set; }

        private int idCliente { get; set; }

    }
}