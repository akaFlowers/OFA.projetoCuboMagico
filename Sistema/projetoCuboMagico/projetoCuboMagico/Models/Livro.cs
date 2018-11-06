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
        public int Id { get; set; }

        [Display(Name = "Nome"), MaxLength(100)]
        public string Nome { get; set; }

        [Display(Name = "Autor"), MaxLength(50)]
        public string Autor { get; set; }

        [Display(Name = "Gênero"), MaxLength(15)]
        public string IdGeneroLivro { get; set; }

        [Display(Name = "Data Publicação"), MaxLength(11)]
        public string DataPublicacao { get; set; }

        [Display(Name = "Editora"), MaxLength(50)]
        public string Editora { get; set; }

    }
}