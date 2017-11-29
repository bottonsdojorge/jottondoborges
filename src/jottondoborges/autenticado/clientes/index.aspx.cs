using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jottondoborges.App_Code.DAL;
using jottondoborges.App_Code.DAO;

namespace jottondoborges.autenticado.clientes
{
    public partial class index : System.Web.UI.Page
    {
        public List<Cliente> clientes { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            carregarClientes();
        }

        private void carregarClientes()
        {
            clientes = DALCliente.SelectAll();
        }
        private void inserirCliente()
        {
            string n, m, d, t, e, c, b, r, compl, td;
            int num;
            n = Request.Form.GetValues("n")[0];
            m = Request.Form.GetValues("m")[0];
            d = Request.Form.GetValues("d")[0];
            t = Request.Form.GetValues("t")[0];
            e = Request.Form.GetValues("e")[0];
            c = Request.Form.GetValues("c")[0];
            b = Request.Form.GetValues("b")[0];
            r = Request.Form.GetValues("r")[0];
            td = Request.Form.GetValues("td")[0];
            compl = Request.Form.GetValues("compl")[0];
            num = Convert.ToInt32(Request.Form.GetValues("num")[0]);
            
            Endereco end = new Endereco(0, e, c, b, r, num, compl);
            Telefone tel = new Telefone(0, t);
            Cliente cl = new Cliente(0, n, m, end, tel);
            if (td == "CPF") cl.setCPF(d);
            else cl.setCNPJ(d);
            DALCliente.Insert(cl);
            Response.Write("<script>alert('Cliente inserido com sucesso.');</script>");
            carregarClientes();
        }
        protected void btnInserir_Click(object sender, EventArgs e)
        {
            inserirCliente();
        }
    }
}