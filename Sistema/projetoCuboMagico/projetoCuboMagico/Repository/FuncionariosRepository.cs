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
                cmd.Parameters.AddWithValue("@nomeCompleto", funcionario.NomeCompleto);
                cmd.Parameters.AddWithValue("@dataNascimento", funcionario.DataNascimento);
                cmd.Parameters.AddWithValue("@sexo", funcionario.Sexo);
                cmd.Parameters.AddWithValue("@cpf", funcionario.Cpf);
                cmd.Parameters.AddWithValue("@email", funcionario.Email);
                cmd.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                cmd.Parameters.AddWithValue("@celular", funcionario.Celular);
                cmd.Parameters.AddWithValue("@endereco", funcionario.Endereco);
                cmd.Parameters.AddWithValue("@idUsuario", funcionario.IdUsuario);
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
                cmd.Parameters.AddWithValue("@ID", funcionario.Id);
                cmd.Parameters.AddWithValue("@nomeCompleto", funcionario.NomeCompleto);
                cmd.Parameters.AddWithValue("@dataNascimento", funcionario.DataNascimento);
                cmd.Parameters.AddWithValue("@sexo", funcionario.Sexo);
                cmd.Parameters.AddWithValue("@cpf", funcionario.Cpf);
                cmd.Parameters.AddWithValue("@email", funcionario.Email);
                cmd.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                cmd.Parameters.AddWithValue("@celular", funcionario.Celular);
                cmd.Parameters.AddWithValue("@endereco", funcionario.Endereco);
                cmd.Parameters.AddWithValue("@idUsuario", funcionario.IdUsuario);
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