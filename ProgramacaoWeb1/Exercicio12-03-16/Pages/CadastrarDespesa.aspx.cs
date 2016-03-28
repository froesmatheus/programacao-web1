using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exercicio12_03_16.Pages
{
    public partial class CadastrarDespesa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void rdParcelamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdParcelamento.SelectedIndex == 1)
            {
                drpDownParcelas.Enabled = true;
            }
            else
            {
                drpDownParcelas.Enabled = false;
            }
        }

        protected void drpDownParcelas_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> parcelas = new List<string>();
                for (int i = 1; i <= 12; i++)
                {
                    parcelas.Add(i + "");
                }

                drpDownParcelas.DataSource = parcelas;
                drpDownParcelas.DataBind();
            }
        }

        protected void drpDownFormaRecebimento_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> formasPagamento = new List<string>();
                formasPagamento.Add("Cheque");
                formasPagamento.Add("Dinheiro");
                formasPagamento.Add("Cartão");

                drpDownFormaRecebimento.DataSource = formasPagamento;
                drpDownFormaRecebimento.DataBind();
            }
        }
    }
}