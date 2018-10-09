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
        private int id;

        [Display(Name = "Nome"), MinLength(3), MaxLength(100)]
        private string nome;

        [Display(Name = "Sobrenome"), MinLength(3), MaxLength(100)]
        private string sobrenome;

        [Display(Name = "Data Nascimento"), MinLength(3), MaxLength(10)]
        private string dataNascimento;

        [Display(Name = "Sexo"), MaxLength(25)]
        private string sexo;

        [Display(Name = "Tamanho Camiseta"), MinLength(3), MaxLength(100)]
        private string tamCamiseta;

        [Display(Name = "CPF"), MinLength(3), MaxLength(100)]
        private string cpf;

        [Display(Name = "E-mail"), MinLength(10), MaxLength(100)]
        private string email;

        [Display(Name = "Telefone"), MaxLength(100)]
        private string telefone;

        [Display(Name = "Celular"), MaxLength(15)]
        private string celular;

        [Display(Name = "CEP"), MaxLength(9)]
        private string cep;

        [Display(Name = "Estado"), MaxLength(50)]
        private string estado;

        [Display(Name = "Cidade"), MaxLength(65)]
        private string cidade;

        [Display(Name = "Bairro"), MaxLength(65)]
        private string bairro;

        [Display(Name = "Rua"), MaxLength(100)]
        private string rua;

        [Display(Name = "Número"), MaxLength(10)]
        private string numero;

        [Display(Name = "Complemento"), MaxLength(100)]
        private string complemento;

        [Display(Name = "País"), MaxLength(70)]
        private string pais;

        private int idUsuario;

        public int _id
        {
            get { return id; }
            set { id = value; }
        }

        public string _nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string _sobrenome
        {
            get { return sobrenome; }
            set { sobrenome = value; }
        }

        public string _dataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; } 
        }

        public string _sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public string _tamCamiseta
        {
            get { return tamCamiseta; }
            set { tamCamiseta = value; }
        }

        public string _cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public string _email
        {
            get { return email; }
            set { email = value; }
        }

        public string _telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        public string _celular
        {
            get { return celular; }
            set { celular = value; }
        }

        public string _cep
        {
            get { return cep; }
            set { cep = value; }
        }

        public string _estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string _cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        public string _bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        public string _rua
        {
            get { return rua; }
            set { rua = value; }
        }

        public string _numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string _complemento
        {
            get { return complemento; }
            set { complemento = value; }
        }

        public string _pais
        {
            get { return pais; }
            set { pais = value; }
        }

        public int _idUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
    }
}