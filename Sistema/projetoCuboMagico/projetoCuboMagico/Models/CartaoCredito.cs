using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Models
{
    public class CartaoCredito
    {
        [Display(Name = "Nome Impresso"), MaxLength(100)]
        public string NomeImpresso { get; set; }

        [Display(Name = "Número"), MaxLength(50)]
        public string Numero { get; set; }

        [Display(Name = "CPF"), MaxLength(15)]
        public string Cpf { get; set; }

        [Display(Name = "Validade"), MaxLength(6)]
        public string Validade { get; set; }

        [Display(Name = "CVV"), MaxLength(5)]
        public string Cvv { get; set; }




    }
}