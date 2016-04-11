using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exercicio12_03_16
{
    public partial class TestesControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListarLancamentos1.qtdDias = 5;
        }
    }
}