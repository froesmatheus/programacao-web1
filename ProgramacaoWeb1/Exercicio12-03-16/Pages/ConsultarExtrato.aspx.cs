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
        private List<Receita> receitas;
        private List<Despesa> despesas;
        protected void Page_Load(object sender, EventArgs e)
        {
            receitas = (Session["listaReceitas"] != null) ? (List<Receita>)Session["listaReceitas"] : new List<Receita>();
            despesas = (Session["listaDespesas"] != null) ? (List<Despesa>)Session["listaDespesas"] : new List<Despesa>();
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            
        }

        protected void grdExtrato_Load(object sender, EventArgs e)
        {
            SortedList<DateTime, Lancamento> lancamentos = new SortedList<DateTime, Lancamento>();
            foreach (var item in receitas)
            {
                lancamentos.Add(item.dataRecebimento, item);
            }

            foreach (var item in despesas)
            {
                lancamentos.Add(item.dataRecebimento, item);
            }

            grdExtrato.DataSource = lancamentos;
            grdExtrato.DataBind();

            double totalReceita = GetTotalReceita(receitas);
            double totalDespesa = GetTotalDespesa(despesas);
            tbxTotalReceita.Text = String.Format("Total de Receitas R$ {0:0.00}", totalReceita);
            tbxTotalDespesa.Text = String.Format("Total de Despesas R$ {0:0.00}", totalDespesa);

            tbxSaldo.Text = String.Format("Saldo R$ {0:0.00}", (totalReceita - totalDespesa));
        }



        private double GetTotalReceita(List<Receita> receitas)
        {
            double total = 0.0;
            foreach (var item in receitas)
            {
                total += item.valor;
            }
            return total;
        }

        private double GetTotalDespesa(List<Despesa> despesas)
        {
            double total = 0.0;
            foreach (var item in despesas)
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
                } else if (e.Row.DataItem is Despesa)
                {
                    Despesa despesa = (Despesa)e.Row.DataItem;
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}