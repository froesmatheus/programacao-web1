using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercicio12_03_16
{
    public class CategoriaDespesa
    {
        public int id { get; set; }
        public string categoria { get; set; }
        public Status status { get; set; }

        public CategoriaDespesa(string categoria, Status status)
        {
            this.categoria = categoria;
            this.status = status;
        }

        public CategoriaDespesa()
        {
        }

        public enum Status
        {
            ATIVO = 0,
            DESATIVADO = 1
        }

        public override string ToString()
        {
            return this.categoria;
        }
    }
}