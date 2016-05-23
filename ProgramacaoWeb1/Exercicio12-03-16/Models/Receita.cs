using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Exercicio12_03_16.Models
{
    public class Receita : Lancamento
    {
        public Receita()
        {

        }
        public Receita(int id, string tipo, string formaRecebimento, float valor,
               DateTime dataVencimento, DateTime dataRecebimento,
               string tipoParcelamento, int qtdParcelas, string observacoes)

   : base(id, tipo, formaRecebimento, valor, dataVencimento, dataRecebimento, tipoParcelamento, qtdParcelas, observacoes)

        {

        }

        public Receita(string tipo, string formaRecebimento, float valor,
               DateTime dataVencimento, DateTime dataRecebimento,
               string tipoParcelamento, int qtdParcelas, string observacoes)

   : base(tipo, formaRecebimento, valor, dataVencimento, dataRecebimento, tipoParcelamento, qtdParcelas, observacoes)

        {

        }

    }
}