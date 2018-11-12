using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Models
{
    public class Unboxing
    {
        [Display(Name = "ID"), Key]
        public int Id { get; set; }

        [Display(Name = "Data Gerada")]
        public DateTime DataGerada { get; set; }

        public int IdCliente { get; set; }

        public LivroUnboxing livroUnboxing { get; set; }

        public BrindeUnboxing brindeUnboxing { get; set; }

    }
}