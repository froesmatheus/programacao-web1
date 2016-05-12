<%@ Page MasterPageFile="~/MasterPage.Master" Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="GerenciarTipoDespesas.aspx.cs" Inherits="Exercicio12_03_16.CadastrarDespesa" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title></title>


        <script type="text/javascript">
            function confirmacao() {
                return confirm("Você realmente deseja desativar esse tipo de despesa?");
            }
        </script>
    </head>
    <body>
        <div>
            <asp:ImageButton CausesValidation="false" ID="btnVoltar" runat="server" ImageUrl="~/Images/voltar.png" Style="margin: 5px;" OnClick="btnVoltar_Click" />

            <asp:Panel GroupingText="Tipos de Despesas" Width="650px" runat="server">
                <p>
                    <label>Categoria: </label>
                    <asp:DropDownList ID="drpDownCategorias" runat="server" Height="23px" Width="146px" DataSourceID="ObjectDataSource2" DataTextField="categoria" DataValueField="categoria"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpDownCategorias" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                </p>

                <p>
                    <label>Tipo de despesa: </label>
                    <asp:TextBox ID="tbxTipoDespesa" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxTipoDespesa" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                </p>

                <p>
                    <label>Características: </label>
                    <br />
                    <asp:RadioButtonList ID="radBtnCaracteristicas" runat="server" RepeatLayout="Flow">
                        <asp:ListItem Text="Gasto com Produto ou Serviço" Value="0" />
                        <asp:ListItem Text="Aplicação em Investimentos" Value="1" />
                        <asp:ListItem Text="Transferência entre Contas" Value="2" />
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="radBtnCaracteristicas" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                </p>


                <asp:Button runat="server" ID="btnCadastrar" Text="Cadastrar" OnClick="btnCadastrar_Click" />
                <asp:Button ID="btnCancelar" Style="margin-left: 5px;" Visible="false" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCategorias" TypeName="Exercicio12_03_16.Database.DAOs.CategoriaDespesaDAO">
                    <SelectParameters>
                        <asp:Parameter Name="query" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>
            <br />
            <br />

            <asp:Panel runat="server" GroupingText="Lista de Tipos de Despesas" Width="648px" style="padding:5px;">
                <label>
                    Categoria: 
                    <asp:DropDownList ID="drpDownCategorias2" runat="server" MaxLength="255" Style="margin-right: 5px" Width="250px" DataSourceID="ObjectDataSource2" DataTextField="categoria" DataValueField="categoria" AppendDataBoundItems="True" >
                        <asp:ListItem Selected="True" Value="null">Todos</asp:ListItem>
                </asp:DropDownList>
                </label>

                <p>
                    <label>Tipo de despesa: </label>
                    <asp:TextBox runat="server" ID="tbxTpDespesa" />
                    <asp:Button Style="margin-left: 5px;" runat="server" ID="btnFiltrar" Text="Filtrar" CausesValidation="False" OnClick="btnFiltrar_Click" />
                    <asp:Button ID="btnExcluirFiltro" Style="margin-left: 5px;" Visible="false" runat="server" CausesValidation="False" OnClick="btnExcluirFiltro_Click" Text="X" />
                </p>


                <p>
                    <asp:GridView ID="grdDespesas" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" Style="margin: 10px;" Width="582px" DataSourceID="ObjectDataSource1">
                        <Columns>
                            <asp:TemplateField HeaderText="Categoria">
                                <ItemTemplate>
                                    <p>
                                        <%# Eval("categoria.categoria") %>
                                    </p>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="tipoDespesa" HeaderText="Tipo" />
                            <asp:BoundField DataField="status" HeaderText="Status">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEditar" runat="server" CausesValidation="false" CommandArgument='<%# Eval("categoria.categoria") %>' CommandName='<%# Eval("tipoDespesa") %>' Height="19px" ImageUrl="~/Images/editar.png" OnClick="btnEditar_Click" Width="19px" />
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDesativar" runat="server" CausesValidation="false" CommandArgument='<%# Eval("categoria.categoria") %>' CommandName='<%# Eval("tipoDespesa") %>' Height="19px" ImageUrl="~/Images/desativar.png" OnClick="btnDesativar_Click" OnClientClick="if (!confirmacao()) return false;" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Exercicio12_03_16.Models.TipoDespesa" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetTiposDespesa" TypeName="Exercicio12_03_16.Database.DAOs.TipoDespesaDAO" UpdateMethod="Update">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="drpDownCategorias2" Name="categoria" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="tbxTpDespesa" Name="query" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </p>
            </asp:Panel>
        </div>
    </body>
    </html>
</asp:Content>
