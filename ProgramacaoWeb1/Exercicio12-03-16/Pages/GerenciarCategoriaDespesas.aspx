﻿<%@ Page MasterPageFile="~/MasterPage.Master" Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="GerenciarCategoriaDespesas.aspx.cs" Inherits="Exercicio12_03_16.GerenciarDespesas" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title></title>
        <style>
            table {
                margin: 10px 11px 10px 10px;
            }
        </style>

        <script type="text/javascript">
            function confirmacao() {
                return confirm("Você realmente deseja desativar essa categoria?");
            }
        </script>
    </head>
    <body>
        <div>
            <asp:ImageButton CausesValidation="false" ID="btnVoltar" runat="server" ImageUrl="~/Images/voltar.png" Style="margin: 5px;" OnClick="btnVoltar_Click" />

            <asp:Panel runat="server" GroupingText="Categoria de Despesas" Width="560px">
                <p>
                    <label>Categoria: </label>
                    <asp:TextBox ID="tbxCategoria" runat="server" Width="250px" MaxLength="255" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxCategoria" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                </p>

                <asp:Button runat="server" ID="btnCadastrar" Text="Cadastrar" OnClick="btnCadastrar_Click" />

                <asp:Button ID="btnCancelar" runat="server" Style="margin-left: 5px;" OnClick="btnCancelar_Click" Text="Cancelar" Visible="false" />

            </asp:Panel>

            <br />
            <br />
            <asp:Panel runat="server" GroupingText="Lista Categoria de Despesas" Width="550px">
                <p>
                    <label>Categoria: </label>
                    <asp:TextBox ID="tbxBuscarDepesa" runat="server" Width="250px" MaxLength="255" Style="margin-right: 5px" />
                    <asp:Button runat="server" ID="btnFiltrar0" Text="Filtrar" CausesValidation="False" OnClick="btnFiltrar_Click" />

                    <asp:Button ID="btnExcluirFiltro" Style="margin-left: 5px;" Visible="false" runat="server" CausesValidation="False" OnClick="btnExcluirFiltro_Click" Text="X" />

                    <asp:GridView ID="grdDespesas" runat="server" Width="509px" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
                        <Columns>
                            <asp:BoundField HeaderText="Categoria" DataField="categoria" SortExpression="categoria">
                                <HeaderStyle BackColor="Black" ForeColor="White" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Black" />
                            </asp:BoundField>
                            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status">
                            <HeaderStyle BackColor="Black" ForeColor="White" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEditar" CommandName='<%# Eval("categoria") %>' CommandArgument='<%# Eval("categoria") %>' CausesValidation="false" runat="server" Height="17px" ImageUrl="~/Images/editar.png" OnClick="btnEditar_Click" Width="18px" />
                                </ItemTemplate>
                                <HeaderStyle BackColor="Black" ForeColor="White" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDesativar" CommandName='<%# Eval("categoria") %>' CommandArgument='<%# Eval("categoria") %>' CausesValidation="false" runat="server" Height="17px" ImageUrl="~/Images/desativar.png" OnClick="btnDesativar_Click" Width="18px" />
                                </ItemTemplate>
                                <HeaderStyle BackColor="Black" ForeColor="White" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Exercicio12_03_16.CategoriaDespesa" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCategorias" TypeName="Exercicio12_03_16.Database.DAOs.CategoriaDespesaDAO" UpdateMethod="Update">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="tbxBuscarDepesa" DefaultValue="" Name="query" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>

                </p>
            </asp:Panel>
        </div>
    </body>
    </html>
</asp:Content>

