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
        public int id { get; set; }

        [Display(Name = "Usuário"), MinLength(2), MaxLength(50)]
        public string usuario { get; set; }

        [Display(Name = "Senha"), MinLength(5), MaxLength(50)]
        public string senha { get; set; }

        [Display(Name = "Nivel de Acesso"), MaxLength(30)]
        public string nivelAcesso;

        public int _id
        {
            get { return id; }
            set { id = value; }
        }

        public string _usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string _senha
        {
            get { return senha; }
            set { senha = value; }
        }

        public string _nivelAcesso
        {
            get { return nivelAcesso; }
            set { nivelAcesso = value; }
        }

    }
}