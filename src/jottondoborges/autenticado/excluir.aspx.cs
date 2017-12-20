using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jottondoborges.App_Code.DAL;
using jottondoborges.App_Code.DAO;

namespace jottondoborges.autenticado
{
    public partial class excluir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string t = Request.QueryString["t"];
            if (t == "c") { excluirCliente(id); }
            else if (t == "fo") { excluirFornecedor(id); }
            else if (t == "fu") { excluirFuncionario(id); }
            else if (t == "p") { excluirProduto(id); }
            else if (t == "s") { }
        }

        private void excluirCliente(int i)
        {
            DALCliente.Delete(i);
            Response.Write("<script>alert('Cliente excluído com sucessso!')</script>");
            Response.Redirect("~/autenticado/clientes/index.aspx");
        }
        private void excluirFornecedor(int i)
        {
            DALFornecedor.Delete(i);
            Response.Write("<script>alert('Fornecedor excluído com sucessso!')</script>");
            Response.Redirect("~/autenticado/fornecedores/index.aspx");

        }
        private void excluirFuncionario(int i)
        {
            DALFuncionario.Delete(i);
            Response.Write("<script>alert('Funcionário excluído com sucessso!')</script>");
            Response.Redirect("~/autenticado/funcionarios/index.aspx");

        }
        private void excluirProduto(int i)
        {
            DALProduto.Delete(i);
            Response.Write("<script>alert('Produto excluído com sucessso!')</script>");
            Response.Redirect("~/autenticado/produtos/index.aspx");
        }
    }
}