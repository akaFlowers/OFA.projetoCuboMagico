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

        public bool incluirGeneroLivro(GeneroLivro genero)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_incluirGeneroLivro", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@generoLivro", genero.GeneroLivroo);
                    cmd.Parameters.AddWithValue("@subGenero", genero.SubGenero);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool alterarGeneroLivro(GeneroLivro genero)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_alterarGeneroLivro", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", genero.Id);
                    cmd.Parameters.AddWithValue("@generoLivro", genero.GeneroLivroo);
                    cmd.Parameters.AddWithValue("@subGenero", genero.SubGenero);
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public bool deletarGeneroLivro(int ID)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_deletarGeneroLivro", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}