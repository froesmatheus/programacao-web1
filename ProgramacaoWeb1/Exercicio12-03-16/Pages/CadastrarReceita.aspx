<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastrarReceita.aspx.cs" Inherits="Exercicio12_03_16.Pages.CadastrarReceita" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel GroupingText="Cadastro de Receitas" Style="padding: 10px;" Width="989px" runat="server" Height="603px">
                <p>
                    <label>Tipo de Receita: </label>
                    <asp:DropDownList ID="drpDownTipoReceita" runat="server" Height="26px" Width="209px" OnLoad="drpDownTipoReceita_Load"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpDownTipoReceita" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                </p>

                <p>
                    <label>Forma recebimento: </label>
                    <asp:DropDownList ID="drpDownFormaRecebimento" runat="server" Height="29px" Width="202px" OnLoad="drpDownFormaRecebimento_Load"></asp:DropDownList>
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
                    <asp:DropDownList ID="drpDownParcelas" runat="server" Height="25px" Width="213px" Enabled="False" OnLoad="drpDownParcelas_Load"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="drpDownParcelas" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                </p>

                <label>Observações</label>


                <p>
                    <asp:TextBox TextMode="MultiLine" runat="server" Height="92px" Width="963px" ID="tbxObservacoes" />
                </p>


                <asp:Button runat="server" ID="btnCadastrar" Text="Cadastrar" OnClick="btnCadastrar_Click" />
                <asp:Button ID="btnCancelar" Style="margin-left: 5px;" Visible="false" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
