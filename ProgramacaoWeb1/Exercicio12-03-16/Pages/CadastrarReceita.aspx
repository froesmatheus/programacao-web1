<%@ Page MasterPageFile="~/MasterPage.Master" Language="C#" AutoEventWireup="true" CodeBehind="CadastrarReceita.aspx.cs" Inherits="Exercicio12_03_16.Pages.CadastrarReceita" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title></title>
    </head>
    <body>
        <asp:ScriptManager ID="ScriptManager" runat="server" />
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
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DataObjectTypeName="Exercicio12_03_16.Models.Receita" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetReceitas" TypeName="Exercicio12_03_16.Database.DAOs.ReceitaDAO" DeleteMethod="Delete" UpdateMethod="Update" OnInserted="ObjectDataSource2_Inserted" OnInserting="ObjectDataSource2_Inserting"></asp:ObjectDataSource>

            <asp:Panel GroupingText="Cadastro de Receitas" Style="padding: 10px;" Width="989px" runat="server" Height="603px">
                <asp:FormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="ObjectDataSource2" Width="994px" AllowPaging="True" OnItemInserting="FormView1_ItemInserting">


                    <EditItemTemplate>
                        <asp:TextBox Text='<%# Bind("Id") %>' ID="TextBox1" runat="server" Visible="false"></asp:TextBox>


                        <p>
                            <label>Tipo de Receita: </label>
                            <asp:DropDownList Text='<%# Bind("Tipo") %>' ID="drpDownTipoReceita" runat="server" Height="26px" Width="209px" DataSourceID="ObjectDataSource1" DataTextField="tipoReceita" DataValueField="tipoReceita"></asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetTiposReceita" TypeName="Exercicio12_03_16.Database.DAOs.TipoReceitaDAO">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="null" Name="categoriaReceita" Type="String" />
                                    <asp:Parameter DefaultValue="" Name="query" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpDownTipoReceita" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        </p>

                        <p>
                            <label>Forma recebimento: </label>
                            <asp:DropDownList Text='<%# Bind("FormaRecebimento") %>' ID="drpDownFormaRecebimento" runat="server" Height="29px" Width="202px">
                                <asp:ListItem>Cheque</asp:ListItem>
                                <asp:ListItem>Dinheiro</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drpDownFormaRecebimento" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        </p>

                        <p>
                            <label>Valor</label>
                            <asp:TextBox Text='<%# Bind("Valor") %>' ID="tbxValor" runat="server" MaxLength="255"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbxValor" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        </p>


                        <p>
                            <label>Data de vencimento: </label>
                            <asp:TextBox Text='<%# Bind("DataVencimento") %>' ID="tbxDataVenc" TextMode="Date" runat="server" MaxLength="255"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="tbxDataVenc" ErrorMessage="Data inválida" ForeColor="Red" Operator="GreaterThan" ValueToCompare="01/01/1900"></asp:CompareValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxDataVenc" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        </p>

                        <p>
                            <label>Data de recebimento: </label>
                            <asp:TextBox Text='<%# Bind("DataRecebimento") %>' ID="tbxDataRecebimento" TextMode="Date" runat="server" MaxLength="255"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="tbxDataRecebimento" ErrorMessage="Data inválida" ForeColor="Red" ValueToCompare="01/01/1900" Operator="GreaterThan"></asp:CompareValidator>
                        </p>

                        <p>
                            <label>Parcelamento:                       </label>
                            <asp:RadioButtonList Text='<%# Bind("TipoParcelamento") %>' ID="rdParcelamento" runat="server" RepeatLayout="Table" AutoPostBack="True" OnSelectedIndexChanged="rdParcelamento_SelectedIndexChanged">
                                <asp:ListItem Text="Único" />
                                <asp:ListItem Text="Dividido" />
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="rdParcelamento" ErrorMessage="* Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
                        </p>
                        <p>
                            <label>Parcelas: </label>
                            <asp:DropDownList Text='<%# Bind("QtdParcelas") %>' ID="drpDownParcelas" runat="server" Height="25px" Width="213px" Enabled="False">
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="drpDownParcelas" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        </p>

                        <label>Observações</label>

                        <p>
                            <asp:TextBox Text='<%# Bind("Observacoes") %>' TextMode="MultiLine" runat="server" Height="92px" Width="963px" ID="tbxObservacoes" />
                        </p>
                        <br />
                        <br />
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>



                    <EmptyDataTemplate>
                        Nenhuma receita<br />
                        <br />
                        <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="Adicionar" />
                    </EmptyDataTemplate>



                    <InsertItemTemplate>
                        <p>
                            <label>Tipo de Receita: </label>
                            <asp:DropDownList Text='<%# Bind("Tipo") %>' ID="drpDownTipoReceita" runat="server" Height="26px" Width="209px" DataSourceID="ObjectDataSource1" DataTextField="tipoReceita" DataValueField="tipoReceita"></asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetTiposReceita" TypeName="Exercicio12_03_16.Database.DAOs.TipoReceitaDAO">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="null" Name="categoriaReceita" Type="String" />
                                    <asp:Parameter DefaultValue="" Name="query" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpDownTipoReceita" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        </p>

                        <p>
                            <label>Forma recebimento: </label>
                            <asp:DropDownList Text='<%# Bind("FormaRecebimento") %>' ID="drpDownFormaRecebimento" runat="server" Height="29px" Width="202px">
                                <asp:ListItem>Cheque</asp:ListItem>
                                <asp:ListItem>Dinheiro</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drpDownFormaRecebimento" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        </p>

                        <p>
                            <label>Valor</label>
                            <asp:TextBox Text='<%# Bind("Valor") %>' ID="tbxValor" runat="server" MaxLength="255"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbxValor" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        </p>


                        <p>
                            <label>Data de vencimento: </label>
                            <asp:TextBox Text='<%# Bind("DataVencimento") %>' ID="tbxDataVenc" TextMode="Date" runat="server" MaxLength="255"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="tbxDataVenc" ErrorMessage="Data inválida" ForeColor="Red" Operator="GreaterThan" ValueToCompare="01/01/1900"></asp:CompareValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxDataVenc" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        </p>

                        <p>
                            <label>Data de recebimento: </label>
                            <asp:TextBox Text='<%# Bind("DataRecebimento") %>' ID="tbxDataRecebimento" TextMode="Date" runat="server" MaxLength="255"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="tbxDataRecebimento" ErrorMessage="Data inválida" ForeColor="Red" ValueToCompare="01/01/1900" Operator="GreaterThan"></asp:CompareValidator>
                        </p>

                        <p>
                            <label>Parcelamento:                       </label>
                            <asp:RadioButtonList Text='<%# Bind("TipoParcelamento") %>' ID="rdParcelamento" runat="server" RepeatLayout="Table" AutoPostBack="True" OnSelectedIndexChanged="rdParcelamento_SelectedIndexChanged">
                                <asp:ListItem Text="Único" />
                                <asp:ListItem Text="Dividido" />
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="rdParcelamento" ErrorMessage="* Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
                        </p>
                        <p>
                            <label>Parcelas: </label>
                            <asp:DropDownList Text='<%# Bind("QtdParcelas") %>' ID="drpDownParcelas" runat="server" Height="25px" Width="213px" Enabled="False">
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="drpDownParcelas" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        </p>

                        <label>Observações</label>

                        <p>
                            <asp:TextBox Text='<%# Bind("Observacoes") %>' TextMode="MultiLine" runat="server" Height="92px" Width="963px" ID="tbxObservacoes" />
                        </p>

                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Adicionar" />
                        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                    </InsertItemTemplate>



                    <ItemTemplate>
                        Tipo:
                    <asp:Label ID="tipoLabel" runat="server" Text='<%# Bind("Tipo") %>' />
                        <br />
                        Forma de Recebimento:
                    <asp:Label ID="formaRecebimentoLabel" runat="server" Text='<%# Bind("FormaRecebimento") %>' />
                        <br />
                        Valor:
                    <asp:Label ID="valorLabel" runat="server" Text='<%# Bind("Valor", "{0:N2}") %>' />
                        <br />
                        Data de Vencimento:
                    <asp:Label ID="dataVencimentoLabel" runat="server" Text='<%# Bind("DataVencimento", "{0:dd/MM/yyyy}") %>' />
                        <br />
                        Data de Recebimento:
                    <asp:Label ID="dataRecebimentoLabel" runat="server" Text='<%# Bind("DataRecebimento", "{0:dd/MM/yyyy}") %>' />
                        <br />
                        Tipo Parcelamento:
                    <asp:Label ID="tipoParcelamentoLabel" runat="server" Text='<%# Bind("TipoParcelamento") %>' />
                        <br />
                        Quantidade de Parcelas:
                    <asp:Label ID="qtParcelasLabel" runat="server" Text='<%# Bind("QtdParcelas") %>' />
                        <br />
                        Observações:
                    <asp:Label ID="observacoesLabel" runat="server" Text='<%# Bind("Observacoes") %>' />
                        <br />
                        <br />
                        <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="Adicionar" />
                        &nbsp;
                        <asp:LinkButton ID="DeleteButton0" runat="server" CausesValidation="False" CommandName="Edit" Text="Atualizar" />

                        &nbsp;
                        <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Excluir" />

                    </ItemTemplate>
                </asp:FormView>
            </asp:Panel>
        </div>
    </body>
    </html>

</asp:Content>
