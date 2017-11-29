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
    public class DALCliente : DAL
    {
        public DALCliente() : base() {}

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Cliente> SelectAll()
        {
            Cliente c;
            List<Cliente> cs = new List<Cliente>();
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string s = "SELECT * FROM Cliente";
                    SqlCommand cmd = new SqlCommand(s, conn);
                    SqlDataReader d;
                    using (d = cmd.ExecuteReader())
                    {
                        if (d.HasRows)
                        {
                            while (d.Read())
                            {
                                int i = Convert.ToInt32(d["id"]);
                                string n = d["Nome"].ToString();
                                string cpf = (d["CPF"] != null) ? d["CPF"].ToString() : "";
                                string cnpj = (d["CNPJ"] != null) ? d["CNPJ"].ToString() : "";
                                string e = d["Email"].ToString();
                                Endereco end = DALEndereco.SelectFromCliente(i);
                                Telefone t = DALTelefone.SelectFromCliente(i);
                                c = new Cliente(i, n, e, end, t);
                                if (cpf != "") c.setCPF(cpf);
                                else c.setCNPJ(cnpj);
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
        public static Cliente Select(int i)
        {
            Cliente c = new Cliente();
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string s = "SELECT * FROM Cliente WHERE id = @id ";
                    SqlCommand cmd = new SqlCommand(s, conn);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = i;
                    SqlDataReader d;
                    using (d = cmd.ExecuteReader())
                    {
                        if (d.HasRows)
                        {
                            while (d.Read())
                            {
                                string n = d["Nome"].ToString();
                                string cpf = (d["CPF"] != null) ? d["CPF"].ToString() : "";
                                string cnpj = (d["CNPJ"] != null) ? d["CNPJ"].ToString() : "";
                                string e = d["Email"].ToString();
                                Endereco end = DALEndereco.SelectFromCliente(i);
                                Telefone t = DALTelefone.SelectFromCliente(i);
                                c = new Cliente(i, n, e, end, t);
                                if (cpf != "") c.setCPF(cpf);
                                else c.setCNPJ(cnpj);
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
        public static void Insert(Cliente cl)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string doc = (cl.CPF != "" && cl.CPF != null) ? "CPF" : "CNPJ";
                    string q = "INSERT INTO Cliente (Nome, " + doc + ", Email) VALUES (@n, @d, @m) SET @ID = SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(q, conn);
                    cmd.Parameters.Add("@n", SqlDbType.VarChar).Value = cl.nome;
                    cmd.Parameters.Add("@d", SqlDbType.VarChar).Value = (cl.CPF != "" && cl.CPF != null) ? cl.CPF : cl.CNPJ;
                    cmd.Parameters.Add("@m", SqlDbType.VarChar).Value = cl.email;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int i = (int)cmd.Parameters["@ID"].Value;
                    cl.telefone.setCliente(i);
                    cl.endereco.setCliente(i);
                    DALTelefone.Insert(cl.telefone);
                    DALEndereco.Insert(cl.endereco);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}