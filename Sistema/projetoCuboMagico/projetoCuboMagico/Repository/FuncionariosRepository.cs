using MySql.Data.MySqlClient;
using projetoCuboMagico.Models;
using projetoCuboMagico.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Repository
{
    public class FuncionariosRepository
    {
        Conexao conexao = new Conexao();
        MySqlCommand cmd;
        MySqlDataReader dr;



        public IEnumerable<Funcionario> listarTodos()
        {
            List<Funcionario> funcionario = new List<Funcionario>();
            try
            {
                using (cmd = new MySqlCommand("SP_listarTodosFuncionarios", Conexao.conexao))
                {
                    conexao.abrirConexao();

                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Funcionario funcionarios = new Funcionario();
                        funcionarios.Id = Convert.ToInt32(dr["id"]);
                        funcionarios.NomeCompleto = dr["nomeCompleto"].ToString();
                        funcionarios.DataNascimento = dr["dataNascimento"].ToString();
                        funcionarios.Sexo = dr["sexo"].ToString();
                        funcionarios.Cpf = dr["cpf"].ToString();
                        funcionarios.Email = dr["email"].ToString();
                        funcionarios.Telefone = dr["telefone"].ToString();
                        funcionarios.Celular = dr["celular"].ToString();
                        funcionarios.Endereco = dr["endereco"].ToString();
                        funcionarios.IdUsuario = Convert.ToInt32(dr["idUsuario"]);

                        funcionario.Add(funcionarios);
                    }
                }             
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                dr.Close();
            }
            return funcionario;
        }

        public Funcionario consultaPorID(int id)
        {
            Funcionario funcionario = new Funcionario();
            try
            {
                using (cmd = new MySqlCommand("SELECT * FROM Funcionario WHERE Funcionario.id = @id", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.Parameters.AddWithValue("@id", id);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Funcionario funcionarios = new Funcionario();
                        funcionarios.Id = Convert.ToInt32(dr["id"]);
                        funcionarios.NomeCompleto = dr["nomeCompleto"].ToString();
                        funcionarios.DataNascimento = dr["dataNascimento"].ToString();
                        funcionarios.Sexo = dr["sexo"].ToString();
                        funcionarios.Cpf = dr["cpf"].ToString();
                        funcionarios.Email = dr["email"].ToString();
                        funcionarios.Telefone = dr["telefone"].ToString();
                        funcionarios.Celular = dr["celular"].ToString();
                        funcionarios.Endereco = dr["endereco"].ToString();
                        funcionarios.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                    }
                    return funcionario;
                }                
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



        public bool incluirFuncionario(Funcionario funcionario)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_incluirFuncionario", Conexao.conexao))
                {
                    conexao.abrirConexao();

                    cmd.CommandType = CommandType.StoredProcedure;
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
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool deletarFuncionario(int ID)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_deletarFuncionario", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
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

        public bool alterarFuncionario(Funcionario funcionario)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_alterarFuncionari", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
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

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}