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
                    usuarios.Id = Convert.ToInt32(dr["id"]);
                    usuarios.Usuarioo = dr["usuario"].ToString();
                    usuarios.Senha = dr["senha"].ToString();
                    usuarios.NivelAcesso = dr["nivelAcesso"].ToString();
                    usuario.Add(usuarios);
                }

            }
            catch
            {

            }
            finally
            {
                conexao.fecharConexao();
                dr.Close();
            }
            return usuario;
        }

        public Usuario consultaPorID(int id)
        {
            Usuario usuario = new Usuario();
            try
            {
                
                conexao.abrirConexao();
                cmd = new MySqlCommand("SELECT * FROM Usuario WHERE Usuario.id = @id", Conexao.conexao);
                cmd.Parameters.AddWithValue("@id", id);
                dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    usuario.Id = Convert.ToInt32(dr["id"]);
                    usuario.Usuarioo = dr["usuario"].ToString();
                    usuario.Senha = dr["senha"].ToString();
                    usuario.NivelAcesso = dr["nivelAcesso"].ToString();
                }
                return usuario;
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
        }

        public bool incluirUsuario(Usuario usuario)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_incluirUsuario", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", usuario.Usuarioo);
                cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@nivelAcesso", usuario.NivelAcesso);
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
                cmd.Parameters.AddWithValue("@usuario", usuario.Usuarioo);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (usuario.Senha == dr["senha"].ToString())
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
                cmd.Parameters.AddWithValue("@ID", usuario.Id);
                cmd.Parameters.AddWithValue("@usuario", usuario.Usuarioo);
                cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@nivelAcesso", usuario.NivelAcesso);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexao.fecharConexao();
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