using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jottondoborges.App_Code.DAL;
using jottondoborges.App_Code.DAO;

namespace jottondoborges.autenticado.funcionarios
{
    public partial class index : System.Web.UI.Page
    {
        public List<Funcionario> fs { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            carregarFuncionarios();
        }
        private void carregarFuncionarios(){
            fs = DALFuncionario.SelectAll();
        }
        private void inserirFuncionario()
        {
            string n, i, d, o, t, e, c, b, r, compl;
            int num;
            bool m;
            double s;
            n = Request.Form.GetValues("n")[0];
            i = Request.Form.GetValues("i")[0];
            d = Request.Form.GetValues("d")[0];
            m = (Request.Form.GetValues("f")[0] == "M") ? true : false;
            o = Request.Form.GetValues("o")[0];
            s = Convert.ToDouble(Request.Form.GetValues("s")[0]);
            t = Request.Form.GetValues("t")[0];
            e = Request.Form.GetValues("e")[0];
            c = Request.Form.GetValues("c")[0];
            b = Request.Form.GetValues("b")[0];
            r = Request.Form.GetValues("r")[0];
            compl = Request.Form.GetValues("compl")[0];
            num = Convert.ToInt32(Request.Form.GetValues("num")[0]);

            Endereco end = new Endereco(0, e, c, b, r, num, compl);
            Telefone tel = new Telefone(0, t);
            Funcionario fn = new Funcionario(0, n, m, !m, i, d, s, o, end, tel);
            DALFuncionario.Insert(fn);
            Response.Write("<script>alert('Funcionário inserido com sucesso.');</script>");
            carregarFuncionarios();
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            inserirFuncionario();
        }
    }
}