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
        private int id;

        [Display(Name = "Nome"), MaxLength(100)]
        private string nome;

        [Display(Name = "Tipo"), MaxLength(30)]
        private string tipo;

        [Display(Name = "Desgin"), MaxLength(30)]
        private string design;

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

        public string _tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string _design
        {
            get { return design; }
            set { design = value; }
        }


    }
}