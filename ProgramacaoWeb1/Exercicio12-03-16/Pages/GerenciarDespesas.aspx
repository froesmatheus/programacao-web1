<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="GerenciarDespesas.aspx.cs" Inherits="Exercicio12_03_16.CadastrarDespesa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        form {
            display: table;
            border-spacing: 10px;
        }

        p {
            display: table-row;
        }

        label {
            display: table-cell;
        }

        input {
            display: table-cell;
        }
    </style>

    <script type="text/javascript">
        function confirmacao() {
            return confirm("Você realmente deseja desativar esse tipo de despesa?");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel GroupingText="Tipos de Despesas" Width="650px" runat="server">
                <p>
                    <label>Categoria: </label>
                    <asp:DropDownList ID="drpDownCategorias" runat="server" Height="23px" Width="146px"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpDownCategorias" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                </p>

                <p>
                    <label>Tipo de despesa: </label>
                    <asp:TextBox ID="tbxTipoDespesa" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxTipoDespesa" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                </p>

                <p>
                    <label>Características: </label>
                    <asp:RadioButtonList ID="radBtnCaracteristicas" runat="server" RepeatLayout="Flow">
                        <asp:ListItem Text="Gasto com Produto ou Serviço" />
                        <asp:ListItem Text="Aplicação em Investimentos" />
                        <asp:ListItem Text="Transferência entre Contas" />
                    </asp:RadioButtonList>
                </p>


                <asp:Button runat="server" ID="btnCadastrar" Text="Cadastrar" OnClick="btnCadastrar_Click" />
            </asp:Panel>
            <br />
            <br />

            <asp:Panel runat="server" GroupingText="Lista de Tipos de Despesas" Width="648px">
                <p>
                    <label>
                        Categoria: 
                    <asp:DropDownList ID="drpDownCategorias2" runat="server" MaxLength="255" Style="margin-right: 5px" Width="250px" />
                    </label>

                    <p>
                        <label>Tipo de despesa: </label>
                        <asp:TextBox runat="server" ID="tbxTpDespesa"  />
                        <asp:Button Style="margin-left: 5px;" runat="server" ID="btnFiltrar" Text="Filtrar" CausesValidation="False" OnClick="btnFiltrar_Click" />
                        <asp:Button ID="btnExcluirFiltro" Style="margin-left: 5px;" Visible="false" runat="server" CausesValidation="False" OnClick="btnExcluirFiltro_Click" Text="X" />
                    </p>


                    <asp:GridView ID="grdDespesas" runat="server" Width="509px" ShowHeaderWhenEmpty="True" Style="margin: 10px;" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="Categoria">
                                <ItemTemplate>
                                    <p>
                                        <%# Eval("categoria.categoria") %>
                                    </p>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Tipo" DataField="tipoDespesa" />
                            <asp:BoundField HeaderText="Status" DataField="status">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEditar" runat="server" Height="19px" ImageUrl="~/Imagens/editar.png" Width="19px" CausesValidation="false" CommandArgument='<%# Eval("categoria") %>' OnClick="btnEditar_Click" />
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDesativar" runat="server" Height="19px" ImageUrl="~/Imagens/desativar.png" OnClientClick="if (!confirmacao()) return false;"
                                        CausesValidation="false" CommandName='<%# Eval("tipoDespesa") %>' CommandArgument='<%# Eval("categoria.categoria") %>' OnClick="btnDesativar_Click" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </p>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
