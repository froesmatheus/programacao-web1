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
        private List<Receita> listaReceitas;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listaReceitas = new List<Receita>();
                Session["listaReceitas"] = listaReceitas;
            }
            else
            {
                listaReceitas = (List<Receita>)Session["listaReceitas"];
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            String tipoReceitaStr = drpDownTipoReceita.SelectedValue;

            if (Session["listaTipoReceitas"] == null)
            {
                return;
            }
            List<TipoReceita> tiposReceita = (List<TipoReceita>)Session["listaTipoReceitas"];

            TipoReceita tipoReceita = null;
            foreach (var item in tiposReceita)
            {
                if (item.tipoReceita.Equals(tipoReceitaStr))
                {
                    tipoReceita = item;
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
            }
            else
            {
                tipoParcelamento = Despesa.TipoParcelamento.DIVIDIDO;
            }

            string observacoes = tbxObservacoes.Text;
            int qtdParcelas = int.Parse(drpDownParcelas.SelectedValue);

            Receita receita = new Receita(tipoReceitaStr, formaRecebimento, valor,
                                          dataVenc, dataReceb, tipoParcelamento,
                                          qtdParcelas, observacoes);

            listaReceitas.Add(receita);
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

                drpDownFormaRecebimento.DataSource = formasPagamento;
                drpDownFormaRecebimento.DataBind();
            }
        }

        protected void drpDownTipoReceita_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["listaTipoReceitas"] == null)
                {
                    return;
                }
                List<TipoReceita> listaTiposReceita = (List<TipoReceita>)Session["listaTipoReceitas"];
                if (listaTiposReceita != null)
                {
                    drpDownTipoReceita.DataSource = listaTiposReceita;
                    drpDownTipoReceita.DataBind();
                }

            }
        }
    }
}