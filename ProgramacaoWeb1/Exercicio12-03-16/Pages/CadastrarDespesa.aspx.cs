using Exercicio12_03_16.Database;
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
    public partial class CadastrarDespesa : System.Web.UI.Page
    {
        private DespesaDAO dao;
        private TipoDespesaDAO tipoDespesaDAO;
        protected void Page_Load(object sender, EventArgs e)
        {
            dao = new DespesaDAO();
            tipoDespesaDAO = new TipoDespesaDAO();           

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            //String tipoDespesaStr = drpDownTipoDespesa.SelectedValue;

            
            //TipoDespesa tipoDespesa = null;

            //tipoDespesa = tipoDespesaDAO.GetTipoDespesa(tipoDespesaStr);


            //String FormaRecebimento = drpDownFormaRecebimento.SelectedValue;
            //float Valor = float.Parse(tbxValor.Text);
            //DateTime dataVenc = DateTime.Parse(tbxDataVenc.Text);

            //DateTime result = DateTime.Parse("01/01/0001");
            //DateTime.TryParse(tbxDataRecebimento.Text, out result);

            ////DateTime dataReceb = DateTime.Parse(tbxDataRecebimento.Text);
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

            //String Tipo = tipoDespesaStr + "/" + tipoDespesa.categoria;

            //Despesa despesa;
            //if (TipoParcelamento == Lancamento.PARCELADO)
            //{
            //    float valorParcela = Valor / qtdParcelas;
            //    DateTime DataVencimento = dataVenc;
            //    despesa = new Despesa(Tipo, FormaRecebimento, valorParcela,
            //                              DataVencimento, result, TipoParcelamento,
            //                              qtdParcelas, Observacoes);
            //    despesa.Parcela = 1;
            //    for (int i = 2; i <= qtdParcelas; i++)
            //    {
            //        DataVencimento = DataVencimento.AddMonths(1);
            //        despesa = new Despesa(Tipo, FormaRecebimento, valorParcela,
            //                              DataVencimento, new DateTime(), TipoParcelamento,
            //                              qtdParcelas, Observacoes);
            //        despesa.Parcela = i;
            //        dao.Insert(despesa);
            //    }
            //}
            //else
            //{
            //    despesa = new Despesa(Tipo, FormaRecebimento, Valor,
            //                              dataVenc, result, TipoParcelamento,
            //                              0, Observacoes);
            //    dao.Insert(despesa);
            //}
        }

        protected void rdParcelamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList drpDownParcelas = (DropDownList) FormView1.FindControl("drpDownParcelas");
            RadioButtonList rdParcelamento = (RadioButtonList) FormView1.FindControl("rdParcelamento");
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

        protected void FormView1_ItemInserting(object sender, FormViewInsertEventArgs e)
        {

        }
    }
}