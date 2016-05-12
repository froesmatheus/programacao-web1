using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercicio12_03_16.Models
{
    public class TipoReceita
    {
        public int id { get; set; }
        public string tipoReceita { get; set; }
        public string categoria { get; set; }
        public CategoriaDespesa.Status status { get; set; }


        public TipoReceita(string tipoReceita, string categoria)
        {
            this.categoria = categoria;
            this.tipoReceita = tipoReceita;
        }

        public TipoReceita()
        {
        }

        public override string ToString()
        {
            return this.tipoReceita;
        }
    }
}