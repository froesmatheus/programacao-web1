using Exercicio12_03_16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exercicio12_03_16.Pages
{
    public partial class ConsultarExtrato : System.Web.UI.Page
    {
        private List<Lancamento> lancamentos;
        private List<Receita> receitas;
        private List<Despesa> despesas;
        protected void Page_Load(object sender, EventArgs e)
        {
            receitas = (Session["listaReceitas"] != null) ? (List<Receita>)Session["listaReceitas"] : new List<Receita>();
            despesas = (Session["listaDespesas"] != null) ? (List<Despesa>)Session["listaDespesas"] : new List<Despesa>();
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            DateTime dataIni = DateTime.Parse(tbxDataIni.Text);
            DateTime dataFim = DateTime.Parse(tbxDataFim.Text);
            filtrarGridView(dataIni, dataFim);
        }

        protected void grdExtrato_Load(object sender, EventArgs e)
        {
            lancamentos = new List<Lancamento>();
            lancamentos.AddRange(receitas);
            lancamentos.AddRange(despesas);

            DateTime dataAtual = DateTime.Today;


            DateTime dataIni = new DateTime(dataAtual.Year, dataAtual.Month, 1);
            DateTime dataFim = new DateTime(dataAtual.Year, dataAtual.Month, DateTime.DaysInMonth(dataAtual.Year, dataAtual.Month));

            filtrarGridView(dataIni, dataFim);

        }

        private void filtrarGridView(DateTime dataIni, DateTime dataFim)
        {
            var listaFiltrada = lancamentos
                                    .Where(x => x.dataVencimento >= dataIni && x.dataVencimento <= dataFim)
                                    .OrderBy(x => x.dataVencimento);


            grdExtrato.DataSource = listaFiltrada;
            grdExtrato.DataBind();


            double totalReceita = GetTotalCusto(listaFiltrada.Where(x => x is Receita).ToList());
            double totalDespesa = GetTotalCusto(listaFiltrada.Where(x => x is Despesa).ToList());
            tbxTotalReceita.Text = String.Format("Total de Receitas R$ {0:0.00}", totalReceita);
            tbxTotalDespesa.Text = String.Format("Total de Despesas R$ {0:0.00}", totalDespesa);

            tbxSaldo.Text = String.Format("Saldo R$ {0:0.00}", (totalReceita - totalDespesa));
        }



        private double GetTotalCusto(List<Lancamento> lista)
        {
            double total = 0.0;
            foreach (var item in lista)
            {
                total += item.valor;
            }
            return total;
        }

        protected void grdExtrato_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.DataItem is Receita)
                {
                    Receita receita = (Receita)e.Row.DataItem;
                    e.Row.BackColor = System.Drawing.Color.Green;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
                else if (e.Row.DataItem is Despesa)
                {
                    Despesa despesa = (Despesa)e.Row.DataItem;
                    e.Row.BackColor = System.Drawing.Color.Red;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }


                Lancamento lanc = e.Row.DataItem as Lancamento;

                if (lanc.dataRecebimento == DateTime.Parse("01/01/0001"))
                {
                    e.Row.Cells[1].Text = "------";
                }

                if (lanc.tipoParcelamento == Lancamento.PARCELADO)
                {
                    e.Row.Cells[4].Text = lanc.parcela + "/" + lanc.qtParcelas;
                }
            }
        }

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx", true);
        }
    }
}