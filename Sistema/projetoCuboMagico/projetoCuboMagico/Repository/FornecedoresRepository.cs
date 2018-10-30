using MySql.Data.MySqlClient;
using projetoCuboMagico.Models;
using projetoCuboMagico.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Repository
{
    public class FornecedoresRepository
    {
        Conexao conexao = new Conexao();
        MySqlCommand cmd;

        public bool incluirFornecedor(Fornecedor fornecedor)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_incluirFornecedor", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nome", fornecedor.Nome);
                    cmd.Parameters.AddWithValue("@email", fornecedor.Email);
                    cmd.Parameters.AddWithValue("@telefone", fornecedor.Telefone);
                    cmd.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                    cmd.Parameters.AddWithValue("@pais", fornecedor.Pais);
                    cmd.ExecuteNonQuery();
                    return true;
                }


            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool alterarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_alterarFornecedor", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", fornecedor.Id);
                    cmd.Parameters.AddWithValue("@nome", fornecedor.Nome);
                    cmd.Parameters.AddWithValue("@email", fornecedor.Email);
                    cmd.Parameters.AddWithValue("@telefone", fornecedor.Telefone);
                    cmd.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                    cmd.Parameters.AddWithValue("@pais", fornecedor.Pais);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool deletarFornecedor(int ID)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_deletarFornecedor", Conexao.conexao))
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