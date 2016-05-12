<%@ Page MasterPageFile="~/MasterPage.Master" Language="C#" AutoEventWireup="true" CodeBehind="CadastrarReceita.aspx.cs" Inherits="Exercicio12_03_16.Pages.CadastrarReceita" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title></title>
    </head>
    <body>
        <div>
            <asp:ImageButton CausesValidation="false" ID="btnVoltar" runat="server" ImageUrl="~/Images/voltar.png" Style="margin: 5px;" OnClick="btnVoltar_Click" />

            <asp:Panel GroupingText="Cadastro de Receitas" Style="padding: 10px;" Width="989px" runat="server" Height="603px">
                <p>
                    <label>Tipo de Receita: </label>
                    <asp:DropDownList ID="drpDownTipoReceita" runat="server" Height="26px" Width="209px" DataSourceID="ObjectDataSource1" DataTextField="tipoReceita" DataValueField="tipoReceita"></asp:DropDownList>
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
                    <asp:DropDownList ID="drpDownFormaRecebimento" runat="server" Height="29px" Width="202px">
                        <asp:ListItem>Cheque</asp:ListItem>
                        <asp:ListItem>Dinheiro</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drpDownFormaRecebimento" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                </p>

                <p>
                    <label>Valor</label>
                    <asp:TextBox ID="tbxValor" runat="server" MaxLength="255"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbxValor" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                </p>


                <p>
                    <label>Data de vencimento: </label>
                    <asp:TextBox ID="tbxDataVenc" TextMode="Date" runat="server" MaxLength="255"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="tbxDataVenc" ErrorMessage="Data inválida" ForeColor="Red" Operator="GreaterThan" ValueToCompare="01/01/1900"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxDataVenc" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                </p>

                <p>
                    <label>Data de recebimento: </label>
                    <asp:TextBox ID="tbxDataRecebimento" TextMode="Date" runat="server" MaxLength="255"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="tbxDataRecebimento" ErrorMessage="Data inválida" ForeColor="Red" ValueToCompare="01/01/1900" Operator="GreaterThan"></asp:CompareValidator>
                </p>

                <p>
                    <label>Parcelamento:                       </label>
                    <asp:RadioButtonList ID="rdParcelamento" runat="server" RepeatLayout="Table" AutoPostBack="True" OnSelectedIndexChanged="rdParcelamento_SelectedIndexChanged">
                        <asp:ListItem Text="Único" />
                        <asp:ListItem Text="Dividido" />
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="rdParcelamento" ErrorMessage="* Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
                </p>
                <p>
                    <label>Parcelas: </label>
                    <asp:DropDownList ID="drpDownParcelas" runat="server" Height="25px" Width="213px" Enabled="False">
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
                    <asp:TextBox TextMode="MultiLine" runat="server" Height="92px" Width="963px" ID="tbxObservacoes" />
                </p>


                <asp:Button runat="server" ID="btnCadastrar" Text="Cadastrar" OnClick="btnCadastrar_Click" />
            </asp:Panel>
        </div>
    </body>
    </html>

</asp:Content>
