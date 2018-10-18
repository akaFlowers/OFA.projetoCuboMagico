using MySql.Data.MySqlClient;
using projetoCuboMagico.Models;
using projetoCuboMagico.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoCuboMagico.Repository
{
    public class CaixasRepository
    {
        Conexao conexao = new Conexao();
        MySqlCommand cmd;

        public bool incluirCaixa(Caixa caixa)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_incluirCaixa", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", caixa._idCliente);
                cmd.Parameters.AddWithValue("@dataGerada", caixa._dataGerada);
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
                cmd.Parameters.AddWithValue("@idCaixa", livroCaixa._idCaixa);
                cmd.Parameters.AddWithValue("@idLivro", livroCaixa._idLivro);
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

        public bool incluirProdutoCaixa(ProdutoCaixa produtoCaixa)
        {
            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_incluirProdutoCaixa", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCaixa", produtoCaixa._idCaixa);
                cmd.Parameters.AddWithValue("@idProduto", produtoCaixa._idProduto);
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