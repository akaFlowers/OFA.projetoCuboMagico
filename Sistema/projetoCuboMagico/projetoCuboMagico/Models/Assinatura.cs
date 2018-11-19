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
        public int Id { get; set; }

        [Display(Name = "ID Cliente")]
        public int IdCliente { get; set; }

        [Display(Name = "Nome"), MaxLength(100)]
        public string Nome { get; set; }

        [Display(Name = "Tipo"), MaxLength(80)]
        public string Tipo { get; set; }

        [Display(Name = "Valor"), MaxLength(10)]
        public decimal Valor { get; set; }

        public Cliente Cliente { get; set; } = new Cliente();
    }
}