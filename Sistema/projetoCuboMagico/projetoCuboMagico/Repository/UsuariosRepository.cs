using MySql.Data.MySqlClient;
using projetoCuboMagico.Models;
using projetoCuboMagico.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Repository
{
    public class UsuariosRepository
    {
        Conexao conexao = new Conexao();
        MySqlDataReader dr;
        MySqlCommand cmd;


        public Usuario autenticarUsuarioPorEmail(Usuario usuario)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SELECT Usuario.id, usuario, senha FROM Usuario JOIN Cliente ON cliente.id = usuario.id WHERE Cliente.email = @email AND Usuario.senha = @senha", Conexao.conexao);
                cmd.Parameters.AddWithValue("@email", usuario._usuario);
                cmd.Parameters.AddWithValue("@senha", usuario._senha);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    usuario._usuario = dr["usuario"].ToString();
                    usuario._senha = dr["Senha"].ToString();
                }

            }
            catch(MySqlException)
            {
                
            }
            finally
            {

            }


        }

    }
}