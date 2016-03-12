using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Pais
    {
        public string codigoIso { get; set; }
        public string nome { get; set; }
        public long populacao { get; set; }
        public double dimensao { get; set; }
        public List<Pais> fronteiras { get; set; }

        public Pais(string codigoIso)
        {
            this.codigoIso = codigoIso;
            this.fronteiras = new List<Pais>();
        }

        public Pais(string codigoIso, string nome) : this(codigoIso)
        {
            this.nome = nome;
        }
  
        public Pais(string codigoIso, string nome, double dimensao) : this(codigoIso, nome)
        {
            this.dimensao = dimensao;
        }


        public override bool Equals(object obj)
        {
            if (obj != null && obj is Pais)
            {
                if ( ((Pais) obj).codigoIso.Equals(this.codigoIso))
                {
                    return true;
                }
            }

            return false;
        }
    
        public override int GetHashCode()
        {
            return this.codigoIso.GetHashCode();
        }


        public double GetDensidadePopulacional()
        {
            return populacao / dimensao;
        }


        public bool IsLimitrofe(Pais pais)
        {
            if (this.fronteiras.Contains(pais))
            {
                return true;
            }

            return false;
        }


        public List<Pais> VizinhosEmComum(Pais pais)
        {
            List<Pais> paisesEmComum = new List<Pais>();

            for (int i = 0; i < pais.fronteiras.Count; i++)
            {
                if (this.fronteiras.Contains(pais.fronteiras[i]))
                {
                    paisesEmComum.Add(pais.fronteiras[i]);
                }
            }

            return paisesEmComum;
        }

    }
}
