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
        public static MySqlConnection conexao = new MySqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString);

        //Construtor
        public Conexao()
        {

        }


        //Codigo

        public bool abrirConexao()
        {

            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();

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
            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Close();
            }

        } 

        public bool testarConexao()
        {
            if (conexao != null && conexao.State != ConnectionState.Closed)
                return true;
            else
                return false;

        }
    }
}