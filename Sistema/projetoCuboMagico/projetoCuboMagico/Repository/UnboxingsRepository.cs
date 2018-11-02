﻿using MySql.Data.MySqlClient;
using projetoCuboMagico.Models;
using projetoCuboMagico.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Repository
{
    public class UnboxingsRepository
    {
        Conexao conexao = new Conexao();
        MySqlCommand cmd;

        public bool incluirUnboxing(Unboxing unboxing)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_incluirUnboxing", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", unboxing.IdCliente);
                cmd.Parameters.AddWithValue("@dataGerada", unboxing.DataGerada);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool incluirLivroUnboxing(LivroUnboxing livroUnboxing)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_ incluirLivroUnboxing", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUnboxing", livroUnboxing.IdCaixa);
                    cmd.Parameters.AddWithValue("@idLivro", livroUnboxing.IdLivro);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool incluirProdutoUnboxing(BrindeUnboxing brindeUnboxing)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_incluirProdutoCaixa", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUnboxing", brindeUnboxing.IdCaixa);
                    cmd.Parameters.AddWithValue("@idProduto", brindeUnboxing.IdBrinde);
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