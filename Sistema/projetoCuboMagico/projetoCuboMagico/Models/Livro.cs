using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Models
{
    public class Livro
    {
        [Display(Name = "ID"), Key]
        private int id { get; set; }

        [Display(Name = "Nome"), MaxLength(100)]
        private string nome { get; set; }

        [Display(Name = "Autor"), Key]
        private string autor { get; set; }

        [Display(Name = "Gênero"), Key]
        private string idGenero { get; set; }

        [Display(Name = "Data Publicação"), Key]
        private string dataPublicacao { get; set; }

        [Display(Name = "Editora"), Key]
        private string editora { get; set; }
    }
}