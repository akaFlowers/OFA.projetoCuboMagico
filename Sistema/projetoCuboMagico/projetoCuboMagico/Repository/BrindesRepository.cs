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
    public class BrindesRepository
    {
        Conexao conexao = new Conexao();
        MySqlCommand cmd;
        MySqlDataReader dr;

        public IEnumerable<Brinde> listarTodos()
        {
            List<Brinde> brinde = new List<Brinde>();

            try
            {
                conexao.abrirConexao();
                cmd = new MySqlCommand("SP_listarTodosBrindes", Conexao.conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Brinde brindes = new Brinde();
                    brindes.Id = Convert.ToInt32(dr["id"]);
                    brindes.Nome = dr["nome"].ToString();
                    brindes.Tipo = dr["tipo"].ToString();
                    brindes.Design = dr["design"].ToString();
                    brinde.Add(brindes);
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
            return brinde;
        }

        public Brinde consultaPorID(int id)
        {
            Brinde brinde = new Brinde();
            try
            {

                conexao.abrirConexao();
                cmd = new MySqlCommand("SELECT * FROM Brinde WHERE Brinde.id = @id", Conexao.conexao);
                cmd.Parameters.AddWithValue("@id", id);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    brinde.Id = Convert.ToInt32(dr["id"]);
                    brinde.Nome = dr["nome"].ToString();
                    brinde.Tipo = dr["tipo"].ToString();
                    brinde.Design = dr["design"].ToString();
                }
                return brinde;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexao.fecharConexao();
                dr.Close();
            }
        }

        public bool incluirBrinde(Brinde brinde)
        {
            try
            {
                using(cmd = new MySqlCommand("SP_incluirBrinde", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nome", brinde.Nome);
                    cmd.Parameters.AddWithValue("@tipo", brinde.Tipo);
                    cmd.Parameters.AddWithValue("@design", brinde.Design);
                    cmd.ExecuteNonQuery();
                }
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

        public bool alterarBrinde(Brinde brinde)
        {
            try
            {
                using(cmd = new MySqlCommand("SP_alterarBrinde", Conexao.conexao))
                {
                    conexao.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", brinde.Id);
                    cmd.Parameters.AddWithValue("@nome", brinde.Nome);
                    cmd.Parameters.AddWithValue("@tipo", brinde.Tipo);
                    cmd.Parameters.AddWithValue("@design", brinde.Design);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public bool deletarBrinde(int id)
        {
            try
            {
                using(cmd = new MySqlCommand("SP_deletarBrinde", Conexao.conexao))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
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




    }
}