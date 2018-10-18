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
    public class LivrosRepository
    {
        Conexao conexao = new Conexao();
        MySqlCommand cmd;
        MySqlDataReader dr;


        public IEnumerable<Livro> listarTodos()
        {
            List<Livro> livro = new List<Livro>();

            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_listarTodosLivros", Conexao.conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Livro livros = new Livro();
                    livros.Id = Convert.ToInt32(dr["id"]);
                    livros.Nome = dr["nome"].ToString();
                    livros.Autor = dr["autor"].ToString();
                    livros.IdGenero = dr["idGenero"].ToString();
                    livros.DataPublicacao = dr["dataPublicacao"].ToString();
                    livros.Editora = dr["editora"].ToString();
                    
                    livro.Add(livros);
                }

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexao.fecharConexao();
                dr.Close();
            }
            return livro;
        }

        public Livro consultaPorID(int id)
        {
            Livro livro = new Livro();
            try
            {

                conexao.abrirConexao();
                cmd = new MySqlCommand("SELECT * FROM Livro WHERE Livro.id = @id", Conexao.conexao);
                cmd.Parameters.AddWithValue("@id", id);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    livro.Id = Convert.ToInt32(dr["id"]);
                    livro.Nome = dr["nome"].ToString();
                    livro.Autor = dr["autor"].ToString();
                    livro.IdGenero = dr["idGenero"].ToString();
                    livro.DataPublicacao = dr["dataPublicacao"].ToString();
                    livro.Editora = dr["editora"].ToString();
                }
                return livro;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexao.fecharConexao();
                dr.Close();
            }
        }

        public bool incluirLivro(Livro livro)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_incluirLivro", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nome", livro.Nome);
                cmd.Parameters.AddWithValue("@autor", livro.Autor);
                cmd.Parameters.AddWithValue("@idGenero", livro.IdGenero);
                cmd.Parameters.AddWithValue("@dataPublicacao", livro.DataPublicacao);
                cmd.Parameters.AddWithValue("@editora", livro.Editora);
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

        public bool alterarLivro(Livro livro)
        {
            try
            {
                cmd = new MySqlCommand("SP_alterarLivro", Conexao.conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", livro.Id);
                cmd.Parameters.AddWithValue("@nome", livro.Nome);
                cmd.Parameters.AddWithValue("@autor", livro.Autor);
                cmd.Parameters.AddWithValue("@idGenero", livro.IdGenero);
                cmd.Parameters.AddWithValue("@dataPublicacao", livro.DataPublicacao);
                cmd.Parameters.AddWithValue("@editora", livro.Editora);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {

            }
        }

        public bool deletarLivro(int id)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_deletarLivro", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
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