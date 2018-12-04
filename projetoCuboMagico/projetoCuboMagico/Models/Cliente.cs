using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Models
{
    public class Cliente
    {
        [Display(Name = "ID"), Key]
        public int Id { get; set; }

        [Display(Name = "Nome"), MaxLength(100)]
        public string Nome { get; set; }

        [Display(Name = "Sobrenome"), MaxLength(100)]
        public string Sobrenome { get; set; }

        [Display(Name = "Data Nascimento"), MaxLength(10)]
        public string DataNascimento { get; set; }

        [Display(Name = "Sexo"), MaxLength(25)]
        public string Sexo { get; set; }

        [Display(Name = "Tamanho Camiseta"), MaxLength(100)]
        public string TamCamiseta { get; set; }

        [Display(Name = "CPF"), MaxLength(100)]
        public string Cpf { get; set; }

        [Display(Name = "E-mail"), MaxLength(100)]
        public string Email { get; set; }

        [Display(Name = "Telefone"), MaxLength(100)]
        public string Telefone { get; set; }

        [Display(Name = "Celular"), MaxLength(15)]
        public string Celular { get; set; }

        [Display(Name = "CEP"), MaxLength(9)]
        public string Cep { get; set; }

        [Display(Name = "Estado"), MaxLength(50)]
        public string Estado { get; set; }

        [Display(Name = "Cidade"), MaxLength(65)]
        public string Cidade { get; set; }

        [Display(Name = "Bairro"), MaxLength(65)]
        public string Bairro { get; set; }

        [Display(Name = "Rua"), MaxLength(100)]
        public string Rua { get; set; }

        [Display(Name = "Numero"), MaxLength(10)]
        public string Numero { get; set; }

        [Display(Name = "Complemento"), MaxLength(100)]
        public string Complemento { get; set; }

        [Display(Name = "País"), MaxLength(70)]
        public string Pais { get; set; }

        public Usuario Usuario { get; set; } = new Usuario();

    }
}