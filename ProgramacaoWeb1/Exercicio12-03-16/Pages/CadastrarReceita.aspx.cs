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
    }
}