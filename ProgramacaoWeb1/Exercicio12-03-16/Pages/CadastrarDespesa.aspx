<%@ Page MasterPageFile="~/MasterPage.Master" Language="C#" AutoEventWireup="true" CodeBehind="CadastrarDespesa.aspx.cs" Inherits="Exercicio12_03_16.Pages.CadastrarDespesa" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title></title>
    </head>
    <body>
        <div>
            <asp:ImageButton CausesValidation="false" ID="btnVoltar" runat="server" ImageUrl="~/Images/voltar.png" Style="margin: 5px;" OnClick="btnVoltar_Click" />


            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DataObjectTypeName="Exercicio12_03_16.Models.Despesa" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDespesas" TypeName="Exercicio12_03_16.Database.DespesaDAO"></asp:ObjectDataSource>

            <asp:Panel GroupingText="Cadastro de Despesas" Style="padding: 10px;" Width="989px" runat="server" Height="603px">
                <asp:FormView ID="FormView1" runat="server" AllowPaging="True" DataSourceID="ObjectDataSource2" DefaultMode="Insert" Width="685px">
                    <EditItemTemplate>
                        tipo:
                    <asp:TextBox ID="tipoTextBox" runat="server" Text='<%# Bind("tipo") %>' />
                        <br />
                        formaRecebimento:
                    <asp:TextBox ID="formaRecebimentoTextBox" runat="server" Text='<%# Bind("formaRecebimento") %>' />
                        <br />
                        valor:
                    <asp:TextBox ID="valorTextBox" runat="server" Text='<%# Bind("valor") %>' />
                        <br />
                        dataVencimento:
                    <asp:TextBox ID="dataVencimentoTextBox" runat="server" Text='<%# Bind("dataVencimento") %>' />
                        <br />
                        dataRecebimento:
                    <asp:TextBox ID="dataRecebimentoTextBox" runat="server" Text='<%# Bind("dataRecebimento") %>' />
                        <br />
                        tipoParcelamento:
                    <asp:TextBox ID="tipoParcelamentoTextBox" runat="server" Text='<%# Bind("tipoParcelamento") %>' />
                        <br />
                        qtParcelas:
                    <asp:TextBox ID="qtParcelasTextBox" runat="server" Text='<%# Bind("qtParcelas") %>' />
                        <br />
                        parcela:
                    <asp:TextBox ID="parcelaTextBox" runat="server" Text='<%# Bind("parcela") %>' />
                        <br />
                        observacoes:
                    <asp:TextBox ID="observacoesTextBox" runat="server" Text='<%# Bind("observacoes") %>' />
                        <br />
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>



                    <InsertItemTemplate>
                        <p>
                            <label>Tipo de Despesa: </label>
                            <asp:DropDownList ID="drpDownTipoDespesa" Text='<%# Bind("tipo") %>' runat="server" Height="26px" Width="209px" DataSourceID="ObjectDataSource1" DataTextField="tipoDespesa" DataValueField="tipoDespesa"></asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetTiposDespesa" TypeName="Exercicio12_03_16.Database.DAOs.TipoDespesaDAO"></asp:ObjectDataSource>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpDownTipoDespesa" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        </p>

                        <p>
                            <label>Forma recebimento: </label>
                            <asp:DropDownList Text='<%# Bind("formaRecebimento") %>' ID="drpDownFormaRecebimento" runat="server" Height="29px" Width="202px">
                                <asp:ListItem>Cheque</asp:ListItem>
                                <asp:ListItem>Dinheiro</asp:ListItem>
                                <asp:ListItem>Cartão</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drpDownFormaRecebimento" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        </p>

                        <p>
                            <label>Valor</label>
                            <asp:TextBox Text='<%# Bind("valor") %>' ID="tbxValor" runat="server" MaxLength="255"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbxValor" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        </p>


                        <p>
                            <label>Data de vencimento: </label>
                            <asp:TextBox Text='<%# Bind("dataVencimento") %>' ID="tbxDataVenc" TextMode="Date" runat="server" MaxLength="255"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="tbxDataVenc" ErrorMessage="Data inválida" ForeColor="Red" Operator="GreaterThan" ValueToCompare="01/01/1900"></asp:CompareValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxDataVenc" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                        </p>

                        <p>
                            <label>Data de pagamento: </label>
                            <asp:TextBox Text='<%# Bind("dataRecebimento") %>' ID="tbxDataRecebimento" TextMode="Date" runat="server" MaxLength="255"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="tbxDataRecebimento" ErrorMessage="Data inválida" ForeColor="Red" ValueToCompare="01/01/1900" Operator="GreaterThan"></asp:CompareValidator>
                        </p>

                        <p>
                            <label>Parcelamento:                       </label>
                            <asp:RadioButtonList Text='<%# Bind("tipoParcelamento") %>' ID="rdParcelamento" runat="server" RepeatLayout="Table" AutoPostBack="True" OnSelectedIndexChanged="rdParcelamento_SelectedIndexChanged">
                                <asp:ListItem Text="Único" />
                                <asp:ListItem Text="Dividido" />
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="rdParcelamento" ErrorMessage="* Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
                        </p>
                        <p>
                            <label>Parcelas: </label>
                            <asp:DropDownList Text='<%# Bind("qtParcelas") %>' ID="drpDownParcelas" runat="server" Height="25px" Width="213px" Enabled="False">
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
                            <asp:TextBox ID="tbxObservacoes" Text='<%# Bind("observacoes") %>' TextMode="MultiLine" runat="server" Height="92px" Width="963px" />
                        </p>


                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Adicionar" />
                        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                    </InsertItemTemplate>



                    <ItemTemplate>
                        tipo:
                    <asp:Label ID="tipoLabel" runat="server" Text='<%# Bind("tipo") %>' />
                        <br />
                        formaRecebimento:
                    <asp:Label ID="formaRecebimentoLabel" runat="server" Text='<%# Bind("formaRecebimento") %>' />
                        <br />
                        valor:
                    <asp:Label ID="valorLabel" runat="server" Text='<%# Bind("valor") %>' />
                        <br />
                        dataVencimento:
                    <asp:Label ID="dataVencimentoLabel" runat="server" Text='<%# Bind("dataVencimento") %>' />
                        <br />
                        dataRecebimento:
                    <asp:Label ID="dataRecebimentoLabel" runat="server" Text='<%# Bind("dataRecebimento") %>' />
                        <br />
                        tipoParcelamento:
                    <asp:Label ID="tipoParcelamentoLabel" runat="server" Text='<%# Bind("tipoParcelamento") %>' />
                        <br />
                        qtParcelas:
                    <asp:Label ID="qtParcelasLabel" runat="server" Text='<%# Bind("qtParcelas") %>' />
                        <br />
                        parcela:
                    <asp:Label ID="parcelaLabel" runat="server" Text='<%# Bind("parcela") %>' />
                        <br />
                        observacoes:
                    <asp:Label ID="observacoesLabel" runat="server" Text='<%# Bind("observacoes") %>' />
                        <br />
                        <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
                    </ItemTemplate>
                </asp:FormView>
            </asp:Panel>
        </div>
    </body>
    </html>

</asp:Content>
