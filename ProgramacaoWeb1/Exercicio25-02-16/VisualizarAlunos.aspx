<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="VisualizarAlunos.aspx.cs" Inherits="Exercicio25_02_16.VisualizarAluno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListBox ID="lbxAlunos" runat="server" Height="106px" Width="276px"></asp:ListBox>
        </div>

        <br />

        <div>
            <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" />
            <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" />
            <asp:Button ID="btnNovo" runat="server" Text="Novo" OnClick="btnNovo_Click" />
        </div>
        <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" Width="484px">
            <Columns>
                <asp:BoundField DataField="matricula" HeaderText="Matrícula" />
                <asp:BoundField DataField="nome" HeaderText="Nome" />
                <asp:BoundField DataField="nota1" HeaderText="Nota 1" />
                <asp:BoundField DataField="nota2" HeaderText="Nota 2" />
                <asp:BoundField DataField="qtdCreditos" HeaderText="Qtd Creditos" />
                <asp:TemplateField HeaderText="Editar">
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" OnClick="btnEditar_Click1" Text="Editar" CommandArgument='<%# Eval("matricula") %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
