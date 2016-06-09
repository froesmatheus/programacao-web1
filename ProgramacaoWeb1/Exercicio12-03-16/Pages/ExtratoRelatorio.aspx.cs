using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exercicio12_03_16.Relatorios
{
    public partial class ExtratoRelatorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ReportViewer1_Load(object sender, EventArgs e)
        {
            tbxTotalReceita.Text = Session["tbxReceitas"].ToString();
            tbxTotalDespesa.Text = Session["tbxDespesas"].ToString();
            tbxSaldo.Text = Session["tbxSaldo"].ToString();

        }
    }
}