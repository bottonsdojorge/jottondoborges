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
    public class DALEndereco : DAL
    {
        public DALEndereco() : base() {}
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Endereco SelectFromFuncionario(int f)
        {
            Endereco e = new Endereco();
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string s = "SELECT * FROM Endereco WHERE Funcionario_id = @id";
                    SqlCommand c = new SqlCommand(s, conn);
                    c.Parameters.Add("@id", SqlDbType.Int).Value = f;
                    SqlDataReader d;
                    using (d = c.ExecuteReader())
                    {
                        if (d.HasRows)
                        {
                            while (d.Read())
                            {
                                int id = Convert.ToInt32(d["id"]);
                                string st = d["Estado"].ToString();
                                string ct = d["Cidade"].ToString();
                                string b = d["Bairro"].ToString();
                                string r = d["Rua"].ToString();
                                int n = Convert.ToInt32(d["Numero"]);
                                string compl = d["Complemento"].ToString();
                                e = new Endereco(id, st, ct, b, r, n, compl);
                                e.setFuncionario(f);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return e;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Endereco SelectFromCliente(int f)
        {
            Endereco e = new Endereco();
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string s = "SELECT * FROM Endereco WHERE Cliente_id = @id";
                    SqlCommand c = new SqlCommand(s, conn);
                    c.Parameters.Add("@id", SqlDbType.Int).Value = f;
                    SqlDataReader d;
                    using (d = c.ExecuteReader())
                    {
                        if (d.HasRows)
                        {
                            while (d.Read())
                            {
                                int id = Convert.ToInt32(d["id"]);
                                string st = d["Estado"].ToString();
                                string ct = d["Cidade"].ToString();
                                string b = d["Bairro"].ToString();
                                string r = d["Rua"].ToString();
                                int n = Convert.ToInt32(d["Numero"]);
                                string compl = d["Complemento"].ToString();
                                e = new Endereco(id, st, ct, b, r, n, compl);
                                e.setCliente(f);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return e;
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void Insert(Endereco e)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string dono = (e.idCliente != 0) ? "Cliente_id" : "Funcionario_id";
                    string compl = (e.complemento != "" && e.complemento != null) ? ("Complemento, ") : "";
                    string q = "INSERT INTO Endereco (Estado, Cidade, Bairro, Rua, Numero, " + compl + dono + ") VALUES (@e, @c, @b, @r, @n, " + ((compl != "") ? "@compl, " : "")  + "@d)";
                    SqlCommand cmd = new SqlCommand(q, conn);
                    cmd.Parameters.Add("@e", SqlDbType.VarChar).Value = e.estado;
                    cmd.Parameters.Add("@c", SqlDbType.VarChar).Value = e.cidade;
                    cmd.Parameters.Add("@b", SqlDbType.VarChar).Value = e.bairro;
                    cmd.Parameters.Add("@r", SqlDbType.VarChar).Value = e.rua;
                    cmd.Parameters.Add("@n", SqlDbType.Int).Value = e.numero;
                    if (e.complemento != "" && e.complemento != null) cmd.Parameters.Add("@compl", SqlDbType.VarChar).Value = e.complemento;
                    cmd.Parameters.Add("@d", SqlDbType.Int).Value = (e.idCliente != 0) ? e.idCliente : e.idFuncionario;
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