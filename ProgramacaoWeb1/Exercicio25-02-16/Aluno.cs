using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercicio25_02_16
{
    public class Aluno
    {
        public int matricula { get; set; }
        public string nome { get; set; }
        public float nota1 { get; set; }
        public float nota2 { get; set; }
        public int percFaltas { get; set; }
        public int qtdCreditos { get; set; }

        public Aluno(int matricula, string nome, float nota1, float nota2, int percFaltas, int qtdCreditos)
        {
            this.matricula = matricula;
            this.nome = nome;
            this.nota1 = nota1;
            this.nota2 = nota2;
            this.percFaltas = percFaltas;
            this.qtdCreditos = qtdCreditos;
        }

        public override string ToString()
        {
            return this.matricula + "-" + this.nome;
        }
    }
}