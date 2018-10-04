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
        private int id { get; set; }

        [Display(Name = "Gênero"), MaxLength(50)]
        private string genero { get; set; }

        [Display(Name = "Sub-Gênero"), MaxLength(60)]
        private string subGenero { get; set; }

    }
}