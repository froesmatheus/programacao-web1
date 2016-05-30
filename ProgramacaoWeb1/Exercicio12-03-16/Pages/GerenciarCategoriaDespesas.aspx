<%@ Page MasterPageFile="~/MasterPage.Master" Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="GerenciarCategoriaDespesas.aspx.cs" Inherits="Exercicio12_03_16.GerenciarDespesas" %>

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
                return confirm("Você realmente deseja alterar o status dessa categoria?");
            }
        </script>
    </head>
    <body>

        <ajaxToolkit:ModalPopupExtender 
            ID="ModalPopupExtender1" 
            PopupControlID="ModalPanel"
            CancelControlID="btnFechar"
            TargetControlID="labelModal"
            DropShadow="true"
            runat="server" />

        <asp:Label ID="labelModal" runat="server"/>

        <asp:Panel ID="ModalPanel" runat="server" BackColor="#0033cc" Style="padding: 16px;">
            <asp:Label ForeColor="#ffffff" Font-Bold="true" Font-Size="Medium" ID="LabelMessage" runat="server" />
            <br />
            <br />
            <asp:Button CausesValidation="false" ID="btnFechar" runat="server" Text="OK" />
        </asp:Panel>

        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:Panel runat="server" GroupingText="Categoria de Despesas" Width="560px">
                <label>&nbsp;</label><asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource1" DefaultMode="Insert" Width="531px">
                    <EditItemTemplate>
                        <label>Categoria: </label>
                        <asp:TextBox ID="tbxCategoria" Text='<%# Bind("categoria") %>' runat="server" Width="250px" MaxLength="255" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxCategoria" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox ID="tbxId" runat="server" MaxLength="255" Text='<%# Bind("id") %>' Width="250px" Visible="False" />
                        <p>
                            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Atualizar" />
                            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                        </p>

                    </EditItemTemplate>

                    <InsertItemTemplate>
                        <label>Categoria: </label>
                        <asp:TextBox ID="tbxCategoria" Text='<%# Bind("categoria") %>' runat="server" Width="250px" MaxLength="255" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxCategoria" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        <p>
                            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Adicionar" />
                            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                        </p>
                    </InsertItemTemplate>


                    <ItemTemplate>
                        id:
                            <asp:Label ID="idLabel" runat="server" Text='<%# Bind("id") %>' />
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
            <asp:Panel runat="server" GroupingText="Lista Categoria de Despesas" Width="550px">
                <p>
                    <label>Categoria: </label>
                    <asp:TextBox ID="tbxBuscarDepesa" runat="server" Width="250px" MaxLength="255" Style="margin-right: 5px" />

                    <ajaxToolkit:AutoCompleteExtender
                        runat="server"
                        ID="autoComplete1"
                        TargetControlID="tbxBuscarDepesa"
                        ServiceMethod="GetCompletionList"
                        ServicePath="~/Servico.asmx"
                        MinimumPrefixLength="1"
                        CompletionInterval="1000"
                        EnableCaching="true"
                        DelimiterCharacters=";" />


                    <asp:Button runat="server" ID="btnFiltrar0" Text="Filtrar" CausesValidation="False" OnClick="btnFiltrar_Click" />

                    <asp:Button ID="btnExcluirFiltro" Style="margin-left: 5px;" Visible="false" runat="server" CausesValidation="False" OnClick="btnExcluirFiltro_Click" Text="X" />

                    <asp:GridView ID="grdDespesas" runat="server" Width="509px" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnSelectedIndexChanged="grdDespesas_SelectedIndexChanged">
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
                                    <asp:ImageButton ID="btnEditar" CommandName='Select' CommandArgument='<%# Eval("categoria") %>' CausesValidation="false" runat="server" Height="17px" ImageUrl="~/Images/editar.png" OnClick="btnEditar_Click" Width="18px" />
                                </ItemTemplate>
                                <HeaderStyle BackColor="Black" ForeColor="White" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDesativar" CommandName='<%# Eval("id") %>' CommandArgument='<%# Eval("categoria") %>' CausesValidation="false" runat="server" Height="17px" OnClientClick="if (!confirmacao()) return false;" ImageUrl="~/Images/desativar.png" OnClick="btnDesativar_Click" Width="18px" />
                                </ItemTemplate>
                                <HeaderStyle BackColor="Black" ForeColor="White" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                   
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Exercicio12_03_16.CategoriaDespesa" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCategorias" TypeName="Exercicio12_03_16.Database.DAOs.CategoriaDespesaDAO" UpdateMethod="Update" OnInserted="ObjectDataSource1_Inserted">
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

