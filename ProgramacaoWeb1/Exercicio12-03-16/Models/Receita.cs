﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercicio12_03_16.Models
{
    public class Receita : Lancamento
    {
        public Receita()
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