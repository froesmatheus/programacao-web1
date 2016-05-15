using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Exercicio12_03_16
{
    public class Cliente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime dataNasc { get; set; }
        public string email { get; set; }
        public string senha { get; set; }


        public Cliente(string nome, DateTime dataNasc, string email, string senha)
        {
            this.nome = nome;
            this.dataNasc = dataNasc;
            this.email = email;
            this.senha = senha;
        }

        public Cliente()
        {
        }
    }
}