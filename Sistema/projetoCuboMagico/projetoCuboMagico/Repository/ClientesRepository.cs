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
        MySqlDataReader dr;

        public IEnumerable<Cliente> listarTodos()
        {
            List<Cliente> cliente = new List<Cliente>();
            try
            {
                using (cmd = new MySqlCommand("SP_listarTodosClientes", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Cliente clientes = new Cliente();
                        clientes.Id = Convert.ToInt32(dr["id"]);
                        clientes.Nome = dr["nome"].ToString();
                        clientes.Sobrenome = dr["sobrenome"].ToString();
                        clientes.DataNascimento = dr["dataNascimento"].ToString();
                        clientes.Sexo = dr["sexo"].ToString();
                        clientes.TamCamiseta = dr["tamCamiseta"].ToString();
                        clientes.Cpf = dr["cpf"].ToString();
                        clientes.Email = dr["Email"].ToString();
                        clientes.Telefone = dr["telefone"].ToString();
                        clientes.Celular = dr["celular"].ToString();
                        clientes.Estado = dr["estado"].ToString();
                        clientes.Cidade = dr["cidade"].ToString();
                        clientes.Bairro = dr["bairro"].ToString();
                        clientes.Rua = dr["rua"].ToString();
                        clientes.Numero = dr["numero"].ToString();
                        clientes.Complemento = dr["complemento"].ToString();
                        clientes.Pais = dr["pais"].ToString();
                        clientes.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                        cliente.Add(clientes);
                    }
                }               
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);

            }
            finally
            {
                dr.Close();
            }
            return cliente;
        }

        public Cliente consultaPorID(int id)
        {
            Cliente cliente = new Cliente();
            try
            {
                using (cmd = new MySqlCommand("SELECT * FROM Cliente WHERE Cliente.id = @id", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.Parameters.AddWithValue("@id", id);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        cliente.Id = Convert.ToInt32(dr["id"]);
                        cliente.Nome = dr["nome"].ToString();
                        cliente.Sobrenome = dr["sobrenome"].ToString();
                        cliente.DataNascimento = dr["dataNascimento"].ToString();
                        cliente.Sexo = dr["sexo"].ToString();
                        cliente.TamCamiseta = dr["tamCamiseta"].ToString();
                        cliente.Cpf = dr["cpf"].ToString();
                        cliente.Email = dr["Email"].ToString();
                        cliente.Telefone = dr["telefone"].ToString();
                        cliente.Celular = dr["celular"].ToString();
                        cliente.Cep = dr["cep"].ToString();
                        cliente.Estado = dr["estado"].ToString();
                        cliente.Cidade = dr["cidade"].ToString();
                        cliente.Bairro = dr["bairro"].ToString();
                        cliente.Rua = dr["rua"].ToString();
                        cliente.Numero = dr["numero"].ToString();
                        cliente.Complemento = dr["complemento"].ToString();
                        cliente.Pais = dr["pais"].ToString();
                        cliente.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                    }            
                }
                return cliente;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                dr.Close();
            }
        }


        public bool incluirCliente(Cliente cliente)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_incluirCliente", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@sobrenome", cliente.Sobrenome);
                    cmd.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento);
                    cmd.Parameters.AddWithValue("@sexo", cliente.Sexo);
                    cmd.Parameters.AddWithValue("@tamCamiseta", cliente.TamCamiseta);
                    cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
                    cmd.Parameters.AddWithValue("email", cliente.Email);
                    cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);
                    cmd.Parameters.AddWithValue("@celular", cliente.Celular);
                    cmd.Parameters.AddWithValue("@cep", cliente.Cep);
                    cmd.Parameters.AddWithValue("@estado", cliente.Estado);
                    cmd.Parameters.AddWithValue("@cidade", cliente.Cidade);
                    cmd.Parameters.AddWithValue("@bairro", cliente.Bairro);
                    cmd.Parameters.AddWithValue("@rua", cliente.Rua);
                    cmd.Parameters.AddWithValue("@numero", cliente.Numero);
                    cmd.Parameters.AddWithValue("@complemento", cliente.Complemento);
                    cmd.Parameters.AddWithValue("@pais", cliente.Pais);
                    cmd.Parameters.AddWithValue("@idUsuario", trazerIdUsuario());
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool alterarCliente(Cliente cliente)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_alterarCliente", Conexao.conexao))
                {
                    conexao.abrirConexao();

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", cliente.Id);
                    cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@sobrenome", cliente.Sobrenome);
                    cmd.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento);
                    cmd.Parameters.AddWithValue("@sexo", cliente.Sexo);
                    cmd.Parameters.AddWithValue("@tamCamiseta", cliente.TamCamiseta);
                    cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
                    cmd.Parameters.AddWithValue("email", cliente.Email);
                    cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);
                    cmd.Parameters.AddWithValue("@celular", cliente.Celular);
                    cmd.Parameters.AddWithValue("@cep", cliente.Cep);
                    cmd.Parameters.AddWithValue("@estado", cliente.Estado);
                    cmd.Parameters.AddWithValue("@cidade", cliente.Cidade);
                    cmd.Parameters.AddWithValue("@bairro", cliente.Bairro);
                    cmd.Parameters.AddWithValue("@rua", cliente.Rua);
                    cmd.Parameters.AddWithValue("@numero", cliente.Numero);
                    cmd.Parameters.AddWithValue("@complemento", cliente.Complemento);
                    cmd.Parameters.AddWithValue("@pais", cliente.Pais);
                    cmd.Parameters.AddWithValue("@idUsuario", cliente.IdUsuario);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool deletarCliente(int id)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_deletarCliente", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                    return true;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public int trazerIdUsuario()
        {
            try
            {
                using (cmd = new MySqlCommand("SELECT COUNT(id) AS ID FROM Usuario", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        return Convert.ToInt32(dr["ID"]);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                dr.Close();
            }
        }
    }
}