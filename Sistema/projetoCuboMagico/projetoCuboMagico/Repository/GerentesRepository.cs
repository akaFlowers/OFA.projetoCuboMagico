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
    public class GerentesRepository
    {

        Conexao conexao = new Conexao();
        MySqlCommand cmd;
        MySqlDataReader dr;


        public IEnumerable<Gerente> listarTodos()
        {
            List<Gerente> gerente = new List<Gerente>();
            try
            {
                using (cmd = new MySqlCommand("SP_listarTodosGerentes", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Gerente gerentes = new Gerente();
                        gerentes.Id = Convert.ToInt32(dr["id"]);
                        gerentes.NomeCompleto = dr["nomeCompleto"].ToString();
                        gerentes.DataNascimento = dr["dataNascimento"].ToString();
                        gerentes.Sexo = dr["sexo"].ToString();
                        gerentes.Cpf = dr["cpf"].ToString();
                        gerentes.Email = dr["email"].ToString();
                        gerentes.Telefone = dr["telefone"].ToString();
                        gerentes.Celular = dr["celular"].ToString();
                        gerentes.Endereco = dr["endereco"].ToString();
                        gerentes.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                        gerente.Add(gerentes);
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
            return gerente;
        }

        public Gerente consultaPorID(int id)
        {
            Gerente gerente = new Gerente();
            try
            {
                using (cmd = new MySqlCommand("SELECT * FROM Gerente WHERE Gerente.id = @id", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.Parameters.AddWithValue("@id", id);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        gerente.Id = Convert.ToInt32(dr["id"]);
                        gerente.NomeCompleto = dr["nomeCompleto"].ToString();
                        gerente.DataNascimento = dr["dataNascimento"].ToString();
                        gerente.Sexo = dr["sexo"].ToString();
                        gerente.Cpf = dr["cpf"].ToString();
                        gerente.Email = dr["email"].ToString();
                        gerente.Telefone = dr["telefone"].ToString();
                        gerente.Celular = dr["celular"].ToString();
                        gerente.Endereco = dr["endereco"].ToString();
                        gerente.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                    }
                    return gerente;
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

        public bool incluirGerente(Gerente gerente)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_incluirGerente", Conexao.conexao);)
                {
                    conexao.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
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
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool deletarGerente(int ID)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_deletarGerente", Conexao.conexao))
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

        public bool alterarGerente(Gerente gerente)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_alterarGerente", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
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
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}