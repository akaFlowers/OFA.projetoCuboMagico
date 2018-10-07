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
        private int id;

        [Display(Name = "Nome"), MaxLength(100)]
        private string nome;

        [Display(Name = "E-Mail"), MaxLength(100)]
        private string email;

        [Display(Name = "Telefone "), MaxLength(14)]
        private string telefone;

        [Display(Name = "CNPJ"), Key]
        private string cnpj;

        [Display(Name = "País"), Key]
        private string pais;

        public int _id
        {
            get { return id; }
            set { id = value; }
        }

        public string _nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string _email
        {
            get { return email; }
            set { email = value; }
        }

        public string _telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        public string _cnpj
        {
            get { return cnpj; }
            set { cnpj = value; }
        }

        public string _pais
        {
            get { return pais; }
            set { pais = value; }
        }
    }
}