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
        private List<TipoReceita> listaReceitas;
        private List<string> listaCategoriaReceitas;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                listaReceitas = (List<TipoReceita>)Session["listaReceitas"];
                listaCategoriaReceitas = (List<string>)Session["listaTipoReceitas"];
                grdReceitas.DataSource = listaReceitas;
                grdReceitas.DataBind();
            }
            else
            {
                listaReceitas = new List<TipoReceita>();
                Session["listaReceitas"] = listaReceitas;

                listaCategoriaReceitas = new List<string>();
                listaCategoriaReceitas.Add("Receitas em Geral");
                listaCategoriaReceitas.Add("Transferência entre Contas");
                drpDownCategoriaReceita.DataSource = listaCategoriaReceitas;
                drpDownCategoriaReceita.DataBind();

                drpDownCategoriaReceita2.DataSource = listaCategoriaReceitas;
                drpDownCategoriaReceita2.DataBind();

                if (Session["listaTipoReceitas"] != null)
                {
                    listaCategoriaReceitas = (List<string>)Session["listaTipoReceitas"];
                    drpDownCategoriaReceita.DataSource = listaCategoriaReceitas;
                    drpDownCategoriaReceita.DataBind();

                    drpDownCategoriaReceita2.DataSource = listaCategoriaReceitas;
                    drpDownCategoriaReceita2.DataBind();
                }
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



            foreach (var item in listaReceitas)
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
            listaReceitas.Add(receita);
            grdReceitas.DataBind();

            tbxTxtReceita.Text = String.Empty;
            tbxTxtReceita.Focus();

        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string query = tbxReceita.Text;

            btnExcluirFiltro.Visible = true;
            var results = listaReceitas.Where(x => x.receita.ToLower().Contains(query.ToLower()) &&
            x.tipoReceita.ToString().Equals(drpDownCategoriaReceita2.SelectedValue));

            grdReceitas.DataSource = results;
            grdReceitas.DataBind();
        }

        protected void btnExcluirFiltro_Click(object sender, EventArgs e)
        {
            grdReceitas.DataSource = listaReceitas;
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

            foreach (var item in listaReceitas)
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
    }
}