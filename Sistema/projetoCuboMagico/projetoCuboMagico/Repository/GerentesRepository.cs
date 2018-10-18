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
                cmd.Parameters.AddWithValue("@nomeCompleto", gerente._nomeCompleto);
                cmd.Parameters.AddWithValue("@dataNascimento", gerente._dataNascimento);
                cmd.Parameters.AddWithValue("@sexo", gerente._sexo);
                cmd.Parameters.AddWithValue("@cpf", gerente._cpf);
                cmd.Parameters.AddWithValue("@email", gerente._email);
                cmd.Parameters.AddWithValue("@telefone", gerente._telefone);
                cmd.Parameters.AddWithValue("@celular", gerente._celular);
                cmd.Parameters.AddWithValue("@endereco", gerente._endereco);
                cmd.Parameters.AddWithValue("@idUsuario", gerente._idUsuario);
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
                cmd.Parameters.AddWithValue("@ID", gerente._id);
                cmd.Parameters.AddWithValue("@nomeCompleto", gerente._nomeCompleto);
                cmd.Parameters.AddWithValue("@dataNascimento", gerente._dataNascimento);
                cmd.Parameters.AddWithValue("@sexo", gerente._sexo);
                cmd.Parameters.AddWithValue("@cpf", gerente._cpf);
                cmd.Parameters.AddWithValue("@email", gerente._email);
                cmd.Parameters.AddWithValue("@telefone", gerente._telefone);
                cmd.Parameters.AddWithValue("@celular", gerente._celular);
                cmd.Parameters.AddWithValue("@endereco", gerente._endereco);
                cmd.Parameters.AddWithValue("@idUsuario", gerente._idUsuario);
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