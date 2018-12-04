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
                using (cmd = new MySqlCommand("SP_listarTodosUsuarios", Conexao.conexao))
                {
                    conexao.abrirConexao();
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
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                dr.Close();
            }
            return usuario;
        }

        public Usuario consultaPorID(int id)
        {
            Usuario usuario = new Usuario();
            try
            {
                using (cmd = new MySqlCommand("SELECT * FROM Usuario WHERE Usuario.id = @id", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.Parameters.AddWithValue("@id", id);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        usuario.Id = Convert.ToInt32(dr["id"]);
                        usuario.Usuarioo = dr["usuario"].ToString();
                        usuario.Senha = dr["senha"].ToString();
                        usuario.NivelAcesso = dr["nivelAcesso"].ToString();
                    }
                    return usuario;
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

        public bool incluirUsuario(Usuario usuario)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_incluirUsuario", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usuario", usuario.Usuarioo);
                    cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                    cmd.Parameters.AddWithValue("@nivelAcesso", "Funcionario");
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void autenticarEmail(string email, string senha)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_consultUsuarioPorEmail", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (senha == dr["senha"].ToString())
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

        public Usuario consultaPorEmail(string email)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_consultaUsuarioPorEmail", Conexao.conexao))
                {
                    Usuario usuario = new Usuario();
                    conexao.abrirConexao();
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        usuario.Usuarioo = dr["usuario"].ToString();
                        usuario.Senha = dr["senha"].ToString();
                        usuario.NivelAcesso = dr["nivelAcesso"].ToString();
                    }
                    return usuario;
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

        public Usuario autenticarPorUsuario(Usuario usuario)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_consultaPorUsuario", Conexao.conexao))
                {
                    Usuario usuarioLogado = new Usuario();
                    conexao.abrirConexao();
                    cmd.Parameters.AddWithValue("@usuario", usuario.Usuarioo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        usuarioLogado.Id = Convert.ToInt32(dr["id"]);
                        usuarioLogado.Usuarioo = dr["usuario"].ToString();
                        usuarioLogado.Senha = dr["senha"].ToString();
                        usuarioLogado.NivelAcesso = dr["nivelAcesso"].ToString();
                    }
                    return usuarioLogado;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
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
                using (cmd = new MySqlCommand("SP_deletarUsuario", Conexao.conexao))
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


        public bool alterarUsuario(Usuario usuario)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_alterarUsuario", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", usuario.Id);
                    cmd.Parameters.AddWithValue("@usuario", usuario.Usuarioo);
                    cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                    cmd.Parameters.AddWithValue("@nivelAcesso", usuario.NivelAcesso);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public int trazerIdUsuario(string usuario)
        {
            try
            {
                using (cmd = new MySqlCommand("SELECT Usuario.id AS ID FROM Usuario WHERE Usuario.usuario = @USUARIO", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.Parameters.AddWithValue("@USUARIO", usuario);
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