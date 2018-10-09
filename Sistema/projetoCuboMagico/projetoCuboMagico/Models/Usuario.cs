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
        private int id;

        [Display(Name = "Usuário"), MinLength(2), MaxLength(50)]
        private string usuario;

        [Display(Name = "Senha"), MinLength(5), MaxLength(50)]
        private string senha;

        [Display(Name = "Nivel de Acesso"), MaxLength(30)]
        private string nivelAcesso;

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