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

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            String tipoReceitaStr = drpDownTipoReceita.SelectedValue;

            List<TipoReceita> tiposReceita = (List<TipoReceita>)Session["listaTipoReceitas"];

            TipoReceita tipoReceita = tipoReceitaDao.GetTipoReceita(tipoReceitaStr);


            String formaRecebimento = drpDownFormaRecebimento.SelectedValue;
            float valor = float.Parse(tbxValor.Text);
            DateTime dataVenc = DateTime.Parse(tbxDataVenc.Text);

            DateTime result = DateTime.Parse("01/01/1753");
            DateTime.TryParse(tbxDataRecebimento.Text, out result);

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


            tipoReceitaStr = tipoReceita.categoria + "/" + tipoReceitaStr;
            Receita receita;
            if (tipoParcelamento == Lancamento.PARCELADO)
            {
                float valorParcela = valor / qtdParcelas;
                DateTime dataVencimento = dataVenc;
                receita = new Receita(tipoReceitaStr, formaRecebimento, valorParcela,
                                          dataVencimento, result, tipoParcelamento,
                                          qtdParcelas, observacoes);
                receita.parcela = 1;
                for (int i = 2; i <= qtdParcelas; i++)
                {
                    dataVencimento = dataVencimento.AddMonths(1);
                    receita = new Receita(tipoReceitaStr, formaRecebimento, valorParcela,
                                          dataVencimento, new DateTime(), tipoParcelamento,
                                          qtdParcelas, observacoes);
                    receita.parcela = i;
                    dao.Insert(receita);
                }
            }
            else
            {
                receita = new Receita(tipoReceitaStr, formaRecebimento, valor,
                                          dataVenc, result, tipoParcelamento,
                                          0, observacoes);
                dao.Insert(receita);
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


        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx", true);
        }
    }
}