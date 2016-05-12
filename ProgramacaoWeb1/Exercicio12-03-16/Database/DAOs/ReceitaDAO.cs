using Exercicio12_03_16.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Exercicio12_03_16.Database.DAOs
{
    public class ReceitaDAO
    {
        private SqlConnection cn;
        private TipoReceitaDAO tpReceitaDao;

        public ReceitaDAO()
        {
            cn = new ConnectionFactory().getConnection();
            tpReceitaDao = new TipoReceitaDAO();
        }



        public void Insert(Receita receita)
        {
            string str =
                @"INSERT INTO Receitas 
                        (FormaRecebimento, Valor, DataVencimento, DataRecebimento, TipoParcelamento, QtdParcelas, Parcela, Observacoes, Tipo)
                VALUES  (@FormaRecebimento, @Valor, @DataVencimento, @DataRecebimento, @TipoParcelamento, @QtdParcelas, @Parcela, @Observacoes, @Tipo)";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@FormaRecebimento", receita.formaRecebimento));
            sql.Parameters.Add(new SqlParameter("@Valor", receita.valor));
            sql.Parameters.Add(new SqlParameter("@DataVencimento", receita.dataVencimento));
            sql.Parameters.Add(new SqlParameter("@DataRecebimento", receita.dataRecebimento));
            sql.Parameters.Add(new SqlParameter("@TipoParcelamento", receita.tipoParcelamento));
            sql.Parameters.Add(new SqlParameter("@QtdParcelas", receita.qtParcelas));
            sql.Parameters.Add(new SqlParameter("@Parcela", receita.parcela));
            sql.Parameters.Add(new SqlParameter("@Observacoes", receita.observacoes));
            sql.Parameters.Add(new SqlParameter("@Tipo", tpReceitaDao.GetTipoReceitaId(receita.tipo)));


            cn.Open();
            sql.ExecuteNonQuery();
            cn.Close();
        }

        public List<Receita> GetReceitas()
        {
            List<Receita> listaReceitas = new List<Receita>();

            string str = @"select t.Id, 
                                  FormaRecebimento, 
                                  Valor, 
                                  DataVencimento, 
                                  DataRecebimento, 
                                  TipoParcelamento, 
                                  QtdParcelas, 
                                  Parcela, 
                                  Observacoes, 
                                  t.TipoReceita
                           from Receitas r 
                           join TipoReceita t on r.TipoReceita = t.Id;s";

            SqlCommand sql = new SqlCommand(str, cn);

            cn.Open();

            SqlDataReader sdr = sql.ExecuteReader();

            while (sdr.Read())
            {
                Receita receita = new Receita();
                receita.formaRecebimento = sdr["FormaRecebimento"] as string;
                receita.valor = float.Parse(sdr["Valor"].ToString());
                receita.dataVencimento = DateTime.Parse(sdr["DataVencimento"].ToString());
                receita.dataRecebimento = DateTime.Parse(sdr["DataRecebimento"].ToString());
                receita.tipoParcelamento = sdr["TipoParcelamento"] as string;
                receita.qtParcelas = int.Parse(sdr["QtdParcelas"].ToString());
                receita.parcela = int.Parse(sdr["Parcela"].ToString());
                receita.observacoes = sdr["Observacoes"] as string;
                receita.tipo = sdr["TipoReceita"].ToString();

                listaReceitas.Add(receita);
            }
            sdr.Close();
            cn.Close();

            return listaReceitas;
        }


        public List<Receita> FiltrarReceitas(DateTime dataIni, DateTime dataFim)
        {
            List<Receita> listaReceitas = new List<Receita>();

            string str = "select * from Receitas where DataVencimento >= @DataIni and DataVencimento <= @DataFim";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@DataIni", dataIni));
            sql.Parameters.Add(new SqlParameter("@DataFim", dataFim));

            cn.Open();

            SqlDataReader sdr = sql.ExecuteReader();

            while (sdr.Read())
            {
                Receita receita = new Receita();
                receita.formaRecebimento = sdr["FormaRecebimento"] as string;
                receita.valor = float.Parse(sdr["Valor"].ToString());
                receita.dataVencimento = (DateTime)sdr["DataVencimento"];
                receita.dataRecebimento = (DateTime)sdr["DataRecebimento"];
                receita.tipoParcelamento = sdr["TipoParcelamento"] as string;
                receita.qtParcelas = int.Parse(sdr["QtdParcelas"].ToString());
                receita.parcela = int.Parse(sdr["Parcela"].ToString());
                receita.observacoes = sdr["Observacoes"] as string;
                receita.tipo = sdr["Tipo"] as string;

                listaReceitas.Add(receita);
            }
            sdr.Close();
            cn.Close();

            return listaReceitas;
        }


        public List<Receita> FiltrarReceitasVencidas(DateTime dataIni, DateTime dataFim)
        {
            List<Receita> listaReceitas = new List<Receita>();

            string str = "select * from Receitas where DataVencimento <= @DataFim and DataRecebimento = @DataNull";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@DataFim", dataFim));
            sql.Parameters.Add(new SqlParameter("@DataNull", "01/01/0001"));

            cn.Open();

            SqlDataReader sdr = sql.ExecuteReader();

            while (sdr.Read())
            {
                Receita receita = new Receita();
                receita.formaRecebimento = sdr["FormaRecebimento"] as string;
                receita.valor = float.Parse(sdr["Valor"].ToString());
                receita.dataVencimento = (DateTime)sdr["DataVencimento"];
                receita.dataRecebimento = (DateTime)sdr["DataRecebimento"];
                receita.tipoParcelamento = sdr["TipoParcelamento"] as string;
                receita.qtParcelas = int.Parse(sdr["QtdParcelas"].ToString());
                receita.parcela = int.Parse(sdr["Parcela"].ToString());
                receita.observacoes = sdr["Observacoes"] as string;
                receita.tipo = sdr["Tipo"] as string;

                listaReceitas.Add(receita);
            }
            sdr.Close();
            cn.Close();

            return listaReceitas;
        }
    }
}