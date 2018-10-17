using MySql.Data.MySqlClient;
using projetoCuboMagico.Models;
using projetoCuboMagico.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace projetoCuboMagico.Repository
{
    public class UsuariosRepository
    {
        Conexao conexao = new Conexao();
        MySqlDataReader dr;
        MySqlCommand cmd;


        public IEnumerable<Usuario> listarTodos()
        {
            List<Usuario> usuario = new List<Usuario>();

            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_listarTodosUsuarios", Conexao.conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Usuario usuarios = new Usuario();
                    usuarios._id = Convert.ToInt32(dr["id"]);
                    usuarios._usuario = dr["usuario"].ToString();
                    usuarios.senha = dr["senha"].ToString();
                    usuarios._nivelAcesso = dr["nivelAcesso"].ToString();
                    usuario.Add(usuarios);
                }

            }
            catch
            {

            }
            finally
            {
                conexao.fecharConexao();
            }
            return usuario;
        }

        public bool incluirUsuario(Usuario usuario)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_incluirUsuario", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", usuario._usuario);
                cmd.Parameters.AddWithValue("@senha", usuario._senha);
                cmd.Parameters.AddWithValue("@nivelAcesso", usuario._nivelAcesso);
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

        public void autenticarEmail(string email, string senha)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_consultUsuarioPorEmail", Conexao.conexao);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if(senha == dr["senha"].ToString() )
                    {
                        //AUTENTICADO
                    }
                    else
                    {
                        //SENHA INCORRETA
                    }
                }
                else
                {
                    //EMAIL NÃO ENCOTRADO
                }

            }
            catch(MySqlException)
            {

            }
            finally
            {
                dr.Close();
                conexao.fecharConexao();
            }
        }

        public void autenticarPorUsuario(Usuario usuario)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_consultaPorUsuario", Conexao.conexao);
                cmd.Parameters.AddWithValue("@usuario", usuario._usuario);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (usuario._senha == dr["senha"].ToString())
                    {
                        //AUTENTICADO
                    }
                    else
                    {
                        //SENHA INCORRETA
                    }
                }
                else
                {
                    //USUARIO NÃO ENCOTRADO
                }

            }
            catch (MySqlException)
            {

            }
            finally
            {
                dr.Close();
                conexao.fecharConexao();
            }
        }

        public bool deletarUsuario(int id)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_deletarUsuario", Conexao.conexao);
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


        public bool alterarUsuario(Usuario usuario)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_alterarUsuario", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", usuario._id);
                cmd.Parameters.AddWithValue("@usuario", usuario._usuario);
                cmd.Parameters.AddWithValue("@senha", usuario._senha);
                cmd.Parameters.AddWithValue("@nivelAcesso", usuario._nivelAcesso);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {

            }
        }


        public int trazerIdUsuario()
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SELECT COUNT(id) AS ID FROM Usuario", Conexao.conexao);
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
            catch
            {
                return 0;
            }
            finally
            {
                conexao.fecharConexao();
                dr.Close();
            }
        }
    }
}