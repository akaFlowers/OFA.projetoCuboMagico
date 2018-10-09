﻿using MySql.Data.MySqlClient;
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
            catch (MySqlException)
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


    }
}