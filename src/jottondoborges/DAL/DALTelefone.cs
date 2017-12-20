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
    public class DALTelefone : DAL
    {
        public DALTelefone() : base() {}

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Telefone> SelectAll()
        {
            Telefone t;
            List<Telefone> ts = new List<Telefone>();
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string s = "SELECT * FROM Telefone";
                    SqlCommand c = new SqlCommand(s, conn);
                    SqlDataReader d;
                    using (d = c.ExecuteReader())
                    {
                        if (d.HasRows)
                        {
                            while (d.Read())
                            {
                                int i = Convert.ToInt32(d["id"]);
                                string n = d["telefone"].ToString();
                                int idU = (d["Cliente_id"] != null) ? Convert.ToInt32(d["Cliente_id"]) : 0;
                                int idF = (d["Funcionario_id"] != null) ? Convert.ToInt32(d["Funcionario_id"]) : 0;
                                t = new Telefone(i, n);
                                if (idU != 0)
                                {
                                    t.setCliente(idU);
                                }
                                else
                                {
                                    t.setFuncionario(idF);
                                }
                                ts.Add(t);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ts;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Telefone Select(int i)
        {
            Telefone t = new Telefone();
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string s = "SELECT * FROM Telefone WHERE id = @id";
                    SqlCommand c = new SqlCommand(s, conn);
                    c.Parameters.Add("@id", SqlDbType.Int).Value = i;
                    SqlDataReader d;
                    using (d = c.ExecuteReader())
                    {
                        if (d.HasRows)
                        {
                            while (d.Read())
                            {
                                string n = d["telefone"].ToString();
                                int idU = (d["Cliente_id"] != null) ? Convert.ToInt32(d["Cliente_id"]) : 0;
                                int idF = (d["Funcionario_id"] != null) ? Convert.ToInt32(d["Funcionario_id"]) : 0;
                                t = new Telefone(i, n);
                                if (idU != 0)
                                {
                                    t.setCliente(idU);
                                }
                                else
                                {
                                    t.setFuncionario(idF);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return t;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Telefone SelectFromFuncionario(int i)
        {
            Telefone t = new Telefone();
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string s = "SELECT * FROM Telefone WHERE Funcionario_id = @id";
                    SqlCommand c = new SqlCommand(s, conn);
                    c.Parameters.Add("@id", SqlDbType.Int).Value = i;
                    SqlDataReader d;
                    using (d = c.ExecuteReader())
                    {
                        if (d.HasRows)
                        {
                            while (d.Read())
                            {
                                string n = d["telefone"].ToString();
                                int id = Convert.ToInt32(d["id"]);
                                t = new Telefone(id, n);
                                t.setFuncionario(i);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return t;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Telefone SelectFromCliente(int i)
        {
            Telefone t = new Telefone();
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string s = "SELECT * FROM Telefone WHERE Cliente_id = @id";
                    SqlCommand c = new SqlCommand(s, conn);
                    c.Parameters.Add("@id", SqlDbType.Int).Value = i;
                    SqlDataReader d;
                    using (d = c.ExecuteReader())
                    {
                        if (d.HasRows)
                        {
                            while (d.Read())
                            {
                                string n = d["telefone"].ToString();
                                int id = Convert.ToInt32(d["id"]);
                                t = new Telefone(id, n);
                                t.setCliente(i);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return t;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Telefone SelectFromFornecedor(int i)
        {
            Telefone t = new Telefone();
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string s = "SELECT * FROM TelefoneFornecedor WHERE Fornecedor_id = @id";
                    SqlCommand c = new SqlCommand(s, conn);
                    c.Parameters.Add("@id", SqlDbType.Int).Value = i;
                    SqlDataReader d;
                    using (d = c.ExecuteReader())
                    {
                        if (d.HasRows)
                        {
                            while (d.Read())
                            {
                                string n = d["telefone"].ToString();
                                int id = Convert.ToInt32(d["id"]);
                                t = new Telefone(id, n);
                                t.setCliente(i);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return t;
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void Insert(Telefone t)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string dono = (t.Cliente_id != 0) ? "Cliente_id" : "Funcionario_id";
                    string q = "INSERT INTO Telefone (telefone, " + dono + ") VALUES (@t, @d)";
                    SqlCommand cmd = new SqlCommand(q, conn);
                    cmd.Parameters.Add("@t", SqlDbType.VarChar).Value = t.telefone;
                    cmd.Parameters.Add("@d", SqlDbType.Int).Value = (t.Cliente_id != 0) ? t.Cliente_id : t.Funcionario_id;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void InsertFornecedor(Telefone t)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string dono = "Fornecedor_id";
                    string q = "INSERT INTO TelefoneFornecedor (telefone, " + dono + ") VALUES (@t, @d)";
                    SqlCommand cmd = new SqlCommand(q, conn);
                    cmd.Parameters.Add("@t", SqlDbType.VarChar).Value = t.telefone;
                    cmd.Parameters.Add("@d", SqlDbType.Int).Value = t.Fornecedor_id;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteFromCliente(int i)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string q = "DELETE FROM Telefone WHERE Cliente_id = @id";
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

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteFromFuncionario(int i)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string q = "DELETE FROM Telefone WHERE Funcionario_id = @id";
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
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteFromFornecedor(int i)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string q = "DELETE FROM TelefoneFornecedor WHERE Fornecedor_id = @id";
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