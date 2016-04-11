<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListarLancamentos.ascx.cs" Inherits="Exercicio12_03_16.Controls.ListarLancamentos" %>

<asp:Panel ID="panel" runat="server" Style="margin-top: 20px;" GroupingText="Lista de Lançamentos" Width="617px">
    <p>
        <asp:Label runat="server" ID="tbxTotalReceita" Text="Total de Receitas R$ 0,00" Style="margin-right: 10px; margin-left: 20px;"></asp:Label>
        <asp:Label runat="server" ID="tbxTotalDespesa" Text="Total de Despesas R$ 0,00" Style="margin-right: 10px;" />
        <asp:Label runat="server" ID="tbxSaldo" Text="Saldo R$ 0,00" />
    </p>

    <asp:GridView ID="grdLancamentos" runat="server" Style="margin: 20px;" AutoGenerateColumns="False" OnLoad="grdLancamentos_Load" OnRowDataBound="grdLancamentos_RowDataBound" Enabled="False">
        <Columns>
            <asp:BoundField HeaderText="Valor (R$)" DataField="valor" DataFormatString="{0:N2}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Data de Realização" DataField="dataRecebimento" DataFormatString="{0:dd/MM/yyyy}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Vencimento" DataField="dataVencimento" DataFormatString="{0:dd/MM/yyyy}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Tipo/Categoria" DataField="tipo">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Pgto" DataField="tipoParcelamento">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Panel>
