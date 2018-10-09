using MySql.Data.MySqlClient;
using projetoCuboMagico.Models;
using projetoCuboMagico.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Repository
{
    public class ClientesRepository
    {
        Conexao conexao = new Conexao();
        MySqlCommand cmd;
        public bool incluirCliente(Cliente cliente)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_incluirCliente", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nome", cliente._nome);
                cmd.Parameters.AddWithValue("@sobrenome", cliente._sobrenome);
                cmd.Parameters.AddWithValue("@dataNascimento", cliente._dataNascimento);
                cmd.Parameters.AddWithValue("@sexo", cliente._sexo);
                cmd.Parameters.AddWithValue("@tamCamiseta", cliente._tamCamiseta);
                cmd.Parameters.AddWithValue("@cpf", cliente._cpf);
                cmd.Parameters.AddWithValue("email", cliente._email);
                cmd.Parameters.AddWithValue("@telefone", cliente._telefone);
                cmd.Parameters.AddWithValue("@celular", cliente._celular);
                cmd.Parameters.AddWithValue("@cep", cliente._cep);
                cmd.Parameters.AddWithValue("@estado", cliente._estado);
                cmd.Parameters.AddWithValue("@cidade", cliente._cidade);
                cmd.Parameters.AddWithValue("@bairro", cliente._bairro);
                cmd.Parameters.AddWithValue("@rua", cliente._rua);
                cmd.Parameters.AddWithValue("@numero", cliente._numero);
                cmd.Parameters.AddWithValue("@complemento", cliente._complemento);
                cmd.Parameters.AddWithValue("@pais", cliente._pais);
                cmd.Parameters.AddWithValue("@idUsuario", cliente._idUsuario);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch(Exception)
            {
                return false;
            }
            finally
            {
                conexao.fecharConexao();
            }
        }

        public bool alterarUsuario(Cliente cliente)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_alterarCliente", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", cliente._id);
                cmd.Parameters.AddWithValue("@nome", cliente._nome);
                cmd.Parameters.AddWithValue("@sobrenome", cliente._sobrenome);
                cmd.Parameters.AddWithValue("@dataNascimento", cliente._dataNascimento);
                cmd.Parameters.AddWithValue("@sexo", cliente._sexo);
                cmd.Parameters.AddWithValue("@tamCamiseta", cliente._tamCamiseta);
                cmd.Parameters.AddWithValue("@cpf", cliente._cpf);
                cmd.Parameters.AddWithValue("email", cliente._email);
                cmd.Parameters.AddWithValue("@telefone", cliente._telefone);
                cmd.Parameters.AddWithValue("@celular", cliente._celular);
                cmd.Parameters.AddWithValue("@cep", cliente._cep);
                cmd.Parameters.AddWithValue("@estado", cliente._estado);
                cmd.Parameters.AddWithValue("@cidade", cliente._cidade);
                cmd.Parameters.AddWithValue("@bairro", cliente._bairro);
                cmd.Parameters.AddWithValue("@rua", cliente._rua);
                cmd.Parameters.AddWithValue("@numero", cliente._numero);
                cmd.Parameters.AddWithValue("@complemento", cliente._complemento);
                cmd.Parameters.AddWithValue("@pais", cliente._pais);
                cmd.Parameters.AddWithValue("@idUsuario", cliente._idUsuario);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            finally
            {
                conexao.fecharConexao();
            }
        }

        public bool deletarCliente(int id)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_deletarCliente", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
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