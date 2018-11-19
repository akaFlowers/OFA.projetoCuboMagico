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
    public class UnboxingsRepository
    {
        ClientesRepository clientesRepository = new ClientesRepository();
        Conexao conexao = new Conexao();
        MySqlCommand cmd;
        MySqlDataReader dr;

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
        
        public DataTable buscarGeneroCliente(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlDataAdapter adp = new MySqlDataAdapter();
                Cliente cliente = new Cliente();
                cliente = clientesRepository.consultaPorID(id);
                using (cmd = new MySqlCommand("SP_livrosSorteadosGenero", Conexao.conexao))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("", id);
                }
                return dt;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {

            }
        }

        public Assinatura trazerAssinaturaCliente(int id)
        {
            try
            {
                Assinatura assinatura = new Assinatura();
                using (cmd = new MySqlCommand("SP_trazerAssinaturaCliente", Conexao.conexao))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        assinatura.Id = Convert.ToInt32(dr["idAssinatura"]);
                        assinatura.Nome = dr["nomeAssinatura"].ToString();
                        assinatura.Tipo = dr["tipo"].ToString();
                        assinatura.IdCliente = id;
                        assinatura.Cliente.Cpf = dr["cpf"].ToString();
                        assinatura.Cliente.Nome = dr["nome"].ToString();
                        assinatura.Cliente.Id = Convert.ToInt32(dr["id"]);
                        assinatura.Valor = Convert.ToDecimal(dr["valor"]);
                    }
                }
                return assinatura;
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