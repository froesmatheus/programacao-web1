using Exercicio12_03_16.Database.DAOs;
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
        private CategoriaDespesaDAO dao;
        protected void Page_Load(object sender, EventArgs e)
        {
            dao = new CategoriaDespesaDAO();
        }

        //protected void btnCadastrar_Click(object sender, EventArgs e)
        //{
        //    if (btnCadastrar.Text.Equals("Salvar"))
        //    {
        //        CategoriaDespesa catDespesa = dao.Get(btnCadastrar.CommandArgument);
        //        if (catDespesa != null)
        //        {
        //            catDespesa.categoria = tbxCategoria.Text;
        //            btnCancelar.Visible = false;
        //            btnCadastrar.Text = "Cadastrar";
        //            dao.Update(catDespesa);
        //            grdDespesas.DataBind();
        //            tbxCategoria.Text = String.Empty;
        //            return;
        //        }
                
        //    }

            
        //    if (dao.Get(tbxCategoria.Text.Trim()) != null)
        //    {
        //        tbxCategoria.Text = String.Empty;
        //        string script = "<script> alert(\"Essa categoria já existe\");</script>";
        //        ScriptManager.RegisterStartupScript(this, typeof(Page), "AlertCategoriaExistente", script, false);
        //        tbxCategoria.Focus();
        //        return;
        //    }

        //    string categoria = tbxCategoria.Text.Trim();

        //    CategoriaDespesa categoriaDespesa = new CategoriaDespesa(categoria, CategoriaDespesa.Status.ATIVO);
        //    dao.Insert(categoriaDespesa);
        //    grdDespesas.DataBind();

           
        //    tbxCategoria.Text = String.Empty;
        //    tbxCategoria.Focus();
        //}

        protected void btnDesativar_Click(object sender, ImageClickEventArgs e)
        {
            CategoriaDespesa categoria = dao.Get(((ImageButton)sender).CommandArgument);
            if (categoria == null) { return; }

            categoria.status = 
                    (categoria.status == CategoriaDespesa.Status.ATIVO) ? CategoriaDespesa.Status.DESATIVADO : CategoriaDespesa.Status.ATIVO;
            dao.Update(categoria);
            grdDespesas.DataBind();
        }

        protected void btnEditar_Click(object sender, ImageClickEventArgs e)
        {
            //TextBox tbxCategoria = (TextBox) FormView1.FindControl("tbxCategoria");
            //tbxCategoria.Text = (((ImageButton)sender).CommandArgument); 
            FormView1.ChangeMode(FormViewMode.Edit);
        }



        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string query = tbxBuscarDepesa.Text;

            if (String.IsNullOrEmpty(query)) { return; }

            btnExcluirFiltro.Visible = true;
            grdDespesas.DataBind();
        }

        protected void btnExcluirFiltro_Click(object sender, EventArgs e)
        {
            grdDespesas.DataBind();
            btnExcluirFiltro.Visible = false;
            tbxBuscarDepesa.Text = String.Empty;
        }

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx", true);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            FormView1.ChangeMode(FormViewMode.Edit);
        }

        protected void grdDespesas_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormView1.PageIndex = grdDespesas.SelectedIndex;
        }

        protected void InsertButton_Click(object sender, EventArgs e)
        {
            FormView1.ChangeMode(FormViewMode.Insert);
        }
    }
}