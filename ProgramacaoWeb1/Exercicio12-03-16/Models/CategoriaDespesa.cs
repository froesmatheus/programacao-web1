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

        
        public enum Status
        {
            ATIVO,
            DESATIVADO
        }

        public override string ToString()
        {
            return this.categoria;
        }
    }
}