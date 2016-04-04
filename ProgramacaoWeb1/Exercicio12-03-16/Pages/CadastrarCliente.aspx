<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastrarCliente.aspx.cs" Inherits="Exercicio12_03_16.CadastrarCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        form {
            display: table;
            border-spacing: 10px;
        }

        p {
            display: table-row;
        }

        label {
            display: table-cell;
        }

        input {
            display: table-cell;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ImageButton CausesValidation="false" ID="btnVoltar" runat="server" ImageUrl="~/Imagens/voltar.png" style="margin:5px;" OnClick="btnVoltar_Click"/>


            <asp:Panel GroupingText="Meus Dados" runat="server" Width="800px">
                <div class="container">
                    <p>
                        <label>Nome: </label>
                        <asp:TextBox ID="tbxNome" runat="server" Width="250px" MaxLength="255" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxNome"
                            ErrorMessage="Campo obrigatório (Nome)" ForeColor="Red"> *</asp:RequiredFieldValidator>
                    </p>

                    <p>
                        <label>Data de aniversário: </label>
                        <asp:TextBox ID="tbxDataNasc" runat="server" Width="250px" TextMode="Date" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxDataNasc"
                            ErrorMessage="Campo obrigatório (Data de aniversário)" ForeColor="Red"> *</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" Display="None"
                            ErrorMessage="Data de aniversário inválida" Type="Date" ControlToValidate="tbxDataNasc"
                            Operator="GreaterThan" ValueToCompare="01/01/1900">Data de aniversário inválida</asp:CompareValidator>
                    </p>

                    <p>
                        <label>Email: </label>
                        <asp:TextBox ID="tbxEmail" runat="server" Width="250px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbxEmail"
                            ErrorMessage="Campo obrigatório (Email)" ForeColor="Red"> *</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="tbxConfirmEmail" 
                            ControlToValidate="tbxEmail" ErrorMessage="Os emails não são iguais" Display="None"></asp:CompareValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbxEmail" 
                            ErrorMessage="O email não é válido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"></asp:RegularExpressionValidator>
                    </p>

                    <p>
                        <label>Confirmação Email: </label>
                        <asp:TextBox ID="tbxConfirmEmail" runat="server" Width="250px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbxConfirmEmail" 
                            ErrorMessage="Campo obrigatório (Confirmação Email)" ForeColor="Red"> *</asp:RequiredFieldValidator>
                    </p>

                    <p>
                        <label>Senha: </label>
                        <asp:TextBox ID="tbxSenha" runat="server" TextMode="Password" Width="250px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbxSenha"
                            ErrorMessage="Campo obrigatório (Senha)" ForeColor="Red"> *</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="tbxConfirmSenha"
                            ControlToValidate="tbxSenha" Display="None" ErrorMessage="As senhas não são iguais"></asp:CompareValidator>
                    </p>

                    <p>
                        <label>Confirmação Senha: </label>
                        <asp:TextBox ID="tbxConfirmSenha" runat="server" TextMode="Password" Width="250px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbxConfirmSenha"
                            ErrorMessage="Campo obrigatório (Confirmação Senha)" ForeColor="Red"> *</asp:RequiredFieldValidator>
                    </p>

                    <asp:Button runat="server" ID="btnSalvar" Text="Salvar" Font-Size="Large" OnClick="btnSalvar_Click" />
                </div>

                <br />

                <p>
                    <asp:ValidationSummary DisplayMode="BulletList" runat="server" ShowSummary="true" ForeColor="Red"
                        HeaderText="O formulário contém erros" />
                </p>

            </asp:Panel>
        </div>
    </form>
</body>
</html>
