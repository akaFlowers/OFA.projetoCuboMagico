using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Models
{
    public class ProdutoCaixa
    {
        private int idCaixa;
        private int idProduto;

        public int _idCaixa
        {
            get { return  idCaixa; }
            set { idCaixa = value; }
        }

        public int _idProduto
        {
            get { return idProduto; }
            set { idProduto = value; }
        }

    }
}