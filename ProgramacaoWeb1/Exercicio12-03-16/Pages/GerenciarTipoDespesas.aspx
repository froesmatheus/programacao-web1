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

            <asp:Panel GroupingText="Tipos de Despesas" Width="650px" runat="server">
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCategorias" TypeName="Exercicio12_03_16.Database.DAOs.CategoriaDespesaDAO">
                    <SelectParameters>
                        <asp:Parameter Name="query" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource1" DefaultMode="Insert" AllowPaging="True" Width="641px" OnItemInserting="FormView1_ItemInserting" OnItemUpdating="FormView1_ItemUpdating">



                    <EditItemTemplate>
                        <p>
                            <label>Categoria: </label>
                            <asp:DropDownList Text='<%# Bind("categoria") %>' ID="drpDownCategorias" runat="server" Height="23px" Width="146px" DataSourceID="ObjectDataSource2" DataTextField="categoria" DataValueField="categoria"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpDownCategorias" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        </p>

                        <p>
                            <label>Tipo de despesa: </label>
                            <asp:TextBox ID="tbxTipoDespesa" Text='<%# Bind("tipoDespesa") %>' runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxTipoDespesa" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        </p>

                        <p>
                            <label>Características: </label>
                            <br />
                            <asp:RadioButtonList ID="radBtnCaracteristicas" Text='<%# Bind("caracteristica") %>' runat="server" RepeatLayout="Flow">
                                <asp:ListItem Text="Gasto com Produto ou Serviço" Value="0" />
                                <asp:ListItem Text="Aplicação em Investimentos" Value="1" />
                                <asp:ListItem Text="Transferência entre Contas" Value="2" />
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="radBtnCaracteristicas" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                            <asp:TextBox ID="tbxTipoDespesa0" runat="server" Text='<%# Bind("id") %>' Visible="False"></asp:TextBox>
                        </p>
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Atualizar" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                    </EditItemTemplate>




                    <InsertItemTemplate>
                        <p>
                            <label>Categoria: </label>
                            <asp:DropDownList Text='<%# Bind("categoria") %>' ID="drpDownCategorias" runat="server" Height="23px" Width="146px" DataSourceID="ObjectDataSource2" DataTextField="categoria" DataValueField="categoria"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpDownCategorias" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        </p>

                        <p>
                            <label>Tipo de despesa: </label>
                            <asp:TextBox ID="tbxTipoDespesa" Text='<%# Bind("tipoDespesa") %>' runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxTipoDespesa" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        </p>

                        <p>
                            <label>Características: </label>
                            <br />
                            <asp:RadioButtonList ID="radBtnCaracteristicas" Text='<%# Bind("caracteristica") %>' runat="server" RepeatLayout="Flow">
                                <asp:ListItem Text="Gasto com Produto ou Serviço" Value="0" />
                                <asp:ListItem Text="Aplicação em Investimentos" Value="1" />
                                <asp:ListItem Text="Transferência entre Contas" Value="2" />
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="radBtnCaracteristicas" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        </p>

                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Adicionar" />
                        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                    </InsertItemTemplate>





                    <ItemTemplate>
                        id:
                        <asp:Label ID="idLabel" runat="server" Text='<%# Bind("id") %>' />
                        <br />
                        categoria:
                        <asp:Label ID="categoriaLabel" runat="server" Text='<%# Bind("categoria") %>' />
                        <br />
                        tipoDespesa:
                        <asp:Label ID="tipoDespesaLabel" runat="server" Text='<%# Bind("tipoDespesa") %>' />
                        <br />
                        caracteristica:
                        <asp:Label ID="caracteristicaLabel" runat="server" Text='<%# Bind("caracteristica") %>' />
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

            <asp:Panel runat="server" GroupingText="Lista de Tipos de Despesas" Width="648px" Style="padding: 5px;">
                <label>
                    Categoria: 
                    <asp:DropDownList ID="drpDownCategorias2" runat="server" MaxLength="255" Style="margin-right: 5px" Width="250px" DataSourceID="ObjectDataSource2" DataTextField="categoria" DataValueField="categoria" AppendDataBoundItems="True">
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
                    <asp:GridView ID="grdDespesas" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" Style="margin: 10px;" Width="582px" DataSourceID="ObjectDataSource1" OnSelectedIndexChanged="grdDespesas_SelectedIndexChanged">
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
                                    <asp:ImageButton ID="btnEditar" runat="server" CausesValidation="false" CommandArgument='<%# Eval("categoria.categoria") %>' CommandName='Select' Height="19px" ImageUrl="~/Images/editar.png" OnClick="btnEditar_Click" Width="19px" />
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
