using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercicio12_03_16.Models
{
    public class Lancamento
    {
        public const string UNICO = "Único";
        public const string PARCELADO = "Dividido";

        public int Id { get; set; }
        public string Tipo { get; set; }
        public string FormaRecebimento { get; set; }
        public float Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataRecebimento { get; set; }
        public string TipoParcelamento { get; set; }
        public int QtdParcelas { get; set; }
        public int Parcela { get; set; }
        public string Observacoes { get; set; }

        public Lancamento()
        {

        }

        public Lancamento(string tipo, string formaRecebimento, float valor,
                       DateTime dataVencimento, DateTime dataRecebimento,
                       string tipoParcelamento, int qtdParcelas, string observacoes)
        {
            this.Tipo = tipo;
            this.FormaRecebimento = formaRecebimento;
            this.Valor = valor;
            this.DataVencimento = dataVencimento;
            this.DataRecebimento = dataRecebimento;
            this.TipoParcelamento = tipoParcelamento;
            this.QtdParcelas = qtdParcelas;
            this.Observacoes = observacoes;
        }


        public Lancamento(int id, string tipo, string formaRecebimento, float valor,
                       DateTime dataVencimento, DateTime dataRecebimento,
                       string tipoParcelamento, int qtdParcelas, string observacoes)
        {
            this.Id = id;
            this.Tipo = tipo;
            this.FormaRecebimento = formaRecebimento;
            this.Valor = valor;
            this.DataVencimento = dataVencimento;
            this.DataRecebimento = dataRecebimento;
            this.TipoParcelamento = tipoParcelamento;
            this.QtdParcelas = qtdParcelas;
            this.Observacoes = observacoes;
        }
    }
}