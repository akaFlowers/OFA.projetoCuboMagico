using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Models
{
    public class LivroCaixa
    {
        private int idCaixa;
        private int idLivro;

        public int _idCaixa
        {
            get { return idCaixa; }
            set { idCaixa = value; }
        }

        public int _idLivro
        {
            get { return idLivro; }
            set { idLivro = value; }
        }



    }
}