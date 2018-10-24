﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Models
{
    public class Genero
    {
        [Display(Name = "ID"), Key]
        public int Id { get; set; }

        [Display(Name = "Gênero"), MaxLength(50)]
        public string Generoo { get; set; }

        [Display(Name = "Sub-Gênero"), MaxLength(60)]
        public string SubGenero { get; set; }


    }
}