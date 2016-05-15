<%@ Page MasterPageFile="~/MasterPage.Master" Language="C#" AutoEventWireup="true" CodeBehind="ConsultarExtrato.aspx.cs" Inherits="Exercicio12_03_16.Pages.ConsultarExtrato" %>


<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!DOCTYPE html>


    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title></title>
    </head>
    <body>
        <div>
            <asp:ImageButton CausesValidation="false" ID="btnVoltar" runat="server" ImageUrl="~/Images/voltar.png" Style="margin: 5px;" OnClick="btnVoltar_Click" />

            <asp:Panel runat="server" GroupingText="Filtro do Extrato" Width="619px">
                <p>
                    <label>Data Início: </label>
                    <asp:TextBox ID="tbxDataIni" TextMode="Date" runat="server" Width="250px" MaxLength="255" />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="tbxDataIni" ErrorMessage="* Data inválida" ForeColor="Red" Operator="GreaterThan" ValueToCompare="01/01/1900"></asp:CompareValidator>
                </p>

                <p>
                    <label>
                        Data Fim: 
                    <asp:TextBox ID="tbxDataFim" TextMode="Date" runat="server" MaxLength="255" Style="margin-left: 12px" Width="250px" />
                    </label>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="* Data inválida" ForeColor="Red" ControlToValidate="tbxDataFim" Operator="GreaterThan" ValueToCompare="01/01/1900"></asp:CompareValidator>
                </p>


                <p>
                    <label>Lançamentos: </label>
                    <asp:RadioButtonList runat="server" RepeatLayout="Table" ID="rdLancamentosFiltro">
                        <asp:ListItem Text="Vencidos" />
                        <asp:ListItem Text="Vencimento Próximo" />
                    </asp:RadioButtonList>
                </p>
                <asp:Button runat="server" ID="btnPesquisar" Text="Pesquisar" OnClick="btnPesquisar_Click" />
            </asp:Panel>




            <asp:Panel runat="server" Style="margin-top: 20px;" GroupingText="Seu Extrato Financeiro" Width="617px">
                <p>
                    <asp:Label runat="server" ID="tbxTotalReceita" Text="Total de Receitas R$ 0,00" Style="margin-right: 10px; margin-left: 20px;"></asp:Label>
                    <asp:Label runat="server" ID="tbxTotalDespesa" Text="Total de Despesas R$ 0,00" Style="margin-right: 10px;" />
                    <asp:Label runat="server" ID="tbxSaldo" Text="Saldo R$ 0,00" />
                </p>

                <asp:GridView ID="grdExtrato" runat="server" Style="margin: 20px;" AutoGenerateColumns="False" OnRowDataBound="grdExtrato_RowDataBound" Enabled="False" DataSourceID="ObjectDataSource1">
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
                        <asp:BoundField HeaderText="Saldo Parcial" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetLancamentos" TypeName="Exercicio12_03_16.Database.DAOs.LancamentoDAO">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="tbxDataIni" Name="dataInicial" PropertyName="Text" Type="DateTime" />
                        <asp:ControlParameter ControlID="tbxDataFim" Name="dataFinal" PropertyName="Text" Type="DateTime" />
                        <asp:ControlParameter ControlID="rdLancamentosFiltro" Name="tpFiltro" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>
        </div>
    </body>
    </html>
</asp:Content>
