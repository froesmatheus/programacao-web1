<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarExtrato.aspx.cs" Inherits="Exercicio12_03_16.Pages.ConsultarExtrato" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel runat="server" GroupingText="Filtro do Extrato" Width="619px">
                <p>
                    <label>Data Início: </label>
                    <asp:TextBox ID="tbxDataIni" TextMode="Date" runat="server" Width="250px" MaxLength="255" />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="tbxDataIni" ErrorMessage="* Data inválida" ForeColor="Red" Operator="GreaterThan" ValueToCompare="01/01/1900"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxDataIni" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                </p>

                <p>
                    <label>
                        Data Fim: 
                    <asp:TextBox ID="tbxDataFim" TextMode="Date" runat="server" MaxLength="255" Style="margin-left: 12px" Width="250px" />
                    </label>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="* Data inválida" ForeColor="Red" ControlToValidate="tbxDataFim" Operator="GreaterThan" ValueToCompare="01/01/1900"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxDataFim" ForeColor="Red"> * Campo obrigatório</asp:RequiredFieldValidator>
                </p>


                <asp:Button runat="server" ID="btnPesquisar" Text="Pesquisar" OnClick="btnPesquisar_Click" />
            </asp:Panel>




            <asp:Panel runat="server" Style="margin-top: 20px;" GroupingText="Seu Extrato Financeiro" Width="617px">
                <p>
                    <asp:Label runat="server" ID="tbxTotalReceita" Text="Total de Receitas R$ 0,00" style="margin-right: 10px; margin-left: 20px;"></asp:Label>
                    <asp:Label runat="server" ID="tbxTotalDespesa" Text="Total de Despesas R$ 0,00" style="margin-right: 10px;"/>
                    <asp:Label runat="server" ID="tbxSaldo" Text="Saldo R$ 0,00" />
                </p>

                <asp:GridView ID="grdExtrato" runat="server" Style="margin: 20px;"  AutoGenerateColumns="False"  OnLoad="grdExtrato_Load" OnRowDataBound="grdExtrato_RowDataBound">
                    <Columns>
                        <asp:BoundField HeaderText="Valor (R$)" DataField="Lancamento.valor" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Data de Realização" DataField="dataRecebimento" DataFormatString="{0:dd/M/yyyy}">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Vencimento" DataField="dataVencimento" DataFormatString="{0:dd/M/yyyy}" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Tipo/Categoria" DataField="tipo" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Pgto" DataField="tipoParcelamento" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
