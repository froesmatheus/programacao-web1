<%@ Page MasterPageFile="~/MasterPage.Master" Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="GerenciarTipoReceitas.aspx.cs" Inherits="Exercicio12_03_16.Pages.ManutencaoReceitas" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title></title>
        <script type="text/javascript">
            function confirmacao() {
                return confirm("Você realmente deseja alterar o status deste tipo de receita?");
            }
        </script>
    </head>
    <body>
        <div>

            <asp:Panel GroupingText="Manutenção de Tipo de Receita" Width="650px" runat="server">
                <asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource1" DefaultMode="Insert" Width="632px" Height="103px" AllowPaging="True">


                    <EditItemTemplate>
                        id:
                            <asp:TextBox ID="idTextBox" Visible="false" runat="server" Text='<%# Bind("id") %>' />
                        <br />
                        <p>
                            <label>Tipo de Receita: </label>
                            <asp:TextBox ID="tbxTxtReceita" Text='<%# Bind("tipoReceita") %>' runat="server" MaxLength="255"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxTxtReceita" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        </p>

                        <p>
                            <label>Categoria de Tipo Receita: </label>
                            <asp:DropDownList Text='<%# Bind("categoria") %>' ID="drpDownCategoriaReceita" runat="server" Height="25px" Width="212px">
                                <asp:ListItem>Receitas em Geral</asp:ListItem>
                                <asp:ListItem>Transferência entre Contas</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpDownCategoriaReceita" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                       </p>     
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Atualizar" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                    </EditItemTemplate>


                    <InsertItemTemplate>
                        <p>
                            <label>Tipo de Receita: </label>
                            <asp:TextBox ID="tbxTxtReceita" Text='<%# Bind("tipoReceita") %>' runat="server" MaxLength="255"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxTxtReceita" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        </p>

                        <p>
                            <label>Categoria de Tipo Receita: </label>
                            <asp:DropDownList Text='<%# Bind("categoria") %>' ID="drpDownCategoriaReceita" runat="server" Height="25px" Width="212px">
                                <asp:ListItem>Receitas em Geral</asp:ListItem>
                                <asp:ListItem>Transferência entre Contas</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpDownCategoriaReceita" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                       </p>     
                       
                            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Adicionar" />
                            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                    </InsertItemTemplate>


                    <ItemTemplate>
                        id:
                            <asp:Label ID="idLabel" runat="server" Text='<%# Bind("id") %>' />
                        <br />
                        tipoReceita:
                            <asp:Label ID="tipoReceitaLabel" runat="server" Text='<%# Bind("tipoReceita") %>' />
                        <br />
                        categoria:
                            <asp:Label ID="categoriaLabel" runat="server" Text='<%# Bind("categoria") %>' />
                        <br />
                        status:
                            <asp:Label ID="statusLabel" runat="server" Text='<%# Bind("status") %>' />
                        <br />
                        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                        &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
                    </ItemTemplate>
                </asp:FormView>


            </asp:Panel>
            <br />
            <br />

            <asp:Panel runat="server" GroupingText="Lista Tipo Receita" Width="648px">

                <p>
                    <label>Tipo de Receita: </label>
                    <asp:TextBox runat="server" ID="tbxReceita" />
                </p>
                Categoria de T<label>ipo Receita
                <asp:DropDownList ID="drpDownCategoriaReceita2" runat="server" MaxLength="255" Style="margin-right: 5px" Width="250px" AppendDataBoundItems="True">
                    <asp:ListItem Selected="True" Value="null">Todos</asp:ListItem>
                    <asp:ListItem>Receitas em Geral</asp:ListItem>
                    <asp:ListItem>Transferência entre Contas</asp:ListItem>
                </asp:DropDownList>
                </label>

                <p>
                    <asp:Button Style="margin-left: 5px;" runat="server" ID="btnFiltrar" Text="Filtrar" CausesValidation="False" OnClick="btnFiltrar_Click" />
                    <asp:Button ID="btnExcluirFiltro" Style="margin-left: 5px;" Visible="false" runat="server" CausesValidation="False" OnClick="btnExcluirFiltro_Click" Text="X" />
                </p>

                <asp:GridView ID="grdReceitas" runat="server" Width="509px" ShowHeaderWhenEmpty="True" Style="margin: 10px;" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" AllowPaging="True" OnSelectedIndexChanged="grdReceitas_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Tipo de Receita" DataField="tipoReceita" SortExpression="tipoReceita">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="categoria" HeaderText="Categoria" SortExpression="categoria">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Status" DataField="status">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnEditar" runat="server" Height="19px" ImageUrl="~/Images/editar.png" Width="19px" CausesValidation="false" CommandName='Select' CommandArgument='<%# Eval("tipoReceita") %>' OnClick="btnEditar_Click" />
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnDesativar" runat="server" Height="19px" ImageUrl="~/Images/desativar.png" OnClientClick="if (!confirmacao()) return false;"
                                    CausesValidation="false" CommandName='<%# Eval("categoria") %>' CommandArgument='<%# Eval("tipoReceita") %>' OnClick="btnDesativar_Click" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Exercicio12_03_16.Models.TipoReceita" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetTiposReceita" TypeName="Exercicio12_03_16.Database.DAOs.TipoReceitaDAO" UpdateMethod="Update">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="drpDownCategoriaReceita2" Name="categoriaReceita" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="tbxReceita" Name="query" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <p>
                </p>
            </asp:Panel>
        </div>
    </body>
    </html>
</asp:Content>

