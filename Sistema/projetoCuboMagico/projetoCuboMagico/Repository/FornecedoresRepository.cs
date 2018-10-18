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
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_incluirFornecedor", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nome", fornecedor._nome);
                cmd.Parameters.AddWithValue("@email", fornecedor._email);
                cmd.Parameters.AddWithValue("@telefone", fornecedor._telefone);
                cmd.Parameters.AddWithValue("@cnpj", fornecedor._cnpj);
                cmd.Parameters.AddWithValue("@pais", fornecedor._pais);
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

        public bool alterarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_alterarFornecedor", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", fornecedor._id);
                cmd.Parameters.AddWithValue("@nome", fornecedor._nome);
                cmd.Parameters.AddWithValue("@email", fornecedor._email);
                cmd.Parameters.AddWithValue("@telefone", fornecedor._telefone);
                cmd.Parameters.AddWithValue("@cnpj", fornecedor._cnpj);
                cmd.Parameters.AddWithValue("@pais", fornecedor._pais);
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

        public bool deletarFornecedor(int ID)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_deletarFornecedor", Conexao.conexao);
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