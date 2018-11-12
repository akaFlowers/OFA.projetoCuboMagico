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
                using (cmd = new MySqlCommand("SP_incluirCartaoCredito", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.Parameters.AddWithValue("@nomeImpresso", cartaoCredito.NomeImpresso);
                    cmd.Parameters.AddWithValue("@numero", cartaoCredito.Numero);
                    cmd.Parameters.AddWithValue("@cpf", cartaoCredito.Cpf);
                    cmd.Parameters.AddWithValue("@validade", cartaoCredito.Validade);
                    cmd.Parameters.AddWithValue("@cvv", cartaoCredito.Cvv);
                    cmd.ExecuteNonQuery();
                    return true;
                }

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool alterarCartaoCredito(CartaoCredito cartaoCredito)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_alterarCartaoCredito", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nomeImpresso", cartaoCredito.NomeImpresso);
                    cmd.Parameters.AddWithValue("@numero", cartaoCredito.Numero);
                    cmd.Parameters.AddWithValue("@cpf", cartaoCredito.Cpf);
                    cmd.Parameters.AddWithValue("@validade", cartaoCredito.Validade);
                    cmd.Parameters.AddWithValue("cvv", cartaoCredito.Cvv);
                    cmd.ExecuteNonQuery();
                    return true;
                }


            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool deletarCartaoCredito(int ID)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_deletarCartaoCredito", Conexao.conexao))
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