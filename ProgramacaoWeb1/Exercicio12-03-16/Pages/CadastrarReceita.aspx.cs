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
            //String tipoReceitaStr = drpDownTipoReceita.SelectedValue;

            //List<TipoReceita> tiposReceita = (List<TipoReceita>)Session["listaTipoReceitas"];

            //TipoReceita tipoReceita = tipoReceitaDao.GetTipoReceita(tipoReceitaStr);


            //String FormaRecebimento = drpDownFormaRecebimento.SelectedValue;
            //float Valor = float.Parse(tbxValor.Text);
            //DateTime dataVenc = DateTime.Parse(tbxDataVenc.Text);

            //DateTime result = DateTime.Parse("01/01/1753");
            //DateTime.TryParse(tbxDataRecebimento.Text, out result);

            //string TipoParcelamento;
            //if (rdParcelamento.SelectedValue.Equals("Único"))
            //{
            //    TipoParcelamento = Lancamento.UNICO;
            //}
            //else
            //{
            //    TipoParcelamento = Lancamento.PARCELADO;
            //}

            //string Observacoes = tbxObservacoes.Text;
            //int qtdParcelas = int.Parse(drpDownParcelas.SelectedValue);


            //tipoReceitaStr = tipoReceita.categoria + "/" + tipoReceitaStr;
            //Receita receita;
            //if (TipoParcelamento == Lancamento.PARCELADO)
            //{
            //    float valorParcela = Valor / qtdParcelas;
            //    DateTime DataVencimento = dataVenc;
            //    receita = new Receita(tipoReceitaStr, FormaRecebimento, valorParcela,
            //                              DataVencimento, result, TipoParcelamento,
            //                              qtdParcelas, Observacoes);
            //    receita.Parcela = 1;
            //    for (int i = 2; i <= qtdParcelas; i++)
            //    {
            //        DataVencimento = DataVencimento.AddMonths(1);
            //        receita = new Receita(tipoReceitaStr, FormaRecebimento, valorParcela,
            //                              DataVencimento, new DateTime(), TipoParcelamento,
            //                              qtdParcelas, Observacoes);
            //        receita.Parcela = i;
            //        dao.Insert(receita);
            //    }
            //}
            //else
            //{
            //    receita = new Receita(tipoReceitaStr, FormaRecebimento, Valor,
            //                              dataVenc, result, TipoParcelamento,
            //                              0, Observacoes);
            //    dao.Insert(receita);
            //}
        }


        protected void rdParcelamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (rdParcelamento.SelectedIndex == 1)
            //{
            //    drpDownParcelas.Enabled = true;
            //}
            //else
            //{
            //    drpDownParcelas.Enabled = false;
            //}
        }


        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx", true);
        }
    }
}