using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Models
{
    public class GeneroLivro
    {
        [Display(Name = "ID"), Key]
        public int Id { get; set; }

        [Display(Name = "Gênero"), MaxLength(50)]
        public string GeneroLivroo { get; set; }

        [Display(Name = "Sub-Gênero"), MaxLength(60)]
        public string SubGenero { get; set; }


    }
}