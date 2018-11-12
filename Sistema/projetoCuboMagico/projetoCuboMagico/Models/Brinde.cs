using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Models
{
    public class Brinde
    {
        [Display(Name = "ID"), Key]
        public int Id { get; set; }

        [Display(Name = "Nome"), MaxLength(100)]
        public string Nome { get; set; }

        [Display(Name = "Tipo"), MaxLength(100)]
        public string Tipo { get; set; }

        [Display(Name = "Design"), MaxLength(100)]
        public string Design { get; set; }
    }
}