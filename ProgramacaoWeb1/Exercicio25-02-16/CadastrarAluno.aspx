<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastrarAluno.aspx.cs" Inherits="Exercicio25_02_16.CadastrarAluno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        #lblMatriculaNaoEncontrada {
            color: red;
            text-align: right;
            font-size: 40px;
            position: center;
        }

        #lblMatriculaExistente {
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label runat="server" ID="lblMatriculaNaoEncontrada" Text="Matrícula não encontrada" />

        <div id="divCadastrarAluno" runat="server">
            <div>
                <asp:Label ID="Label6" runat="server" Text="Matrícula"></asp:Label>
                <br />
                <asp:TextBox ID="tbxMatricula" runat="server" AutoPostBack="True" OnTextChanged="tbxMatricula_TextChanged" />
                <asp:Label runat="server" ID="lblMatriculaExistente" Text="Matrícula existente" Visible="false" />
            </div>


            <div>
                <asp:Label ID="Label1" runat="server" Text="Nome"></asp:Label>
                <br />
                <asp:TextBox ID="tbxNome" runat="server"></asp:TextBox>
            </div>

            <div>
                <asp:Label ID="Label2" runat="server" Text="Nota 1"></asp:Label>
                <br />
                <asp:TextBox ID="tbxNota1" runat="server"></asp:TextBox>
            </div>

            <div>
                <asp:Label ID="Label3" runat="server" Text="Nota 2"></asp:Label>
                <br />
                <asp:TextBox ID="tbxNota2" runat="server"></asp:TextBox>
            </div>

            <div>
                <asp:Label ID="Label4" runat="server" Text="Percentual de faltas"></asp:Label>
                <br />
                <asp:TextBox ID="tbxPercFaltas" runat="server"></asp:TextBox>
            </div>

            <div>
                <asp:Label ID="Label5" runat="server" Text="Créditos"></asp:Label>
                <br />
                <asp:TextBox ID="tbxCreditos" runat="server"></asp:TextBox>
            </div>

            <br />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
            <asp:Button ID="btnVisualizarAlunos" runat="server" Text="Lista de alunos" OnClick="btnVisualizarAlunos_Click" />
        </div>
    </form>
</body>
</html>

