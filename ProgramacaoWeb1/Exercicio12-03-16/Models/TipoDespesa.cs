using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercicio12_03_16.Models
{
    public class TipoDespesa
    {
        public CategoriaDespesa categoria { get; set; }
        public string tipoDespesa { get; set; }
        public string caracteristica { get; set; }
        public CategoriaDespesa.Status status { get; set; }

        public TipoDespesa(CategoriaDespesa categoria, string despesa, string caracteristica, CategoriaDespesa.Status status)
        {
            this.categoria = categoria;
            this.tipoDespesa = despesa;
            this.caracteristica = caracteristica;
            this.status = status;
        }

        public override string ToString()
        {
            return this.tipoDespesa.ToString();
        }
    }
}