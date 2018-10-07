using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Models
{
    public class Caixa
    {
        [Display(Name = "ID"), Key]
        private int id;

        [Display(Name = "Data Gerada")]
        private DateTime dataGerada;

        private int idCliente;

        public int _id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime _dataGerada
        {
            get { return dataGerada; }
            set { dataGerada = value; }
        }

        public int _idCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

    }
}