using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Models
{
    public class Livro
    {
        [Display(Name = "ID"), Key]
        private int id;

        [Display(Name = "Nome"), MaxLength(100)]
        private string nome;

        [Display(Name = "Autor"), MaxLength(50)]
        private string autor;

        [Display(Name = "Gênero"), MaxLength(15)]
        private int idGenero;

        [Display(Name = "Data Publicação"), MaxLength(11)]
        private string dataPublicacao;

        [Display(Name = "Editora"), MaxLength(50)]
        private string editora;

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

        public string _autor
        {
            get { return autor; }
            set { autor = value; }
        }

        public int _idGenero
        {
            get { return idGenero; }
            set { idGenero = value; }
        }

        public string _dataPublicacao
        {
            get { return dataPublicacao; }
            set { dataPublicacao = value; }
        }

        public string _editora
        {
            get { return editora; }
            set { editora = value; }
        }
    }
}