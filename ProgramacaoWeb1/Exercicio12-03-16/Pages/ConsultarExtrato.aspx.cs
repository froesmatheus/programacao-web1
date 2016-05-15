﻿using Exercicio12_03_16.Database.DAOs;
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
        private LancamentoDAO dao;
        private List<Lancamento> lancamentos;

        protected void Page_Load(object sender, EventArgs e)
        {
            dao = new LancamentoDAO();
            lancamentosTR = new List<Lancamento>();
            lancamentos = new List<Lancamento>();

            if (!IsPostBack)
            {
                DateTime hoje = DateTime.Today;
                DateTime primeiroDiaMes = new DateTime(hoje.Year, hoje.Month, 1);
                DateTime ultimoDiaMes = primeiroDiaMes.AddMonths(1).AddDays(-1);
                tbxDataIni.Text = primeiroDiaMes.ToShortDateString();
                tbxDataFim.Text = ultimoDiaMes.ToShortDateString(); 
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            
        }
        private void AtualizarEstatisticas(List<Lancamento> listaFiltrada)
        {
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