using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Models
{
    public class Cliente
    {
        [Display(Name ="ID"), Key]
        private int id { get; set; }

        [Display(Name = "Nome"), MinLength(3), MaxLength(100)]
        private string nome { get; set; }

        [Display(Name = "Sobrenome"), MinLength(3), MaxLength(100)]
        private string sobrenome { get; set; }

        [Display(Name = "Data Nascimento"), MinLength(3), MaxLength(10)]
        private string dataNascimento { get; set; }

        [Display(Name = "Sexo"), MaxLength(25)]
        private string sexo { get; set; }

        [Display(Name = "Tamanho Camiseta"), MinLength(3), MaxLength(100)]
        private string tamCamisetqa { get; set; }

        [Display(Name = "CPF"), MinLength(3), MaxLength(100)]
        private string cpf { get; set; }

        [Display(Name = "E-mail"), MinLength(10), MaxLength(100)]
        private string email { get; set; }

        [Display(Name = "Telefone"), MaxLength(100)]
        private string telefone { get; set; }

        [Display(Name = "Celular"), MaxLength(15)]
        private string celular { get; set; }

        [Display(Name = "CEP"), MaxLength(9)]
        private string cep { get; set; }

        [Display(Name = "Estado"), MaxLength(50)]
        private string estado { get; set; }

        [Display(Name = "Cidade"), MaxLength(65)]
        private string cidade { get; set; }

        [Display(Name = "Bairro"), MaxLength(65)]
        private string bairro { get; set; }

        [Display(Name = "Rua"), MaxLength(100)]
        private string rua { get; set; }

        [Display(Name = "Número"), MaxLength(10)]
        private string numero { get; set; }

        [Display(Name = "Complemento"), MaxLength(100)]
        private string complemento { get; set; }

        [Display(Name = "País"), MaxLength(70)]
        private string pais { get; set; }

        private string idUsuario { get; set; }

    }
}