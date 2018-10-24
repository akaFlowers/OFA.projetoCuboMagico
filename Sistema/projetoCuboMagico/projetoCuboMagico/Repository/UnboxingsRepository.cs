using MySql.Data.MySqlClient;
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

        public bool incluirCaixa(Unboxing unboxing)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_incluirCaixa", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", unboxing.IdCliente);
                cmd.Parameters.AddWithValue("@dataGerada", unboxing.DataGerada);
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

        public bool incluirLivroCaixa(LivroCaixa livroCaixa)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_ incluirLivroCaixa", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCaixa", livroCaixa.IdCaixa);
                cmd.Parameters.AddWithValue("@idLivro", livroCaixa.IdLivro);
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

        public bool incluirProdutoCaixa(BrindeCaixa brindeCaixa)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_incluirProdutoCaixa", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCaixa", brindeCaixa.IdCaixa);
                cmd.Parameters.AddWithValue("@idProduto", brindeCaixa.IdBrinde);
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