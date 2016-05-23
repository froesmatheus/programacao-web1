using Exercicio12_03_16.Database.DAOs;
using Exercicio12_03_16.Models;
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
        private TipoDespesaDAO dao;
        private CategoriaDespesaDAO categoriasDAO;
        protected void Page_Load(object sender, EventArgs e)
        {
            dao = new TipoDespesaDAO();
            categoriasDAO = new CategoriaDespesaDAO();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            //if (btnCadastrar.Text.Equals("Salvar"))
            //{
            //    TipoDespesa desp = dao.GetTipoDespesa(btnCadastrar.CommandName, btnCadastrar.CommandArgument);
            //    if (desp != null)
            //    {
            //        desp.categoria = categoriasDAO.Get(drpDownCategorias.SelectedValue);
            //        desp.tipoDespesa = tbxTipoDespesa.Text;
            //        desp.caracteristica = radBtnCaracteristicas.SelectedValue;
            //        btnCancelar.Visible = false;
            //        btnCadastrar.Text = "Cadastrar";
            //        dao.Update(desp);
            //        grdDespesas.DataBind();
            //        tbxTipoDespesa.Text = String.Empty;
            //        return;
            //    }

            //}


            //if (dao.GetTipoDespesa(drpDownCategorias.SelectedValue.ToString(), tbxTipoDespesa.Text.ToString()) != null) {
            //    tbxTipoDespesa.Text = String.Empty;
            //    string script = "<script> alert(\"Esse Tipo de despesa já existe\");</script>";
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "AlertCategoriaExistente", script, false);
            //    tbxTipoDespesa.Focus();
            //    return;
            //}


            //string tipoDespesa = tbxTipoDespesa.Text;
            //string caracteristica = radBtnCaracteristicas.SelectedValue;

            //TipoDespesa despesa = new TipoDespesa(categoriasDAO.Get(drpDownCategorias.Text), tipoDespesa, caracteristica, CategoriaDespesa.Status.ATIVO);
            //dao.Insert(despesa);
            //grdDespesas.DataBind();


            //tbxTipoDespesa.Text = String.Empty;
            //drpDownCategorias.Focus();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            btnExcluirFiltro.Visible = true;
        }

        protected void btnExcluirFiltro_Click(object sender, EventArgs e)
        {
            btnExcluirFiltro.Visible = false;
            tbxTpDespesa.Text = String.Empty;
            drpDownCategorias2.SelectedValue = "null";
        }

        protected void btnEditar_Click(object sender, ImageClickEventArgs e)
        {
            FormView1.ChangeMode(FormViewMode.Edit);
            //tbxTipoDespesa.Focus();
            //TipoDespesa tipoDespesa = dao.GetTipoDespesa(((ImageButton)sender).CommandArgument, ((ImageButton)sender).CommandName);
            //if (tipoDespesa == null) { return; }


            //tbxTipoDespesa.Text = tipoDespesa.tipoDespesa;
            //radBtnCaracteristicas.SelectedValue = tipoDespesa.caracteristica;

            //btnCadastrar.Text = "Salvar";
            //btnCancelar.Visible = true;
            //btnCadastrar.CommandArgument = tipoDespesa.tipoDespesa;
            //btnCadastrar.CommandName = tipoDespesa.categoria.categoria;
        }

        protected void btnDesativar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            TipoDespesa tipoDespesa = dao.GetTipoDespesa(btn.CommandArgument, btn.CommandName);
            if (tipoDespesa == null) { return; }

            tipoDespesa.status = CategoriaDespesa.Status.DESATIVADO;
            dao.Update(tipoDespesa);

            grdDespesas.DataBind();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //tbxTipoDespesa.Text = String.Empty;
            //btnCadastrar.Text = "Cadastrar";
            //btnCancelar.Visible = false;
        }

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx", true);
        }

        protected void FormView1_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            e.Values[0] = categoriasDAO.Get(e.Values[0].ToString());
        }

        protected void FormView1_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            e.NewValues[0] = categoriasDAO.Get(e.NewValues[0].ToString());
        }

        protected void grdDespesas_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormView1.PageIndex = grdDespesas.SelectedIndex;
        }
    }
}
