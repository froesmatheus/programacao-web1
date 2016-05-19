using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Exercicio12_03_16
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }


        public Cliente(string nome, DateTime dataNasc, string email, string senha)
        {
            this.Nome = nome;
            this.DataNasc = dataNasc;
            this.Email = email;
            this.Senha = senha;
        }

        public Cliente()
        {
        }
    }
}