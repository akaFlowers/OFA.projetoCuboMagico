using MySql.Data.MySqlClient;
using projetoCuboMagico.Models;
using projetoCuboMagico.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Repository
{
    public class FuncionariosRepository
    {
        Conexao conexao = new Conexao();
        MySqlCommand cmd;

        public bool incluirFuncionario(Funcionario funcionario)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_incluirFuncionario", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nomeCompleto", funcionario._nomeCompleto);
                cmd.Parameters.AddWithValue("@dataNascimento", funcionario._dataNascimento);
                cmd.Parameters.AddWithValue("@sexo", funcionario._sexo);
                cmd.Parameters.AddWithValue("@cpf", funcionario._cpf);
                cmd.Parameters.AddWithValue("@email", funcionario._email);
                cmd.Parameters.AddWithValue("@telefone", funcionario._telefone);
                cmd.Parameters.AddWithValue("@celular", funcionario._celular);
                cmd.Parameters.AddWithValue("@endereco", funcionario._endereco);
                cmd.Parameters.AddWithValue("@idUsuario", funcionario._idUsuario);
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

        public bool deletarFuncionario(int ID)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_deletarFuncionario", Conexao.conexao);
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

        public bool alterarFuncionario(Funcionario funcionario)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_alterarFuncionari", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", funcionario._id);
                cmd.Parameters.AddWithValue("@nomeCompleto", funcionario._nomeCompleto);
                cmd.Parameters.AddWithValue("@dataNascimento", funcionario._dataNascimento);
                cmd.Parameters.AddWithValue("@sexo", funcionario._sexo);
                cmd.Parameters.AddWithValue("@cpf", funcionario._cpf);
                cmd.Parameters.AddWithValue("@email", funcionario._email);
                cmd.Parameters.AddWithValue("@telefone", funcionario._telefone);
                cmd.Parameters.AddWithValue("@celular", funcionario._celular);
                cmd.Parameters.AddWithValue("@endereco", funcionario._endereco);
                cmd.Parameters.AddWithValue("@idUsuario", funcionario._idUsuario);
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