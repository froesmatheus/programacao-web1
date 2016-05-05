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
        public List<CategoriaDespesa> listaCatDespesas;
        public List<TipoDespesa> listaTipoDespesas;
        protected void Page_Load(object sender, EventArgs e)
        {
            dao = new TipoDespesaDAO();
            categoriasDAO = new CategoriaDespesaDAO();
            if (IsPostBack)
            {
                listaTipoDespesas = (List<TipoDespesa>)Session["listaTipoDespesas"];
                listaCatDespesas = (List<CategoriaDespesa>)Session["listaCatDespesas"];
                grdDespesas.DataSource = listaTipoDespesas;
                grdDespesas.DataBind();
            }
            else
            {
                if (Session["listaCatDespesas"] == null)
                {
                    listaTipoDespesas = new List<TipoDespesa>();
                    Session["listaTipoDespesas"] = listaTipoDespesas;
                }
                else
                {
                    listaTipoDespesas = (List<TipoDespesa>)Session["listaTipoDespesas"];
                    grdDespesas.DataSource = listaTipoDespesas;
                    grdDespesas.DataBind();
                }


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
            if (btnCadastrar.Text.Equals("Salvar"))
            {
                TipoDespesa desp = GetTipoDespesa(btnCadastrar.CommandName, btnCadastrar.CommandArgument);
                if (desp != null)
                {
                    desp.categoria.categoria = drpDownCategorias.SelectedValue;
                    desp.tipoDespesa = tbxTipoDespesa.Text;
                    desp.caracteristica = radBtnCaracteristicas.SelectedValue;
                    btnCancelar.Visible = false;
                    btnCadastrar.Text = "Cadastrar";
                    grdDespesas.DataBind();
                    tbxTipoDespesa.Text = String.Empty;
                    return;
                }

            }



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


            foreach (var item in listaTipoDespesas)
            {
                if (item.categoria.categoria.ToLower().Equals(drpDownCategorias.SelectedValue.ToLower()) && item.tipoDespesa.Trim().ToLower().Equals(tbxTipoDespesa.Text.Trim().ToLower()))
                {
                    tbxTipoDespesa.Text = String.Empty;
                    string script = "<script> alert(\"Esse tipo de despesa já existe\");</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "AlertCategoriaExistente", script, false);
                    tbxTipoDespesa.Focus();
                    return;
                }
            }

            string tipoDespesa = tbxTipoDespesa.Text;
            string caracteristica = radBtnCaracteristicas.SelectedValue;

            TipoDespesa despesa = new TipoDespesa(categoriaDespesa, tipoDespesa, caracteristica, CategoriaDespesa.Status.ATIVO);
            listaTipoDespesas.Add(despesa);
            dao.Insert(despesa);
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
            tbxTipoDespesa.Focus();
            TipoDespesa tipoDespesa = GetTipoDespesa(((ImageButton)sender).CommandArgument, ((ImageButton)sender).CommandName);
            if (tipoDespesa == null) { return; }


            tbxTipoDespesa.Text = tipoDespesa.tipoDespesa;
            radBtnCaracteristicas.SelectedValue = tipoDespesa.caracteristica;

            btnCadastrar.Text = "Salvar";
            btnCancelar.Visible = true;
            btnCadastrar.CommandArgument = tipoDespesa.tipoDespesa;
            btnCadastrar.CommandName = tipoDespesa.categoria.categoria;
        }

        private TipoDespesa GetTipoDespesa(string categoria, string tipoDespesa)
        {

            foreach (var item in listaTipoDespesas)
            {
                if (item.categoria.categoria.Equals(categoria) && item.tipoDespesa.Equals(tipoDespesa))
                {
                    return item;
                }
            }
            return null;
        }

        protected void btnDesativar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            TipoDespesa despesa = GetTipoDespesa(btn.CommandArgument, btn.CommandName);
            if (despesa == null) { return; }

            despesa.status = CategoriaDespesa.Status.DESATIVADO;
            grdDespesas.DataBind();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            tbxTipoDespesa.Text = String.Empty;
            btnCadastrar.Text = "Cadastrar";
            btnCancelar.Visible = false;
        }

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx", true);
        }

        protected void drpDownCategorias_Load(object sender, EventArgs e)
        {
            drpDownCategorias.DataSource = categoriasDAO.GetCategorias();
        }
    }
}
