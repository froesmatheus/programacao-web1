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
                    <asp:MenuItem Text="Cadastrar Cliente" Target="_blank" NavigateUrl="~/Pages/CadastrarCliente.aspx" />
                    <asp:MenuItem Text="Gerenciar Categoria de Despesa" Target="_blank" NavigateUrl="~/Pages/GerenciarCategoriaDespesas.aspx" />
                    <asp:MenuItem Text="Gerenciar Tipo de Despesa" Target="_blank" NavigateUrl="~/Pages/GerenciarTipoDespesas.aspx" />
                    <asp:MenuItem Text="Manutenção de Tipo de Receitas" Target="_blank" NavigateUrl="~/Pages/ManutencaoTipoReceitas.aspx" />
                    <asp:MenuItem Text="Cadastrar Despesa" Target="_blank" NavigateUrl="~/Pages/CadastrarDespesa.aspx" />
                    <asp:MenuItem Text="Cadastrar Receita" Target="_blank" NavigateUrl="~/Pages/CadastrarReceita.aspx" />
                    <asp:MenuItem Text="Consultar Extrato" Target="_blank" NavigateUrl="~/Pages/ConsultarExtrato.aspx" />
                </Items>
            </asp:Menu>
        </div>
    </form>
</body>
</html>
