using MySql.Data.MySqlClient;
using projetoCuboMagico.Persistencia;
using projetoCuboMagico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Repository
{
    public class GenerosRepository
    {
        Conexao conexao = new Conexao();
        MySqlCommand cmd;

        public bool incluirGenero(Genero genero)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_incluirGenero", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@genero", genero.Generoo);
                cmd.Parameters.AddWithValue("@subGenero", genero.SubGenero);
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

        public bool alterarGenero(Genero genero)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_alterarGenero", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", genero.Id);
                cmd.Parameters.AddWithValue("@genero", genero.Generoo);
                cmd.Parameters.AddWithValue("@subGenero", genero.SubGenero);
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


        public bool deletarGenero(int ID)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_deletarGenero", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
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