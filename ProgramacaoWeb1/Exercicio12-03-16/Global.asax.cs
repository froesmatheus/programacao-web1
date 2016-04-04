using Exercicio12_03_16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Exercicio12_03_16
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            List<CategoriaDespesa> listaCatDespesas = new List<CategoriaDespesa>()
            {
                new CategoriaDespesa("Alimentação", CategoriaDespesa.Status.ATIVO),
                new CategoriaDespesa("Saúde", CategoriaDespesa.Status.ATIVO),
                new CategoriaDespesa("Universidade", CategoriaDespesa.Status.ATIVO),
                new CategoriaDespesa("Casa", CategoriaDespesa.Status.ATIVO)
            };
            Session["listaCatDespesas"] = listaCatDespesas;



            List<TipoDespesa> listaTipoDespesas = new List<TipoDespesa>()
            {
                new TipoDespesa(listaCatDespesas[0], "Almoços", "A", CategoriaDespesa.Status.ATIVO),
                new TipoDespesa(listaCatDespesas[1], "Unimed", "A", CategoriaDespesa.Status.ATIVO),
                new TipoDespesa(listaCatDespesas[2], "Xerox", "A", CategoriaDespesa.Status.ATIVO),
                new TipoDespesa(listaCatDespesas[3], "Energia", "A", CategoriaDespesa.Status.ATIVO)
            };

            Session["listaTipoDespesas"] = listaTipoDespesas;




            List<TipoReceita> listaTipoReceitas = new List<TipoReceita>()
            {
                new TipoReceita("Salário", "Receitas em Geral"),
                new TipoReceita("Bônus salarial", "Receitas em Geral"),
            };
            Session["listaTipoReceitas"] = listaTipoReceitas;

            


            List<Despesa> listaDespesas = new List<Despesa>()
            {
                new Despesa(listaCatDespesas[0] + "/" + listaTipoDespesas[0], "Dinheiro", 50, new DateTime(2016, 3, 25), new DateTime(2016, 3, 25), Lancamento.UNICO, 0, ""),
                new Despesa("Universidade", "Dinheiro", 150, new DateTime(2016, 3, 24), new DateTime(2016, 3, 24), Lancamento.UNICO, 0, ""),
                new Despesa("Saúde", "Dinheiro", 5000, new DateTime(2016, 3, 13), new DateTime(2016, 3, 12), Lancamento.UNICO, 0, ""),
                new Despesa("Casa", "Dinheiro", 350, new DateTime(2016, 3, 25), new DateTime(2016, 4, 5), Lancamento.UNICO, 0, ""),
                new Despesa("Alimentação", "Dinheiro", 50, new DateTime(2016, 3, 25), new DateTime(2016, 4, 30), Lancamento.UNICO, 0, ""),
                new Despesa("Alimentação", "Dinheiro", 50, new DateTime(2016, 3, 25), new DateTime(2016, 4, 30), Lancamento.UNICO, 0, ""),

            };

            List<Receita> listaReceitas = new List<Receita>()
            {
                new Receita("Salário", "Dinheiro", 1000, new DateTime(2016, 3, 25), new DateTime(2016, 3, 25), Lancamento.UNICO, 0, ""),
                new Receita("Estágio", "Dinheiro", 300, new DateTime(2016, 3, 25), new DateTime(2016, 3, 25), Lancamento.UNICO, 0, ""),
            };

            Session["listaDespesas"] = listaDespesas;
            Session["listaReceitas"] = listaReceitas;
        }



        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}