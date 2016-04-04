using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercicio12_03_16.Models
{
    public class Lancamento
    {
        public const string UNICO = "Único";
        public const string PARCELADO = "Parcelado";


        public string tipo { get; set; }
        public string formaRecebimento { get; set; }
        public float valor { get; set; }
        public DateTime dataVencimento { get; set; }
        public DateTime dataRecebimento { get; set; }
        public string tipoParcelamento { get; set; }
        public int qtParcelas { get; set; }
        public int parcela { get; set; }
        public string observacoes { get; set; }

        public Lancamento(string tipo, string formaRecebimento, float valor,
                       DateTime dataVencimento, DateTime dataRecebimento,
                       string tipoParcelamento, int qtdParcelas, string observacoes)
        {
            this.tipo = tipo;
            this.formaRecebimento = formaRecebimento;
            this.valor = valor;
            this.dataVencimento = dataVencimento;
            this.dataRecebimento = dataRecebimento;
            this.tipoParcelamento = tipoParcelamento;
            this.qtParcelas = qtdParcelas;
            this.observacoes = observacoes;
        }
    }
}