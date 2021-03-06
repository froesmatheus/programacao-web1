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
    public partial class ManutencaoReceitas : System.Web.UI.Page
    {
        private List<TipoReceita> listaTipoReceitas;
        private TipoReceitaDAO dao;
        protected void Page_Load(object sender, EventArgs e)
        {
            dao = new TipoReceitaDAO();
            listaTipoReceitas = new List<TipoReceita>();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            

        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string query = tbxReceita.Text;

            btnExcluirFiltro.Visible = true;
        }

        protected void btnExcluirFiltro_Click(object sender, EventArgs e)
        {
            drpDownCategoriaReceita2.SelectedValue = "null";
            btnExcluirFiltro.Visible = false;
            tbxReceita.Text = String.Empty;
            grdReceitas.DataBind();
        }

        protected void btnEditar_Click(object sender, ImageClickEventArgs e)
        {
            FormView1.ChangeMode(FormViewMode.Edit);
            //tbxTxtReceita.Focus();
            //TipoReceita tipoReceita = dao.GetTipoReceita(((ImageButton)sender).CommandArgument, ((ImageButton)sender).CommandName);
            //if (tipoReceita == null) { return; }


            //tbxTxtReceita.Text = tipoReceita.tipoReceita;
            //drpDownCategoriaReceita.SelectedValue = tipoReceita.categoria;

            //btnCadastrar.Text = "Salvar";
            //btnCancelar.Visible = true;
            //btnCadastrar.CommandArgument = tipoReceita.tipoReceita;
            //btnCadastrar.CommandName = tipoReceita.categoria;
        }

        protected void btnDesativar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            TipoReceita tipoReceita = dao.GetTipoReceita(btn.CommandArgument, btn.CommandName);
            if (tipoReceita == null) { return; }

            tipoReceita.status = (tipoReceita.status == CategoriaDespesa.Status.DESATIVADO)? CategoriaDespesa.Status.ATIVO : CategoriaDespesa.Status.DESATIVADO;
            dao.Update(tipoReceita);
            grdReceitas.DataBind();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //tbxTxtReceita.Text = String.Empty;
            //btnCadastrar.Text = "Cadastrar";
            //btnCancelar.Visible = false;
        }

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx", true);
        }

        protected void grdReceitas_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormView1.PageIndex = grdReceitas.SelectedIndex;
        }

        protected void ObjectDataSource1_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            Label label = (Label)ModalPopupExtender1.FindControl("LabelMessage");
            if (int.Parse(e.ReturnValue.ToString()) > 0)
            {
                label.Text = "Tipo de Receita adicionado com sucesso";
            }
            else
            {
                label.Text = "Tipo de Receita já existe";
            }
            ModalPopupExtender1.Show();
        }
    }
}