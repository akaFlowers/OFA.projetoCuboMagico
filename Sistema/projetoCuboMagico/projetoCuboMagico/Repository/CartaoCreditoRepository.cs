using MySql.Data.MySqlClient;
using projetoCuboMagico.Models;
using projetoCuboMagico.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Repository
{
    public class CartaoCreditoRepository
    {
        Conexao conexao = new Conexao();
        MySqlCommand cmd;

        public bool incluirCartaoCredito(CartaoCredito cartaoCredito)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_incluirCartaoCredito", Conexao.conexao);
                cmd.Parameters.AddWithValue("@nomeImpresso", cartaoCredito._nomeImpresso);
                cmd.Parameters.AddWithValue("@cpf", cartaoCredito._cpf);
                cmd.Parameters.AddWithValue("@validade", cartaoCredito._validade);
                cmd.Parameters.AddWithValue("@cvv", cartaoCredito._cvv);
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

        public bool alterarCartaoCredito(CartaoCredito cartaoCredito)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_alterarCartaoCredito", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nomeImpresso", cartaoCredito._nomeImpresso);
                cmd.Parameters.AddWithValue("@numero", cartaoCredito._numero);
                cmd.Parameters.AddWithValue("@cpf", cartaoCredito._cpf);
                cmd.Parameters.AddWithValue("@validade", cartaoCredito._validade);
                cmd.Parameters.AddWithValue("cvv", cartaoCredito._cvv);
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

        public bool deletarCartaoCredito(int ID)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_deletarCartaoCredito", Conexao.conexao);
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