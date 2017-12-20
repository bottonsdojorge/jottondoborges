using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using jottondoborges.App_Code.DAO;

namespace jottondoborges.App_Code.DAL
{
    public class DALProduto : DAL
    {
        public DALProduto() : base(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Produto> SelectAll()
        {
            Produto c;
            List<Produto> cs = new List<Produto>();
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string s = "SELECT * FROM Produto";
                    SqlCommand cmd = new SqlCommand(s, conn);
                    SqlDataReader d;
                    using (d = cmd.ExecuteReader())
                    {
                        if (d.HasRows)
                        {
                            while (d.Read())
                            {
                                int i = Convert.ToInt32(d["id"]);
                                string n = d["Descricao"].ToString();
                                c = new Produto(i, n);
                                cs.Add(c);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return cs;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Produto Select(int i)
        {
            Produto c = new Produto();
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string s = "SELECT * FROM Produto WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(s, conn);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = i;
                    SqlDataReader d;
                    using (d = cmd.ExecuteReader())
                    {
                        if (d.HasRows)
                        {
                            while (d.Read())
                            {
                                string n = d["Descricao"].ToString();
                                c = new Produto(i, n);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return c;
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void Insert(Produto p)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string q = "INSERT INTO Produto (Descricao) VALUES (@d)";
                    SqlCommand cmd = new SqlCommand(q, conn);
                    cmd.Parameters.Add("@d", SqlDbType.VarChar).Value = p.desc;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void Delete(int i)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string q = "DELETE FROM Produto WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(q, conn);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = i;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}