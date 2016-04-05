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
        private List<Lancamento> lancamentosTR;
        private List<Lancamento> lancamentos;
        private List<Receita> receitas;
        private List<Despesa> despesas;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            receitas = (Session["listaReceitas"] != null) ? (List<Receita>)Session["listaReceitas"] : new List<Receita>();
            despesas = (Session["listaDespesas"] != null) ? (List<Despesa>)Session["listaDespesas"] : new List<Despesa>();
            lancamentosTR = new List<Lancamento>();
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            string lancamentoFiltroStr = rdLancamentosFiltro.SelectedValue;
            if (!String.IsNullOrEmpty(lancamentoFiltroStr))
            {
                if (lancamentoFiltroStr.Equals("Vencidos"))
                {
                    DateTime dataIniVencidos = new DateTime();
                    DateTime dataFimVencidos = DateTime.Today.Subtract(TimeSpan.FromDays(1));
                    filtrarVencidosGridView(dataIniVencidos, dataFimVencidos);
                    return;
                }
                else
                {
                    DateTime dataIniProximos = DateTime.Today;
                    DateTime dataFimProximos = DateTime.Today.AddDays(5);
                    filtrarGridViewVencProximos(dataIniProximos, dataFimProximos);
                    return;
                }
            }
            if (tbxDataIni.Text.Equals("") || tbxDataFim.Text.Equals(""))
            {
                string script = "<script> alert(\"Ambas as datas devem ser preenchidas\");</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "AlertDataVazia", script, false);
                return;
            }
       
            DateTime dataIni = DateTime.Parse(tbxDataIni.Text);
            DateTime dataFim = DateTime.Parse(tbxDataFim.Text);
            filtrarGridView(dataIni, dataFim);
        }

        private void filtrarGridViewVencProximos(DateTime dataIniProximos, DateTime dataFimProximos)
        {
            var listaFiltrada = lancamentos
                                    .Where(x => x.dataVencimento >= dataIniProximos && x.dataVencimento <= dataFimProximos && x.dataRecebimento == DateTime.Parse("01/01/0001"))
                                    .OrderBy(x => x.dataVencimento);


            grdExtrato.DataSource = listaFiltrada;
            grdExtrato.DataBind();
            lancamentosTR.Clear();



            double totalReceita = GetTotalCusto(listaFiltrada.Where(x => x is Receita).ToList());
            double totalDespesa = GetTotalCusto(listaFiltrada.Where(x => x is Despesa).ToList());
            tbxTotalReceita.Text = String.Format("Total de Receitas R$ {0:0.00}", totalReceita);
            tbxTotalDespesa.Text = String.Format("Total de Despesas R$ {0:0.00}", totalDespesa);

            tbxSaldo.Text = String.Format("Saldo R$ {0:0.00}", (totalReceita - totalDespesa));
        }


        protected void grdExtrato_Load(object sender, EventArgs e)
        {
            lancamentosTR = new List<Lancamento>();

            lancamentos = new List<Lancamento>();
            lancamentos.AddRange(receitas);
            lancamentos.AddRange(despesas);
            lancamentos = lancamentos.OrderBy(x => x.dataVencimento).ToList();
            
         


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
            lancamentosTR.Clear();


            double totalReceita = GetTotalCusto(listaFiltrada.Where(x => x is Receita).ToList());
            double totalDespesa = GetTotalCusto(listaFiltrada.Where(x => x is Despesa).ToList());
            tbxTotalReceita.Text = String.Format("Total de Receitas R$ {0:0.00}", totalReceita);
            tbxTotalDespesa.Text = String.Format("Total de Despesas R$ {0:0.00}", totalDespesa);

            tbxSaldo.Text = String.Format("Saldo R$ {0:0.00}", (totalReceita - totalDespesa));
        }

        private void filtrarVencidosGridView(DateTime dataIni, DateTime dataFim)
        {
            var listaFiltrada = lancamentos
                                    .Where(x => x.dataVencimento <= dataFim && x.dataRecebimento == DateTime.Parse("01/01/0001"))
                                    .OrderBy(x => x.dataVencimento);


            grdExtrato.DataSource = listaFiltrada;
            grdExtrato.DataBind();
            lancamentosTR.Clear();


            double totalReceita = GetTotalCusto(listaFiltrada.Where(x => x is Receita).ToList());
            double totalDespesa = GetTotalCusto(listaFiltrada.Where(x => x is Despesa).ToList());
            tbxTotalReceita.Text = String.Format("Total de Receitas R$ {0:0.00}", totalReceita);
            tbxTotalDespesa.Text = String.Format("Total de Despesas R$ {0:0.00}", totalDespesa);

            tbxSaldo.Text = String.Format("Saldo R$ {0:0.00}", (totalReceita - totalDespesa));
        }


        public double GetSaldoParcial(List<Lancamento> lista)
        {
            double totalReceita = GetTotalCusto(lista.Where(x => x is Receita).ToList());
            double totalDespesa = GetTotalCusto(lista.Where(x => x is Despesa).ToList());

            return (totalReceita - totalDespesa);
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
                lancamentosTR.Add(lanc);
                if (lanc.dataRecebimento == DateTime.Parse("01/01/0001"))
                {
                    e.Row.Cells[1].Text = "------";
                }

                if (lanc.tipoParcelamento == Lancamento.PARCELADO)
                {
                    e.Row.Cells[4].Text = lanc.parcela + "/" + lanc.qtParcelas;
                }
                e.Row.Cells[5].Text = GetSaldoParcial(lancamentosTR) + "";

            }
        }

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx", true);
        }
    }
}