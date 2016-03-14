<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="GerenciarCategoriaDespesas.aspx.cs" Inherits="Exercicio12_03_16.GerenciarDespesas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        table {
            margin: 10px;
        }
    </style>

    <script type="text/javascript">
        function confirmacao() {
            return confirm("Você realmente deseja desativar essa categoria?");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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

                    <asp:Button ID="btnExcluirFiltro" Style="margin-left:5px;" Visible="false" runat="server" CausesValidation="False" OnClick="btnExcluirFiltro_Click" Text="X" />

                    <asp:GridView ID="grdDespesas" runat="server" Width="509px" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField HeaderText="Categoria" DataField="categoria" />
                            <asp:BoundField HeaderText="Status" DataField="status">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEditar" runat="server" Height="19px" ImageUrl="../Imagens/editar.png" Width="19px" CausesValidation="false" CommandArgument='<%# Eval("categoria") %>' OnClick="btnEditar_Click" />
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDesativar" runat="server" Height="19px" ImageUrl="../Imagens/desativar.png" OnClientClick="if (!confirmacao()) return false;"
                                        CausesValidation="false" CommandArgument='<%# Eval("categoria") %>' OnClick="btnDesativar_Click" />
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
