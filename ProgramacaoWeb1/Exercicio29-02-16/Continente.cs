using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Continente
    {
        public string nome { get; set; }
        public List<Pais> paises { get; set; }

        public Continente(string nome)
        {
            this.nome = nome;
            this.paises = new List<Pais>();
        }

        public void AddPais(Pais pais)
        {
           if (!this.paises.Contains(pais))
            {
                this.paises.Add(pais);
            }
        }

        public double GetDimensao()
        {
            double dimensao = 0;
            for (int i = 0; i < paises.Count; i++)
            {
                dimensao += paises[i].dimensao;
            }
            return dimensao;
        }

        public double GetPopulacao()
        {
            long populacao = 0;
            for (int i = 0; i < paises.Count; i++)
            {
                populacao += paises[i].populacao;
            }
            return populacao;
        }

        public double GetDensidadePopulacional()
        {
            return this.GetPopulacao() / this.GetDimensao();
        }
    }
}
