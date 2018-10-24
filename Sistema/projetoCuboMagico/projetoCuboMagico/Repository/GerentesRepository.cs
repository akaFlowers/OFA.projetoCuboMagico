using MySql.Data.MySqlClient;
using projetoCuboMagico.Models;
using projetoCuboMagico.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Repository
{
    public class GerentesRepository
    {

        Conexao conexao = new Conexao();
        MySqlCommand cmd;

        public bool incluirGerente(Gerente gerente)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_incluirGerente", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nomeCompleto", gerente.NomeCompleto);
                cmd.Parameters.AddWithValue("@dataNascimento", gerente.DataNascimento);
                cmd.Parameters.AddWithValue("@sexo", gerente.Sexo);
                cmd.Parameters.AddWithValue("@cpf", gerente.Cpf);
                cmd.Parameters.AddWithValue("@email", gerente.Email);
                cmd.Parameters.AddWithValue("@telefone", gerente.Telefone);
                cmd.Parameters.AddWithValue("@celular", gerente.Celular);
                cmd.Parameters.AddWithValue("@endereco", gerente.Endereco);
                cmd.Parameters.AddWithValue("@idUsuario", gerente.IdUsuario);
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

        public bool deletarGerente(int ID)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_deletarGerente", Conexao.conexao);
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

        public bool alterarGerente(Gerente gerente)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_alterarFuncionari", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", gerente.Id);
                cmd.Parameters.AddWithValue("@nomeCompleto", gerente.NomeCompleto);
                cmd.Parameters.AddWithValue("@dataNascimento", gerente.DataNascimento);
                cmd.Parameters.AddWithValue("@sexo", gerente.Sexo);
                cmd.Parameters.AddWithValue("@cpf", gerente.Cpf);
                cmd.Parameters.AddWithValue("@email", gerente.Email);
                cmd.Parameters.AddWithValue("@telefone", gerente.Telefone);
                cmd.Parameters.AddWithValue("@celular", gerente.Celular);
                cmd.Parameters.AddWithValue("@endereco", gerente.Endereco);
                cmd.Parameters.AddWithValue("@idUsuario", gerente.IdUsuario);
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