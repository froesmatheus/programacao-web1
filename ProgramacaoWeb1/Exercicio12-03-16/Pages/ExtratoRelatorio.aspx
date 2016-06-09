<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExtratoRelatorio.aspx.cs" Inherits="Exercicio12_03_16.Relatorios.ExtratoRelatorio" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager" runat="server" />

        <br />
                    <asp:Label runat="server" ID="tbxTotalReceita" Text="Total de Receitas R$ 0,00" Style="margin-right: 10px; margin-left: 20px;"></asp:Label>
                    <asp:Label runat="server" ID="tbxTotalDespesa" Text="Total de Despesas R$ 0,00" Style="margin-right: 10px;" />
                    <asp:Label runat="server" ID="tbxSaldo" Text="Saldo R$ 0,00" />
                <br />

        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="747px" OnLoad="ReportViewer1_Load">
            <LocalReport ReportPath="Relatorios\RelatorioExtrato.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetExtrato" TypeName="Exercicio12_03_16.Database.DAOs.LancamentoDAO">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name="dataInicial" SessionField="dataInicial" Type="DateTime" />
                <asp:SessionParameter DefaultValue="" Name="dataFinal" SessionField="dataFinal" Type="DateTime" />
                <asp:SessionParameter Name="tpFiltro" SessionField="tpFiltro" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
