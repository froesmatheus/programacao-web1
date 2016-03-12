using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Conjunto
    { 
        private List<String> elementos { get; set; }

        public Conjunto()
        {
            elementos = new List<string>();
        }

        public void Adicionar(String elemento)
        {
            if (!this.elementos.Contains(elemento))
            {
                this.elementos.Add(elemento);
            }
        }

        public bool Contem(String elemento)
        {
            return this.elementos.Contains(elemento);
        }

        public Conjunto Uniao(Conjunto set)
        {
            Conjunto conjunto = new Conjunto();

            foreach (String element in elementos)
            {
                conjunto.Adicionar(element);
            }

            foreach (String element in set.elementos)
            {
                conjunto.Adicionar(element);
            }

            return conjunto;
        }


        public Conjunto Intersecao(Conjunto set)
        {
            Conjunto conjunto = new Conjunto();

            foreach (String item in set.elementos)
            {
                if (this.elementos.Contains(item))
                {
                    conjunto.Adicionar(item);
                }
            }

            return conjunto;
        }


        public Conjunto Subtracao(Conjunto set)
        {
            Conjunto conjunto = new Conjunto();

            foreach (String item in this.elementos)
            {
                if (!set.elementos.Contains(item))
                {
                    conjunto.Adicionar(item);
                }
            }

            return conjunto;
        }


        public override string ToString()
        {
            if (this.elementos.Count == 0)
            {
                return "[]";
            }

            StringBuilder builder = new StringBuilder("[");
            for (int i = 0; i < elementos.Count-1; i++)
            {
                builder.Append(elementos[i]);
                builder.Append(", ");
            }

            builder.Append(elementos[elementos.Count-1] + "]");

            return builder.ToString();
        }
    }
}
