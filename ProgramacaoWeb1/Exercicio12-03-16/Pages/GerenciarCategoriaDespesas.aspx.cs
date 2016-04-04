using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exercicio12_03_16
{
    public partial class GerenciarDespesas : System.Web.UI.Page
    {
        private List<CategoriaDespesa> listaCatDespesas;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["listaCatDespesas"] == null)
            {
                listaCatDespesas = new List<CategoriaDespesa>();
                Session["listaCatDespesas"] = listaCatDespesas;
            } else
            {
                listaCatDespesas = (List<CategoriaDespesa>) Session["listaCatDespesas"];
                grdDespesas.DataSource = listaCatDespesas;
                grdDespesas.DataBind();
            }
            
            if (grdDespesas.DataSource == null)
            {
                grdDespesas.DataSource = listaCatDespesas;
                grdDespesas.DataBind();
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (btnCadastrar.Text.Equals("Salvar"))
            {
                CategoriaDespesa catDespesa = GetCategoria(btnCadastrar.CommandArgument);
                if (catDespesa != null)
                {
                    catDespesa.categoria = tbxCategoria.Text;
                    btnCancelar.Visible = false;
                    btnCadastrar.Text = "Cadastrar";
                    grdDespesas.DataBind();
                    tbxCategoria.Text = String.Empty;
                    return;
                }
                
            }


            // Verificando se a categoria já existe
            foreach (var item in listaCatDespesas)
            {
                if (item.categoria.ToLower().Equals(tbxCategoria.Text.Trim().ToLower()))
                {
                    tbxCategoria.Text = String.Empty;
                    string script = "<script> alert(\"Essa categoria já existe\");</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "AlertCategoriaExistente", script, false);
                    tbxCategoria.Focus();
                    return;
                }
            }

            string categoria = tbxCategoria.Text.Trim();

            CategoriaDespesa categoriaDespesa = new CategoriaDespesa(categoria, CategoriaDespesa.Status.ATIVO);


            listaCatDespesas.Add(categoriaDespesa);
            grdDespesas.DataBind();

           
            tbxCategoria.Text = String.Empty;
            tbxCategoria.Focus();
        }

        protected void btnDesativar_Click(object sender, ImageClickEventArgs e)
        {
            CategoriaDespesa categoria = GetCategoria(((ImageButton)sender).CommandArgument);
            if (categoria == null) { return; }

            categoria.status = CategoriaDespesa.Status.DESATIVADO;
            grdDespesas.DataBind();
        }

        protected void btnEditar_Click(object sender, ImageClickEventArgs e)
        {
            tbxCategoria.Focus();
            CategoriaDespesa categoria = GetCategoria(((ImageButton)sender).CommandArgument);
            if (categoria == null) { return; }


            tbxCategoria.Text = categoria.categoria;

            btnCadastrar.Text = "Salvar";
            btnCancelar.Visible = true;
            btnCadastrar.CommandArgument = categoria.categoria;
        }

        private CategoriaDespesa GetCategoria(string categoria)
        {
 
            foreach (var item in listaCatDespesas)
            {
                if (item.categoria.Equals(categoria))
                {
                    return item;
                }
            }
            return null;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            tbxCategoria.Text = String.Empty;
            btnCadastrar.Text = "Cadastrar";
            btnCancelar.Visible = false;
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string query = tbxBuscarDepesa.Text;

            if (String.IsNullOrEmpty(query)) { return; }

            btnExcluirFiltro.Visible = true;
            var results = listaCatDespesas.Where(x => x.categoria.ToLower().Contains(query.ToLower()));
            grdDespesas.DataSource = results;
            grdDespesas.DataBind();
        }

        protected void btnExcluirFiltro_Click(object sender, EventArgs e)
        {
            grdDespesas.DataSource = listaCatDespesas;
            grdDespesas.DataBind();
            btnExcluirFiltro.Visible = false;
            tbxBuscarDepesa.Text = String.Empty;
        }

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx", true);
        }
    }
}