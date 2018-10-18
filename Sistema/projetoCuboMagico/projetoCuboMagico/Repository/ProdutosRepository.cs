using MySql.Data.MySqlClient;
using projetoCuboMagico.Models;
using projetoCuboMagico.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Repository
{
    public class ProdutosRepository
    {
        Conexao conexao = new Conexao();
        MySqlCommand cmd;

       
        public bool deletarProduto(int id)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_deletarProduto", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conexao.fecharConexao();
            }
        }




    }
}