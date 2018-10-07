using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Models
{
    public class Genero
    {
        [Display(Name = "ID"), Key]
        private int id;

        [Display(Name = "Gênero"), MaxLength(50)]
        private string genero;

        [Display(Name = "Sub-Gênero"), MaxLength(60)]
        private string subGenero;

        public int _id
        {
            get { return id; }
            set { id = value; }
        }

        public string _genero
        {
            get { return genero; }
            set { genero = value; }
        }

        public string _subGenero
        {
            get { return subGenero; }
            set { subGenero = value; }
        }

    }
}