using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Models
{
    public class Usuario
    {
        [Display(Name = "ID"), Key]
        public int Id { get; set; }

        [Display(Name = "Usuário"), MaxLength(50)]
        public string Usuarioo { get; set; }

        [Display(Name = "Senha"),  MaxLength(50)]
        public string Senha { get; set; }

        [Display(Name = "Nivel de Acesso"), MaxLength(30)]
        public string NivelAcesso { get; set; }

    }
}