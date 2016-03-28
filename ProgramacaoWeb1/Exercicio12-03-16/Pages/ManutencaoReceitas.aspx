<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ManutencaoReceitas.aspx.cs" Inherits="Exercicio12_03_16.Pages.ManutencaoReceitas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function confirmacao() {
            return confirm("Você realmente deseja desativar essa receita?");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel GroupingText="Manutenção de Receita" Width="650px" runat="server">
                <p>
                    <label>Receita: </label>
                    <asp:TextBox ID="tbxTxtReceita" runat="server" MaxLength="255"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxTxtReceita" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                </p>

                <p>
                    <label>Categoria de Receita: </label>
                    <asp:DropDownList ID="drpDownCategoriaReceita" runat="server" Height="25px" Width="212px"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpDownCategoriaReceita" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                </p>

                <asp:Button runat="server" ID="btnCadastrar" Text="Cadastrar" OnClick="btnCadastrar_Click" />
                <asp:Button ID="btnCancelar" Style="margin-left: 5px;" Visible="false" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            </asp:Panel>
            <br />
            <br />

            <asp:Panel runat="server" GroupingText="Lista Receita" Width="648px">

                <p>
                    <label>Receita: </label>
                    <asp:TextBox runat="server" ID="tbxReceita" />
                </p>
                <label>
                    Tipo de Receita
                    <asp:DropDownList ID="drpDownCategoriaReceita2" runat="server" MaxLength="255" Style="margin-right: 5px" Width="250px" />
                </label>

                <p>
                    <asp:Button Style="margin-left: 5px;" runat="server" ID="btnFiltrar" Text="Filtrar" CausesValidation="False" OnClick="btnFiltrar_Click" />
                    <asp:Button ID="btnExcluirFiltro" Style="margin-left: 5px;" Visible="false" runat="server" CausesValidation="False" OnClick="btnExcluirFiltro_Click" Text="X" />
                </p>

                <asp:GridView ID="grdReceitas" runat="server" Width="509px" ShowHeaderWhenEmpty="True" Style="margin: 10px;" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="Receita">
                            <ItemTemplate>
                                <p>
                                    <%# Eval("receita") %>
                                </p>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Tipo" DataField="tipoReceita" />
                        <asp:BoundField HeaderText="Status" DataField="status">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnEditar" runat="server" Height="19px" ImageUrl="~/Imagens/editar.png" Width="19px" CausesValidation="false" CommandName='<%# Eval("receita") %>' CommandArgument='<%# Eval("tipoReceita") %>' OnClick="btnEditar_Click" />
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
                                    CausesValidation="false" CommandName='<%# Eval("receita") %>' CommandArgument='<%# Eval("tipoReceita") %>' OnClick="btnDesativar_Click" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <p>
                </p>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
