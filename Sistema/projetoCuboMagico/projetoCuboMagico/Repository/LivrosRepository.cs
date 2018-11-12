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
                using (cmd = new MySqlCommand("SP_listarTodosLivros", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Livro livros = new Livro();
                        livros.Id = Convert.ToInt32(dr["id"]);
                        livros.Nome = dr["nome"].ToString();
                        livros.Autor = dr["autor"].ToString();
                        livros.IdGeneroLivro = dr["idGeneroLivro"].ToString();
                        livros.GeneroLivro.GeneroLivroo = dr["generoLivro"].ToString();
                        livros.GeneroLivro.SubGenero = dr["subGenero"].ToString();
                        livros.DataPublicacao = dr["dataPublicacao"].ToString();
                        livros.Editora = dr["editora"].ToString();   

                        livro.Add(livros);
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
            return livro;
        }

        public Livro consultaPorID(int id)
        {
            Livro livro = new Livro();
            try
            {
                using (cmd = new MySqlCommand("SP_consultaLivroPorID", Conexao.conexao))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexao.abrirConexao();
                    cmd.Parameters.AddWithValue("@ID", id);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        livro.Id = Convert.ToInt32(dr["id"]);
                        livro.Nome = dr["nome"].ToString();
                        livro.Autor = dr["autor"].ToString();
                        livro.IdGeneroLivro = dr["idGeneroLivro"].ToString();
                        livro.GeneroLivro.GeneroLivroo = dr["generoLivro"].ToString();
                        livro.GeneroLivro.SubGenero = dr["subGenero"].ToString();
                        livro.DataPublicacao = dr["dataPublicacao"].ToString();
                        livro.Editora = dr["editora"].ToString();
                    }
                    return livro;
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

        public bool incluirLivro(Livro livro)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_incluirLivro", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nome", livro.Nome);
                    cmd.Parameters.AddWithValue("@autor", livro.Autor);
                    cmd.Parameters.AddWithValue("@idGeneroLivro", livro.IdGeneroLivro);
                    cmd.Parameters.AddWithValue("@dataPublicacao", livro.DataPublicacao);
                    cmd.Parameters.AddWithValue("@editora", livro.Editora);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool alterarLivro(Livro livro)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_alterarLivro", Conexao.conexao))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", livro.Id);
                    cmd.Parameters.AddWithValue("@nome", livro.Nome);
                    cmd.Parameters.AddWithValue("@autor", livro.Autor);
                    cmd.Parameters.AddWithValue("@idGeneroLivro", livro.IdGeneroLivro);
                    cmd.Parameters.AddWithValue("@dataPublicacao", livro.DataPublicacao);
                    cmd.Parameters.AddWithValue("@editora", livro.Editora);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool deletarLivro(int id)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_deletarLivro", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
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