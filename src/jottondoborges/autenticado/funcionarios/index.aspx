<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="jottondoborges.autenticado.funcionarios.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Painel de Funcionários</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCorpo" runat="server">
    <div class="row">
        <div class="col">
            <h1>Cadastro de Funcionários 
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
                    <h5 class="modal-title" id="H1">Inserir Funcionário</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Fechar"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div id="formInserir">
                            <div class="form-group">
                                <label class="col-form-label" for="nome">Nome</label>
                                <input type="text" class="form-control" id="nome" name="n" placeholder="Nome" required />
                            </div>
                            <div class="form-group">
                                <label class="col-form-label" for="identidade">Identidade</label>
                                <input type="text" class="form-control" id="identidade" name="i" placeholder="Identidade" required />
                            </div>
                            <div class="form-group">
                                <legend class="col-form-legend">CLT</legend>
                                <input type="text" class="form-control" id="clt" name="d" placeholder="CLT" /required>
                            </div>
                            <div class="form-group">
                                <div class="form-row">
                                    <label class="col-form-label">Função</label>
                                </div>
                                <div class="form-check-inline">
                                    <label class="form-check-label">
                                        <input class="form-check-input" type="radio" name="f" value="M" required/>
                                        Motorista
                                    </label>
                                </div>
                                <div class="form-check-inline">
                                    <label class="form-check-label">
                                        <input class="form-check-input" type="radio" name="f" value="T" required />
                                        Técnico
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <legend class="col-form-legend">Salário</legend>
                                <input type="text" class="form-control" id="salario" name="s" placeholder="Salário" required/>
                            </div>
                            <div class="form-group">
                                <legend class="col-form-legend">Observação</legend>
                                <input type="text" class="form-control" id="obs" name="o" placeholder="Observação" required/>
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
                        <th>Motorista</th>
                        <th>Técnico</th>
                        <th>Identidade</th>
                        <th>CLT</th>
                        <th>Salário</th>
                        <th>Observação</th>
                        <th>Edição</th>
                    </tr>
                </thead>
                <tbody>
                    <% foreach (jottondoborges.App_Code.DAO.Funcionario f in fs) {  %>
                    <tr>
                        <td><% Response.Write(f.id); %></td>
                        <td><% Response.Write(f.nome); %></td>
                        <td><% Response.Write(f.telefone.telefone); %></td>
                        <td><% Response.Write(f.endereco.cidade); %></td>
                        <td><input type="checkbox" disabled <% Response.Write((f.motorista) ? "checked" : ""); %>/></td>
                        <td><input type="checkbox" disabled <% Response.Write((f.tecnico) ? "checked" : ""); %>/></td>
                        <td><% Response.Write(f.identidade); %></td>
                        <td><% Response.Write(f.CLT); %></td>
                        <td><% Response.Write(f.salario); %></td>
                        <td><% Response.Write(f.observacao); %></td>
                        <td><a href="editar.aspx?uid=<% Response.Write(f.id); %>">Editar</a> <a href="#">Excluir</a></td>
                    </tr>
                    <% } %>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
