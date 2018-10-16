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
        private string nomeImpresso;

        [Display(Name = "Número"), MaxLength(50)]
        private string numero;

        [Display(Name = "CPF"), MaxLength(15)]
        private string cpf;

        [Display(Name = "Validade"), MaxLength(6)]
        private string validade;

        [Display(Name = "CVV"), MaxLength(5)]
        private string cvv;

        public string _nomeImpresso
        {
            get { return nomeImpresso; }
            set { nomeImpresso = value; }
        }

        public string _cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }


        public string _numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string _validade
        {
            get { return validade; }
            set { validade = value; }
        }

        public string _cvv
        {
            get { return cvv; }
            set { cvv = value; }
        }


    }
}