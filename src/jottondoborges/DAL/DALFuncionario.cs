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
    public class DALFuncionario : DAL
    {
        public DALFuncionario() : base() { }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Funcionario> SelectAll()
        {
            Funcionario c;
            List<Funcionario> cs = new List<Funcionario>();
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string s = "SELECT * FROM Funcionario";
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
                                string rg = d["Identidade"].ToString();
                                string clt = d["CLT"].ToString();
                                string obs = d["Observacao"].ToString();
                                bool m = Convert.ToBoolean(d["Motorista"]);
                                bool t = Convert.ToBoolean(d["Tecnico"]);
                                double sal = Convert.ToDouble(d["Salario"]);
                                Endereco end = DALEndereco.SelectFromFuncionario(i);
                                Telefone tel = DALTelefone.SelectFromFuncionario(i);
                                c = new Funcionario(i, n, m, t, rg, clt, sal, obs, end, tel);
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
        public static Funcionario Select(int i)
        {
            Funcionario c = new Funcionario();
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string s = "SELECT * FROM Funcionario WHERE id = @id";
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
                                string rg = d["Identidade"].ToString();
                                string clt = d["CLT"].ToString();
                                string obs = d["Observacao"].ToString();
                                bool m = Convert.ToBoolean(d["Motorista"]);
                                bool t = Convert.ToBoolean(d["Tecnico"]);
                                double sal = Convert.ToDouble(d["Salario"]);
                                Endereco end = DALEndereco.SelectFromFuncionario(i);
                                Telefone tel = DALTelefone.SelectFromFuncionario(i);
                                c = new Funcionario(i, n, m, t, rg, clt, sal, obs, end, tel);
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
        public static void Insert(Funcionario fn)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string q = "INSERT INTO Funcionario (Nome, Motorista, Tecnico, Identidade, CLT, Salario, Observacao) VALUES (@n, @m, @t, @i, @c, @s, @o) SET @ID = SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(q, conn);
                    cmd.Parameters.Add("@n", SqlDbType.VarChar).Value = fn.nome;
                    cmd.Parameters.Add("@m", SqlDbType.Bit).Value = fn.motorista;
                    cmd.Parameters.Add("@t", SqlDbType.Bit).Value = fn.tecnico;
                    cmd.Parameters.Add("@i", SqlDbType.VarChar).Value = fn.identidade;
                    cmd.Parameters.Add("@c", SqlDbType.VarChar).Value = fn.CLT;
                    cmd.Parameters.Add("@s", SqlDbType.Float).Value = fn.salario;
                    cmd.Parameters.Add("@o", SqlDbType.VarChar).Value = fn.observacao;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int i = (int)cmd.Parameters["@ID"].Value;
                    fn.telefone.setFuncionario(i);
                    fn.endereco.setFuncionario(i);
                    DALTelefone.Insert(fn.telefone);
                    DALEndereco.Insert(fn.endereco);
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
                DALTelefone.DeleteFromFuncionario(i);
                DALEndereco.DeleteFromFuncionario(i);
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string q = "DELETE FROM Funcionario WHERE id = @id";
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