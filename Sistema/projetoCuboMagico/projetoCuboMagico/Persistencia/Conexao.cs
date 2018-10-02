using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace projetoCuboMagico.Persistencia
{
    public class Conexao
    {
        private MySqlConnection conexao = new MySqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString);

        //Construtor
        public Conexao()
        {

        }

        //Getters And Setters
        public MySqlConnection _conexao
        {
            get { return this.conexao; }
            set { this.conexao = value; }
        }

        //Codigo

        public bool abrirConexao()
        {

            try
            {
                if (this.conexao.State == ConnectionState.Closed)
                {
                    this.conexao.Open();

                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }



        }
        public void fecharConexao()
        {
            if (this.conexao.State == ConnectionState.Closed)
            {
                this.conexao.Close();
            }

        }

        public bool testarConexao()
        {
            if (this.conexao != null && conexao.State != ConnectionState.Closed)
                return true;
            else
                return false;

        }
    }
}