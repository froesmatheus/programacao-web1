﻿using Exercicio12_03_16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exercicio12_03_16
{
    public partial class CadastrarDespesa : System.Web.UI.Page
    {
        public List<CategoriaDespesa> listaCatDespesas;
        public List<Despesa> listaTipoDespesas;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                listaTipoDespesas = (List<Despesa>)Session["listaTipoDespesas"];
                listaCatDespesas = (List<CategoriaDespesa>)Session["listaCatDespesas"];
                grdDespesas.DataSource = listaTipoDespesas;
                grdDespesas.DataBind();
            }
            else
            {
                listaTipoDespesas = new List<Despesa>();
                Session["listaTipoDespesas"] = listaTipoDespesas;

                if (Session["listaCatDespesas"] != null)
                {
                    listaCatDespesas = (List<CategoriaDespesa>)Session["listaCatDespesas"];
                    drpDownCategorias.DataSource = listaCatDespesas;
                    drpDownCategorias.DataBind();

                    drpDownCategorias2.DataSource = listaCatDespesas;
                    drpDownCategorias2.DataBind();
                }
            }


        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string categoria = drpDownCategorias.SelectedItem.ToString();
            CategoriaDespesa categoriaDespesa = null;
            foreach (var item in listaCatDespesas)
            {
                if (item.categoria.Equals(categoria))
                {
                    categoriaDespesa = item;
                    break;
                }
            }

            string tipoDespesa = tbxTipoDespesa.Text;
            string caracteristica = radBtnCaracteristicas.SelectedValue;

            Despesa despesa = new Despesa(categoriaDespesa, tipoDespesa, caracteristica, CategoriaDespesa.Status.ATIVO);
            listaTipoDespesas.Add(despesa);
            grdDespesas.DataBind();


            tbxTipoDespesa.Text = String.Empty;
            drpDownCategorias.Focus();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string query = tbxTpDespesa.Text;

            btnExcluirFiltro.Visible = true;
            var results = listaTipoDespesas.Where(x => x.tipoDespesa.ToLower().Contains(query.ToLower()) && 
            x.categoria.ToString().Equals(drpDownCategorias2.SelectedValue));

            grdDespesas.DataSource = results;
            grdDespesas.DataBind();
        }

        protected void btnExcluirFiltro_Click(object sender, EventArgs e)
        {
            grdDespesas.DataSource = listaTipoDespesas;
            grdDespesas.DataBind();
            btnExcluirFiltro.Visible = false;
            tbxTpDespesa.Text = String.Empty;
        }

        protected void btnEditar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnDesativar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            Despesa despesa = GetTipoDespesa(btn.CommandArgument, btn.CommandName);
            if (despesa == null) { return; }

            despesa.status = CategoriaDespesa.Status.DESATIVADO;
            grdDespesas.DataBind();
        }

        private Despesa GetTipoDespesa(string categoria, string tipoDespesa)
        {

            foreach (var item in listaTipoDespesas)
            {
                if (item.categoria.ToString().Equals(categoria) && item.tipoDespesa.Equals(tipoDespesa))
                {
                    return item;
                }
            }
            return null;
        }
    }
}
