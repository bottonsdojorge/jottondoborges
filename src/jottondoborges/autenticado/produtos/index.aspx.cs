using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jottondoborges.App_Code.DAL;
using jottondoborges.App_Code.DAO;

namespace jottondoborges.autenticado.produtos
{
    public partial class index : System.Web.UI.Page
    {
        public List<Produto> ps { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            carregarProdutos();
        }
        private void carregarProdutos()
        {
            ps = DALProduto.SelectAll();
        }
        private void inserirProduto()
        {
            string n;
            n = Request.Form.GetValues("n")[0];
            Produto p = new Produto(n);
            DALProduto.Insert(p);
            Response.Write("<script>alert('Produto inserido com sucesso.');</script>");
            carregarProdutos();
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            inserirProduto();
        }
    }
}