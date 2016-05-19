using Exercicio12_03_16.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Exercicio12_03_16.Database.DAOs
{

    [DataObject(true)]
    public class LancamentoDAO
    {
        private SqlConnection cn;
        private DespesaDAO despesaDAO;
        private ReceitaDAO receitaDAO;

        public LancamentoDAO()
        {
            cn = new ConnectionFactory().getConnection();
            despesaDAO = new DespesaDAO();
            receitaDAO = new ReceitaDAO();
        }


        public List<Lancamento> FiltrarLancamentos(DateTime dataIni, DateTime dataFim)
        {
            List<Lancamento> listaLancamentos = new List<Lancamento>();

            listaLancamentos.AddRange(despesaDAO.FiltrarDespesas(dataIni, dataFim));
            listaLancamentos.AddRange(receitaDAO.FiltrarReceitas(dataIni, dataFim));

            listaLancamentos.OrderBy(x => x.DataVencimento);

            return listaLancamentos;
        }


        public List<Lancamento> FiltrarLancamentosVencidos(DateTime dataIni, DateTime dataFim)
        {
            List<Lancamento> listaLancamentos = new List<Lancamento>();

            listaLancamentos.AddRange(despesaDAO.FiltrarDespesasVencidas(dataIni, dataFim));
            listaLancamentos.AddRange(receitaDAO.FiltrarReceitasVencidas(dataIni, dataFim));

            listaLancamentos.OrderBy(x => x.DataVencimento);

            return listaLancamentos;
        }

        public List<Lancamento> FiltrarLancamentosVencProximo(DateTime dataIni, DateTime dataFim)
        {
            List<Lancamento> listaLancamentos = new List<Lancamento>();

            listaLancamentos.AddRange(despesaDAO.FiltrarDespesasVencProximo(dataIni, dataFim));
            listaLancamentos.AddRange(receitaDAO.FiltrarReceitasVencProximo(dataIni, dataFim));

            listaLancamentos.OrderBy(x => x.DataVencimento);

            return listaLancamentos;
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Lancamento> GetLancamentos(DateTime dataInicial, DateTime dataFinal, string tpFiltro)
        {
            if (String.IsNullOrEmpty(tpFiltro))
            {
                return FiltrarLancamentos(dataInicial, dataFinal);
            }


            if (tpFiltro.Equals("Vencidos"))
            {
                DateTime dataIniVencidos = new DateTime();
                DateTime dataFimVencidos = DateTime.Today.Subtract(TimeSpan.FromDays(1));
                return FiltrarLancamentosVencidos(dataIniVencidos, dataFimVencidos);
            }
            else if (tpFiltro.Equals("Vencimento Próximo"))
            {
                DateTime dataIniProximos = DateTime.Today;
                DateTime dataFimProximos = DateTime.Today.AddDays(5);
                return FiltrarLancamentosVencProximo(dataIniProximos, dataFimProximos);
            }

            return null;
        }


        public void AtualizarEstatisticas(List<Lancamento> lancamentos, out double custoReceita, out double custoDespesa)
        {
            double totalReceita = 0.0;
            double totalDespesa = 0.0;

            foreach (var item in lancamentos)
            {
                if (item is Receita)
                {
                    totalReceita += item.Valor;
                } else
                {
                    totalDespesa += item.Valor;
                }
            }

            custoReceita = totalReceita;
            custoDespesa = totalDespesa;
        }
    }
}