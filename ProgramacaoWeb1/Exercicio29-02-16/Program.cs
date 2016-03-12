using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Pais brasil = new Pais("BRA", "Brasil", 40924024);
            brasil.populacao = 121212;
            Pais uruguai = new Pais("URU", "Uruguai", 3203113);
            uruguai.populacao = 120945;
            Pais argentina = new Pais("ARG", "Argentina", 232390);
            argentina.populacao = 399394;
            Pais colombia = new Pais("COL", "Colombia", 13093);
            colombia.populacao = 230203;
            Pais venezuela = new Pais("VEN", "Venezuela", 13093);
            venezuela.populacao = 230203;

            Continente americaDoSul = new Continente("America do Sul");

            americaDoSul.AddPais(brasil);
            americaDoSul.AddPais(uruguai);
            americaDoSul.AddPais(argentina);
            americaDoSul.AddPais(colombia);
            americaDoSul.AddPais(venezuela);

            Console.WriteLine("Densidade populacional: " + americaDoSul.GetDensidadePopulacional());
            Console.WriteLine("Populacao: " + americaDoSul.GetPopulacao());
            Console.WriteLine("Dimensao: " + americaDoSul.GetDimensao());

            brasil.fronteiras.Add(argentina);
            brasil.fronteiras.Add(colombia);
            uruguai.fronteiras.Add(argentina);
            uruguai.fronteiras.Add(colombia);

            List<Pais> emComum = brasil.VizinhosEmComum(uruguai);

            Console.WriteLine("Vizinhos em comum: ");
            foreach (var item in emComum)
            {
                Console.WriteLine(item.nome);
            }


            // Teste com conjuntos

            Conjunto conjunto1 = new Conjunto();
            Conjunto conjunto2 = new Conjunto();

            conjunto1.Adicionar("A");
            conjunto1.Adicionar("B");
            conjunto1.Adicionar("C");
            conjunto1.Adicionar("D");
            conjunto1.Adicionar("E");
            conjunto1.Adicionar("F");
            Console.WriteLine("Conjunto1: " + conjunto1);

            conjunto2.Adicionar("D");
            conjunto2.Adicionar("E");
            conjunto2.Adicionar("F");
            conjunto2.Adicionar("G");
            conjunto2.Adicionar("H");
            conjunto2.Adicionar("I");
            Console.WriteLine("Conjunto2: " + conjunto2);

            Console.WriteLine("União do conjunto1 com o conjunto2: " + conjunto1.Uniao(conjunto2));

            Console.WriteLine("Interseção do conjunto1 com o conjunto2: " + conjunto1.Intersecao(conjunto2));

            Console.WriteLine("Subtração do conjunto1 com o conjunto2: " + conjunto1.Subtracao(conjunto2));
        }
    }
}
