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
        private int id;

        [Display(Name = "Nome Completo"), MaxLength(110)]
        private string nomeCompleto;

        [Display(Name = "Data Nascimento"), MaxLength(10)]
        private string dataNascimento;

        [Display(Name = "Sexo"), MaxLength(10)]
        private string sexo;

        [Display(Name = "CPF"), MaxLength(15)]
        private string cpf;

        [Display(Name = "E-Mail"), MaxLength(100)]
        private string email;

        [Display(Name = "Telefone"), MaxLength(14)]
        private string telefone;

        [Display(Name = "Celular"), MaxLength(15)]
        private string celular;

        [Display(Name = "Endereço"), MaxLength(120)]
        private string endereco;

        private int idUsuario;

        public int _id
        {
            get { return id; }
            set { id = value; }
        }

        public string _nomeCompleto
        {
            get { return nomeCompleto; }
            set { nomeCompleto = value; }
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

        public string _endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        public int _idUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

    }
}