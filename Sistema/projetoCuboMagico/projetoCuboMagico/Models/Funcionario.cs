using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Models
{
    public class Funcionario
    {
        [Display(Name = "ID"), Key]
        private int id { get; set; }

        [Display(Name = "Nome Completo"), MaxLength(110)]
        private string nomeCompleto { get; set; }

        [Display(Name = "Data Nascimento"), MaxLength(10)]
        private string dataNascimento { get; set; }

        [Display(Name = "Sexo"), MaxLength(10)]
        private string sexo { get; set; }

        [Display(Name = "CPF"), MaxLength(15)]
        private string cpf { get; set; }

        [Display(Name = "E-Mail"), MaxLength(100)]
        private string email { get; set; }

        [Display(Name = "Telefone"), MaxLength(14)]
        private string telefone { get; set; }

        [Display(Name = "Celular"), MaxLength(15)]
        private string celular { get; set; }

        [Display(Name = "Endereço"), MaxLength(15)]
        private string endereco { get; set; }

        private string idUsuario { get; set; }

    }
}