<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="jottondoborges.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Jotton do Borges</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCorpo" runat="server">
    <header class="row">
        <div class="col">
            <h1>Bem vindo ao Jotton do Borges</h1>
            <h3>Não somos o Bottons do Jorge</h3>
        </div>
    </header>
    <main class="row">
        <div class="col">
            <ul class="list-unstyled">
                <li><a href="autenticado/clientes/index.aspx">Painel Clientes</a></li>
                <li><a href="autenticado/funcionarios/index.aspx">Painel Funcionários</a></li>
            </ul>
        </div>
    </main>
</asp:Content>
