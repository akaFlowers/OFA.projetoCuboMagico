using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Models
{
    public class Gerente
    {
        [Display(Name = "ID"), Key]
        public int Id { get; set; }

        [Display(Name = "Nome Completo"), MaxLength(110)]
        public string NomeCompleto { get; set; }

        [Display(Name = "Data Nascimento"), MaxLength(10)]
        public string DataNascimento { get; set; }

        [Display(Name = "Sexo"), MaxLength(10)]
        public string Sexo { get; set; }

        [Display(Name = "CPF"), MaxLength(15)]
        public string Cpf { get; set; }

        [Display(Name = "E-Mail"), MaxLength(100)]
        public string Email { get; set; }

        [Display(Name = "Telefone"), MaxLength(14)]
        public string Telefone { get; set; }

        [Display(Name = "Celular"), MaxLength(15)]
        public string Celular { get; set; }

        [Display(Name = "Endereço"), MaxLength(120)]
        public string Endereco { get; set; }

        public int IdUsuario { get; set; }

        public Usuario usuario { get; set; }


    }
}