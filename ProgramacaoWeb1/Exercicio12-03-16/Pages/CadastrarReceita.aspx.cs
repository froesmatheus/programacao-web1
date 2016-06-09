using Exercicio12_03_16.Database.DAOs;
using Exercicio12_03_16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exercicio12_03_16.Pages
{
    public partial class CadastrarReceita : System.Web.UI.Page
    {
        private ReceitaDAO dao;
        private TipoReceitaDAO tipoReceitaDao;

        protected void Page_Load(object sender, EventArgs e)
        {
            dao = new ReceitaDAO();
            tipoReceitaDao = new TipoReceitaDAO();
        }
        

        protected void rdParcelamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList drpDownParcelas = (DropDownList)FormView1.FindControl("drpDownParcelas");
            RadioButtonList rdParcelamento = (RadioButtonList)FormView1.FindControl("rdParcelamento");
            if (rdParcelamento.SelectedIndex == 1)
            {
                drpDownParcelas.Enabled = true;
            }
            else
            {
                drpDownParcelas.Enabled = false;
            }
        }


        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx", true);
        }

        protected void ObjectDataSource2_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {

            e.ExceptionHandled = true;
            Label label = (Label)ModalPopupExtender1.FindControl("LabelMessage");
            if (e.Exception != null)
            {
                label.Text = "Erro!: " + e.Exception.InnerException.Message;
            } else if (int.Parse(e.ReturnValue.ToString()) > 0)
            {
                label.Text = "Receita adicionada com sucesso";
            }
            else
            {
                label.Text = "Erro!";
            }

            
            ModalPopupExtender1.Show();
        }

        protected void ObjectDataSource2_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
        {

        }

        protected void FormView1_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            if (e.Values[4].Equals(""))
            {
                e.Values[4] = DateTime.Parse("01/01/0001");
            }
        }
    }
}