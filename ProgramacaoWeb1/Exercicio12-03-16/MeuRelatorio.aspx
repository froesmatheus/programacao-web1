<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeuRelatorio.aspx.cs" Inherits="Exercicio12_03_16.MeuRelatorio" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="774px">
            <LocalReport ReportPath="Relatorios\Report1.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
        
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Exercicio12_03_16.DataSet1TableAdapters.DespesasTableAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="FormaRecebimento" Type="String" />
                <asp:Parameter Name="Valor" Type="Decimal" />
                <asp:Parameter Name="DataVencimento" Type="DateTime" />
                <asp:Parameter Name="DataRecebimento" Type="DateTime" />
                <asp:Parameter Name="TipoParcelamento" Type="String" />
                <asp:Parameter Name="QtdParcelas" Type="Decimal" />
                <asp:Parameter Name="Parcela" Type="Decimal" />
                <asp:Parameter Name="Observacoes" Type="String" />
                <asp:Parameter Name="Tipo" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="FormaRecebimento" Type="String" />
                <asp:Parameter Name="Valor" Type="Decimal" />
                <asp:Parameter Name="DataVencimento" Type="DateTime" />
                <asp:Parameter Name="DataRecebimento" Type="DateTime" />
                <asp:Parameter Name="TipoParcelamento" Type="String" />
                <asp:Parameter Name="QtdParcelas" Type="Decimal" />
                <asp:Parameter Name="Parcela" Type="Decimal" />
                <asp:Parameter Name="Observacoes" Type="String" />
                <asp:Parameter Name="Tipo" Type="String" />
                <asp:Parameter Name="Original_Id" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        
    </form>
</body>
</html>
