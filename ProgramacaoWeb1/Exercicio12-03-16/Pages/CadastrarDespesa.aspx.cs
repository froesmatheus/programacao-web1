using Exercicio12_03_16.Database;
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
        private DespesaDAO dao;
        protected void Page_Load(object sender, EventArgs e)
        {
            dao = new DespesaDAO();

            dao.GetDespesas();
            if (!IsPostBack)
            {
                if (Session["listaDespesas"] == null)
                {
                    listaDespesas = new List<Despesa>();
                    Session["listaDespesas"] = listaDespesas;
                } else
                {
                    listaDespesas = (List<Despesa>)Session["listaDespesas"];
                }
                
            }
            else
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

            DateTime result = DateTime.Parse("01/01/0001");
            DateTime.TryParse(tbxDataRecebimento.Text, out result);

            //DateTime dataReceb = DateTime.Parse(tbxDataRecebimento.Text);
            string tipoParcelamento;
            if (rdParcelamento.SelectedValue.Equals("Único"))
            {
                tipoParcelamento = Lancamento.UNICO;
            }
            else
            {
                tipoParcelamento = Lancamento.PARCELADO;
            }

            string observacoes = tbxObservacoes.Text;
            int qtdParcelas = int.Parse(drpDownParcelas.SelectedValue);

            String tipo = tipoDespesaStr + "/" + tipoDespesa.categoria;

            Despesa despesa;
            if (tipoParcelamento == Lancamento.PARCELADO)
            {
                float valorParcela = valor / qtdParcelas;
                DateTime dataVencimento = dataVenc;
                despesa = new Despesa(tipo, formaRecebimento, valorParcela,
                                          dataVencimento, result, tipoParcelamento,
                                          qtdParcelas, observacoes);
                despesa.parcela = 1;
                listaDespesas.Add(despesa);
                for (int i = 2; i <= qtdParcelas; i++)
                {
                    dataVencimento = dataVencimento.AddMonths(1);
                    despesa = new Despesa(tipo, formaRecebimento, valorParcela,
                                          dataVencimento, new DateTime(), tipoParcelamento,
                                          qtdParcelas, observacoes);
                    despesa.parcela = i;
                    listaDespesas.Add(despesa);
                    dao.Insert(despesa);
                }
            }
            else
            {
                despesa = new Despesa(tipo, formaRecebimento, valor,
                                          dataVenc, result, tipoParcelamento,
                                          0, observacoes);
                listaDespesas.Add(despesa);
                dao.Insert(despesa);
            }
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

                List<TipoDespesa> tiposDespesa = (List<TipoDespesa>)Session["listaTipoDespesas"];
                if (tiposDespesa != null)
                {
                    drpDownTipoDespesa.DataSource = tiposDespesa;
                    drpDownTipoDespesa.DataBind();
                }
            }
        }

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx", true);
        }
    }
}