<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="jottondoborges.autenticado.fornecedores.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Painel de Fornecedores</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCorpo" runat="server">
    <div class="row">
        <div class="col">
            <h1>Cadastro de Fornecedores 
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
                    <h5 class="modal-title" id="H1">Inserir Cliente</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Fechar"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div id="formInserir">
                            <div class="form-group">
                                <label class="col-form-label" for="nome">Nome</label>
                                <input type="text" class="form-control" id="nome" name="n" placeholder="Nome" />
                            </div>
                            <div class="form-group">
                                <label class="col-form-label" for="email">E-mail</label>
                                <input type="text" class="form-control" id="email" name="m" placeholder="E-mail" />
                            </div>
                            <div class="form-group">
                                <legend class="col-form-legend">Documento</legend>
                                <input type="text" class="form-control" id="cpf" name="d" placeholder="CPF ou CNPJ" />
                            </div>
                            <div class="form-group">
                                <div class="form-check-inline">
                                    <label class="form-check-label">
                                        <input class="form-check-input" type="radio" name="td" value="CPF" />
                                        CPF
                                    </label>
                                </div>
                                <div class="form-check-inline">
                                    <label class="form-check-label">
                                        <input class="form-check-input" type="radio" name="td" value="CNPJ" />
                                        CNPJ
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                    <label for="validarTelefone">Telefone</label>
                                    <input type="text" class="form-control" id="validarTelefone" name="t" placeholder="Telefone" required>
                                    <div class="invalid-feedback">
                                        Entre um telefone.
                                    </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-md-6 mb-6">
                                    <label for="validarEstado">Estado</label>
                                    <input type="text" class="form-control" id="validarEstado" name="e" placeholder="Estado" required>
                                    <div class="invalid-feedback">
                                        Entre um Estado.
                                    </div>
                                </div>
                                <div class="col-md-6 mb-6">
                                    <label for="validarCidade">Cidade</label>
                                    <input type="text" class="form-control" id="validarCidade" name="c" placeholder="Cidade" required>
                                    <div class="invalid-feedback">
                                        Entre uma cidade.
                                    </div>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-md-6 mb-6">
                                    <label for="validarBairro">Bairro</label>
                                    <input type="text" class="form-control" id="validarBairro" name="b" placeholder="Bairro" required>
                                    <div class="invalid-feedback">
                                        Entre um bairro.
                                    </div>
                                </div>
                                <div class="col-md-6 mb-6">
                                    <label for="validarRua">Rua</label>
                                    <input type="text" class="form-control" id="validarRua" name="r" placeholder="Rua" required>
                                    <div class="invalid-feedback">
                                        Entre uma rua.
                                    </div>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-md-6 mb-6">
                                    <label for="validarNumero">Número</label>
                                    <input type="text" class="form-control" id="validarNumero" name="num" placeholder="Número" required>
                                    <div class="invalid-feedback">
                                        Entre um número.
                                    </div>
                                </div>
                                <div class="col-md-6 mb-6">
                                    <label for="complemento">Complemento</label>
                                    <input type="text" class="form-control" id="complemento" name="compl" placeholder="Complemento">
                                </div>
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
                        <th>Nome</th>
                        <th>Telefone</th>
                        <th>Cidade</th>
                        <th>CPF/CNPJ</th>
                        <th>Email</th>
                        <th>Edição</th>
                    </tr>
                </thead>
                <tbody>
                    <% foreach (jottondoborges.App_Code.DAO.Fornecedor c in fs)
                       {  %>
                    <tr>
                        <td><% Response.Write(c.id); %></td>
                        <td><% Response.Write(c.nome); %></td>
                        <td><% Response.Write(c.telefone.telefone); %></td>
                        <td><% Response.Write(c.endereco.cidade); %></td>
                        <td><% Response.Write((c.CPF != "" && c.CPF != null) ? c.CPF : c.CNPJ); %></td>
                        <td><% Response.Write(c.email); %></td>
                        <td><a href="editar.aspx?uid=<% Response.Write(c.id); %>">Editar</a> <a href="../excluir.aspx?id=<% Response.Write(c.id); %>&t=<% Response.Write("fo"); %>">Excluir</a></td>
                    </tr>
                    <% } %>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
