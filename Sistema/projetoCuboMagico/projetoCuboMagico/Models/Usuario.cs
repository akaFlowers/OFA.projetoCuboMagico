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
        private int id { get; set; }
  
        [Display(Name = "Usuário"), MinLength(2), MaxLength(50)]
        private string usuario { get; set; }

        [Display(Name = "Senha"), MinLength(5), MaxLength(50)]
        private string senha { get; set; }

        [Display(Name = "Nivel de Acesso"), Key]
        private string nivelAcesso { get; set; }

    }
}