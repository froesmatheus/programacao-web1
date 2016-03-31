using Exercicio12_03_16.Models;
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
        private List<Despesa> listaDespesas;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listaDespesas = new List<Despesa>();
                Session["listaDespesas"] = listaDespesas;
            } else
            {
                listaDespesas = (List<Despesa>)Session["listaDespesas"];
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            String tipoDespesaStr = drpDownTipoDespesa.SelectedValue;

            if (Session["listaTipoDespesas"] == null)
            {
                return;
            }
            List<TipoDespesa> tiposDespesa = (List<TipoDespesa>)Session["listaTipoDespesas"];

            TipoDespesa tipoDespesa = null;
            foreach (var item in tiposDespesa)
            {
                if (item.tipoDespesa.Equals(tipoDespesaStr))
                {
                    tipoDespesa = item;
                }
            }




            String formaRecebimento = drpDownFormaRecebimento.SelectedValue;
            float valor = float.Parse(tbxValor.Text);
            DateTime dataVenc = DateTime.Parse(tbxDataVenc.Text);
            DateTime dataReceb = DateTime.Parse(tbxDataRecebimento.Text);
            Despesa.TipoParcelamento tipoParcelamento;
            if (rdParcelamento.SelectedValue.Equals("Único"))
            {
               tipoParcelamento = Despesa.TipoParcelamento.UNICO;
            } else
            {
               tipoParcelamento = Despesa.TipoParcelamento.DIVIDIDO;
            }

            string observacoes = tbxObservacoes.Text;
            int qtdParcelas = int.Parse(drpDownParcelas.SelectedValue);

            String tipo = tipoDespesaStr + "/" + tipoDespesa.categoria;

            Despesa despesa = new Despesa(tipo, formaRecebimento, valor, 
                                          dataVenc, dataReceb, tipoParcelamento, 
                                          qtdParcelas, observacoes);

            listaDespesas.Add(despesa);
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
                for (int i = 2; i <= 12; i++)
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

        protected void drpDownTipoDespesa_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["listaTipoDespesas"] == null)
                {
                    return;
                }

                List<TipoDespesa> tiposDespesa = (List<TipoDespesa>) Session["listaTipoDespesas"];
                if (tiposDespesa != null)
                {
                    drpDownTipoDespesa.DataSource = tiposDespesa;
                    drpDownTipoDespesa.DataBind();
                }
            }
        }
    }
}