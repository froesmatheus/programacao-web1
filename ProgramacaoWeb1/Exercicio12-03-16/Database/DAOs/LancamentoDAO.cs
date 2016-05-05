using Exercicio12_03_16.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Exercicio12_03_16.Database.DAOs
{
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

            listaLancamentos.OrderBy(x => x.dataVencimento);

            return listaLancamentos;
        }


        public List<Lancamento> FiltrarLancamentosVencidos(DateTime dataIni, DateTime dataFim)
        {
            List<Lancamento> listaLancamentos = new List<Lancamento>();

            listaLancamentos.AddRange(despesaDAO.FiltrarDespesas(dataIni, dataFim));
            listaLancamentos.AddRange(receitaDAO.FiltrarReceitas(dataIni, dataFim));

            listaLancamentos.OrderBy(x => x.dataVencimento);

            return listaLancamentos;
        }
    }
}