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
            foreach (var item in listaCatDespesas)
            {
                if (item.categoria.ToLower().Equals(tbxCategoria.Text.Trim().ToLower()))
                {
                    lblCategoriaExistente.Visible = true;
                    tbxCategoria.Text = String.Empty;
                    tbxCategoria.Focus();
                    return;
                }
            }
            lblCategoriaExistente.Visible = false;

            string categoria = tbxCategoria.Text.Trim();

            CategoriaDespesa categoriaDespesa = new CategoriaDespesa(categoria, CategoriaDespesa.Status.ATIVO);


            listaCatDespesas.Add(categoriaDespesa);
            grdDespesas.DataBind();

           
            tbxCategoria.Text = String.Empty;
            tbxCategoria.Focus();
        }

        protected void btnDesativar_Click(object sender, ImageClickEventArgs e)
        {
            string categoria = ((sender as ImageButton).CommandArgument);

            foreach (var item in listaCatDespesas)
            {
                if (item.categoria.Equals(categoria))
                {
                    item.status = CategoriaDespesa.Status.DESATIVADO;
                    grdDespesas.DataBind();
                    return;
                }
            }
        }
    }
}