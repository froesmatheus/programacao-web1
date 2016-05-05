using Exercicio12_03_16.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Exercicio12_03_16.Database
{
    public class DespesaDAO
    {
        private SqlConnection cn;

        public DespesaDAO()
        {
            cn = new ConnectionFactory().getConnection();
        }



        public void Insert(Despesa despesa)
        {
            string str = 
                @"INSERT INTO Despesas 
                        (FormaRecebimento, Valor, DataVencimento, DataRecebimento, TipoParcelamento, QtdParcelas, Parcela, Observacoes, Tipo)
                VALUES  (@FormaRecebimento, @Valor, @DataVencimento, @DataRecebimento, @TipoParcelamento, @QtdParcelas, @Parcela, @Observacoes, @Tipo)";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@FormaRecebimento", despesa.formaRecebimento));
            sql.Parameters.Add(new SqlParameter("@Valor", despesa.valor));
            sql.Parameters.Add(new SqlParameter("@DataVencimento", despesa.dataVencimento));
            sql.Parameters.Add(new SqlParameter("@DataRecebimento", despesa.dataRecebimento));
            sql.Parameters.Add(new SqlParameter("@TipoParcelamento", despesa.tipoParcelamento));
            sql.Parameters.Add(new SqlParameter("@QtdParcelas", despesa.qtParcelas));
            sql.Parameters.Add(new SqlParameter("@Parcela", despesa.parcela));
            sql.Parameters.Add(new SqlParameter("@Observacoes", despesa.observacoes));
            sql.Parameters.Add(new SqlParameter("@Tipo", despesa.tipo));


            cn.Open();
            sql.ExecuteNonQuery();
            cn.Close();
        }


        public List<Despesa> GetDespesas()
        {
            List<Despesa> listaDespesas = new List<Despesa>();

            string str = "select * from Despesas";

            SqlCommand sql = new SqlCommand(str, cn);

            cn.Open();

            SqlDataReader sdr = sql.ExecuteReader();
            
            while (sdr.Read())
            {
                Despesa despesa = new Despesa();
                despesa.formaRecebimento = sdr["FormaRecebimento"] as string;
                despesa.valor = float.Parse(sdr["Valor"].ToString());
                despesa.dataVencimento = (DateTime) sdr["DataVencimento"];
                despesa.dataRecebimento = (DateTime)sdr["DataRecebimento"];
                despesa.tipoParcelamento = sdr["TipoParcelamento"] as string;
                despesa.qtParcelas = int.Parse(sdr["QtdParcelas"].ToString());
                despesa.parcela = int.Parse(sdr["Parcela"].ToString());
                despesa.observacoes = sdr["Observacoes"] as string;
                despesa.tipo = sdr["Tipo"] as string;

                listaDespesas.Add(despesa);
            }
            sdr.Close();
            cn.Close();

            return listaDespesas;
        }


        public List<Despesa> FiltrarDespesas(DateTime dataIni, DateTime dataFim)
        {
            List<Despesa> listaDespesas = new List<Despesa>();

            string str = "select * from Despesas where DataVencimento >= @DataIni and DataVencimento <= @DataFim";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@DataIni", dataIni));
            sql.Parameters.Add(new SqlParameter("@DataFim", dataFim));

            cn.Open();

            SqlDataReader sdr = sql.ExecuteReader();

            while (sdr.Read())
            {
                Despesa despesa = new Despesa();
                despesa.formaRecebimento = sdr["FormaRecebimento"] as string;
                despesa.valor = float.Parse(sdr["Valor"].ToString());
                despesa.dataVencimento = (DateTime)sdr["DataVencimento"];
                despesa.dataRecebimento = (DateTime)sdr["DataRecebimento"];
                despesa.tipoParcelamento = sdr["TipoParcelamento"] as string;
                despesa.qtParcelas = int.Parse(sdr["QtdParcelas"].ToString());
                despesa.parcela = int.Parse(sdr["Parcela"].ToString());
                despesa.observacoes = sdr["Observacoes"] as string;
                despesa.tipo = sdr["Tipo"] as string;

                listaDespesas.Add(despesa);
            }
            sdr.Close();
            cn.Close();

            return listaDespesas;
        }


        public List<Despesa> FiltrarDespesasVencidas(DateTime dataIni, DateTime dataFim)
        {
            List<Despesa> listaDespesas = new List<Despesa>();

            string str = "select * from Despesas where DataVencimento <= @DataFim and DataRecebimento = @DataNull";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@DataFim", dataFim));
            sql.Parameters.Add(new SqlParameter("@DataNull", "01/01/0001"));

            cn.Open();

            SqlDataReader sdr = sql.ExecuteReader();

            while (sdr.Read())
            {
                Despesa despesa = new Despesa();
                despesa.formaRecebimento = sdr["FormaRecebimento"] as string;
                despesa.valor = float.Parse(sdr["Valor"].ToString());
                despesa.dataVencimento = (DateTime)sdr["DataVencimento"];
                despesa.dataRecebimento = (DateTime)sdr["DataRecebimento"];
                despesa.tipoParcelamento = sdr["TipoParcelamento"] as string;
                despesa.qtParcelas = int.Parse(sdr["QtdParcelas"].ToString());
                despesa.parcela = int.Parse(sdr["Parcela"].ToString());
                despesa.observacoes = sdr["Observacoes"] as string;
                despesa.tipo = sdr["Tipo"] as string;

                listaDespesas.Add(despesa);
            }
            sdr.Close();
            cn.Close();

            return listaDespesas;
        }
    }
}