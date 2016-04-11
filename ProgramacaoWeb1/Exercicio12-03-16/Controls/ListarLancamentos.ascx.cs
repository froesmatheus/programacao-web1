using Exercicio12_03_16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exercicio12_03_16.Controls
{
    public partial class ListarLancamentos : System.Web.UI.UserControl
    {
        public int qtdDias { get; set; }
        private List<Receita> receitas;
        private List<Despesa> despesas;
        private List<Lancamento> lancamentos;

        

        protected void Page_Load(object sender, EventArgs e)
        {
            receitas = (Session["listaReceitas"] != null) ? (List<Receita>)Session["listaReceitas"] : new List<Receita>();
            despesas = (Session["listaDespesas"] != null) ? (List<Despesa>)Session["listaDespesas"] : new List<Despesa>();
        }

        protected void grdLancamentos_Load(object sender, EventArgs e)
        {
            lancamentos = new List<Lancamento>();
            lancamentos.AddRange(receitas);
            lancamentos.AddRange(despesas);
            lancamentos = lancamentos.OrderBy(x => x.dataVencimento).ToList();

            DateTime dataIni = DateTime.Today;
            DateTime dataFim = dataIni.AddDays(qtdDias * -1);

            filtrarGridView(dataIni, dataFim);
        }

        private void filtrarGridView(DateTime dataIni, DateTime dataFim)
        {
            var listaFiltrada = lancamentos
                                    .Where(x => x.dataVencimento <= dataIni && x.dataVencimento >= dataFim)
                                    .OrderBy(x => x.dataVencimento);


            grdLancamentos.DataSource = listaFiltrada;
            grdLancamentos.DataBind();


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

        protected void grdLancamentos_RowDataBound(object sender, GridViewRowEventArgs e)
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

        
    }
}