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
        private List<string> listaCategoriaReceitas;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                listaTipoReceitas = (List<TipoReceita>)Session["listaTipoReceitas"];
                listaCategoriaReceitas = (List<string>)Session["listaCategoriaReceitas"];
                grdReceitas.DataSource = listaTipoReceitas;
                grdReceitas.DataBind();
            }
            else
            {
                if (Session["listaTipoReceitas"] == null)
                {
                    listaTipoReceitas = new List<TipoReceita>();
                    Session["listaTipoReceitas"] = listaTipoReceitas;
                } else
                {
                    listaTipoReceitas = (List<TipoReceita>)Session["listaTipoReceitas"];
                    grdReceitas.DataSource = listaTipoReceitas;
                    grdReceitas.DataBind();
                }



                drpDownCategoriaReceita2.DataSource = listaCategoriaReceitas;
                drpDownCategoriaReceita2.DataBind();

                drpDownCategoriaReceita.DataSource = listaCategoriaReceitas;
                drpDownCategoriaReceita.DataBind();
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (btnCadastrar.Text.Equals("Salvar"))
            {
                TipoReceita rec = GetTipoReceita(btnCadastrar.CommandArgument, btnCadastrar.CommandName);
                if (rec != null)
                {
                    rec.receita = tbxTxtReceita.Text;
                    rec.tipoReceita = drpDownCategoriaReceita.SelectedValue;
                    btnCancelar.Visible = false;
                    btnCadastrar.Text = "Cadastrar";
                    grdReceitas.DataBind();
                    tbxTxtReceita.Text = String.Empty;
                    return;
                }

            }



            foreach (var item in listaTipoReceitas)
            {
                if (item.tipoReceita.ToLower().Equals(drpDownCategoriaReceita.SelectedValue.Trim().ToLower()) && item.receita.Trim().ToLower().Equals(tbxTxtReceita.Text.Trim().ToLower()))
                {
                    tbxTxtReceita.Text = String.Empty;
                    string script = "<script> alert(\"Essa receita já existe\");</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "AlertCategoriaExistente", script, false);
                    tbxTxtReceita.Focus();
                    return;
                }
            }


            string receitaStr = tbxTxtReceita.Text;
            string tipoReceita = drpDownCategoriaReceita.SelectedItem.ToString();

            TipoReceita receita = new TipoReceita(receitaStr, tipoReceita);
            listaTipoReceitas.Add(receita);
            grdReceitas.DataBind();

            tbxTxtReceita.Text = String.Empty;
            tbxTxtReceita.Focus();

        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string query = tbxReceita.Text;

            btnExcluirFiltro.Visible = true;
            var results = listaTipoReceitas.Where(x => x.receita.ToLower().Contains(query.ToLower()) &&
            x.tipoReceita.ToString().Equals(drpDownCategoriaReceita2.SelectedValue));

            grdReceitas.DataSource = results;
            grdReceitas.DataBind();
        }

        protected void btnExcluirFiltro_Click(object sender, EventArgs e)
        {
            grdReceitas.DataSource = listaTipoReceitas;
            grdReceitas.DataBind();
            btnExcluirFiltro.Visible = false;
            tbxReceita.Text = String.Empty;
        }

        protected void btnEditar_Click(object sender, ImageClickEventArgs e)
        {
            tbxTxtReceita.Focus();
            TipoReceita receita = GetTipoReceita(((ImageButton)sender).CommandArgument, ((ImageButton)sender).CommandName);
            if (receita == null) { return; }


            tbxTxtReceita.Text = receita.receita;
            drpDownCategoriaReceita.SelectedValue = receita.tipoReceita;

            btnCadastrar.Text = "Salvar";
            btnCancelar.Visible = true;
            btnCadastrar.CommandArgument = receita.tipoReceita;
            btnCadastrar.CommandName = receita.receita;
        }

        private TipoReceita GetTipoReceita(string tipoReceita, string receita)
        {

            foreach (var item in listaTipoReceitas)
            {
                if (item.receita.Equals(receita) && item.tipoReceita.Equals(tipoReceita))
                {
                    return item;
                }
            }
            return null;
        }

        protected void btnDesativar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            TipoReceita receita = GetTipoReceita(btn.CommandArgument, btn.CommandName);
            if (receita == null) { return; }

            receita.status = CategoriaDespesa.Status.DESATIVADO;
            grdReceitas.DataBind();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            tbxTxtReceita.Text = String.Empty;
            btnCadastrar.Text = "Cadastrar";
            btnCancelar.Visible = false;
        }

        protected void drpDownCategoriaReceita_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listaCategoriaReceitas = new List<string>();
                listaCategoriaReceitas.Add("Receitas em Geral");
                listaCategoriaReceitas.Add("Transferência entre Contas");
                drpDownCategoriaReceita.DataSource = listaCategoriaReceitas;
                drpDownCategoriaReceita.DataBind();
            }
        }

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx", true);
        }
    }
}