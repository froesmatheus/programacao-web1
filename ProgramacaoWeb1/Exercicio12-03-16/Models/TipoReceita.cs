using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercicio12_03_16.Models
{
    public class TipoReceita
    {
        public string receita { get; set; }
        public string tipoReceita { get; set; }
        public CategoriaDespesa.Status status { get; set; }


        public TipoReceita(string receita, string tipoReceita)
        {
            this.receita = receita;
            this.tipoReceita = tipoReceita;
        }

        public override string ToString()
        {
            return this.receita;
        }
    }
}