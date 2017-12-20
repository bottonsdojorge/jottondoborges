<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="jottondoborges.autenticado.produtos.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Painel de Produtos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCorpo" runat="server">
    <div class="row">
        <div class="col">
            <h1>Cadastro de Produtos 
                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalInserir">
                    Inserir
                </button>
            </h1>
        </div>
    </div>
    <div class="modal fade" id="modalInserir" tabindex="-1" role="dialog" aria-labelledby="ModalInserir" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="H1">Inserir Produto</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Fechar"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div id="formInserir">
                            <div class="form-group">
                                <label class="col-form-label" for="nome">Descrição</label>
                                <input type="text" class="form-control" id="nome" name="n" placeholder="Descrição" required />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                    <asp:Button ID="btnInserir" CssClass="btn btn-primary" runat="server" Text="Inserir" OnClick="btnInserir_Click" />
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <table class="table">
                <thead class="thead-dark">
                    <tr>
                        <th>#</th>
                        <th>Descrição</th>
                        <th>Edição</th>
                    </tr>
                </thead>
                <tbody>
                    <% foreach (jottondoborges.App_Code.DAO.Produto f in ps) {  %>
                    <tr>
                        <td><% Response.Write(f.id); %></td>
                        <td><% Response.Write(f.desc); %></td>
                        <td><a href="editar.aspx?uid=<% Response.Write(f.id); %>">Editar</a> <a href="../excluir.aspx?id=<% Response.Write(f.id); %>&t=<% Response.Write("p"); %>">Excluir</a>
                        </td>
                    </tr>
                    <% } %>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
