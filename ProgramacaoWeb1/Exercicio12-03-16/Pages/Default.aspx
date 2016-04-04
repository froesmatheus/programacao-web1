<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Exercicio12_03_16.Pages.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Menu ID="Menu1" runat="server">
                <Items>
                    <asp:MenuItem Text="Cadastrar Cliente" NavigateUrl="~/Pages/CadastrarCliente.aspx" />
                    <asp:MenuItem Text="Gerenciar Categoria de Despesa" NavigateUrl="~/Pages/GerenciarCategoriaDespesas.aspx" />
                    <asp:MenuItem Text="Gerenciar Tipo de Despesa" NavigateUrl="~/Pages/GerenciarTipoDespesas.aspx" />
                    <asp:MenuItem Text="Manutenção de Tipo de Receitas" NavigateUrl="~/Pages/ManutencaoTipoReceitas.aspx" />
                    <asp:MenuItem Text="Cadastrar Despesa" NavigateUrl="~/Pages/CadastrarDespesa.aspx" />
                    <asp:MenuItem Text="Cadastrar Receita" NavigateUrl="~/Pages/CadastrarReceita.aspx" />
                    <asp:MenuItem Text="Consultar Extrato" NavigateUrl="~/Pages/ConsultarExtrato.aspx" />
                </Items>
            </asp:Menu>
        </div>
    </form>
</body>
</html>
