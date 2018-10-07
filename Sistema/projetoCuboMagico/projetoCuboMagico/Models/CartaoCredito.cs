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
        private string nomeImpresso { get; set; }

        [Display(Name = "CPF"), MaxLength(15)]
        private string cpf { get; set; }

        [Display(Name = "Validade"), MaxLength(6)]
        private string validade { get; set; }

        [Display(Name = "CVV"), MaxLength(5)]
        private string cvv { get; set; }

    }
}