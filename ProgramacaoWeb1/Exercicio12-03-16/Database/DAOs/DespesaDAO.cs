using Exercicio12_03_16.Database.DAOs;
using Exercicio12_03_16.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Exercicio12_03_16.Database
{
    [DataObject(true)]
    public class DespesaDAO
    {
        private SqlConnection cn;
        private TipoDespesaDAO tpDespesaDao;

        public DespesaDAO()
        {
            cn = new ConnectionFactory().getConnection();
            tpDespesaDao = new TipoDespesaDAO();
        }


        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Despesa despesa)
        {
            string str =
                @"INSERT INTO Despesas 
                        (FormaRecebimento, Valor, DataVencimento, DataRecebimento, TipoParcelamento, QtdParcelas, Parcela, Observacoes, Tipo)
                VALUES  (@FormaRecebimento, @Valor, @DataVencimento, @DataRecebimento, @TipoParcelamento, @QtdParcelas, @Parcela, @Observacoes, @Tipo)";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@FormaRecebimento", despesa.FormaRecebimento));
            sql.Parameters.Add(new SqlParameter("@Valor", despesa.Valor));
            sql.Parameters.Add(new SqlParameter("@DataVencimento", despesa.DataVencimento));
            sql.Parameters.Add(new SqlParameter("@DataRecebimento", despesa.DataRecebimento));
            sql.Parameters.Add(new SqlParameter("@TipoParcelamento", despesa.TipoParcelamento));
            sql.Parameters.Add(new SqlParameter("@QtdParcelas", despesa.QtdParcelas));
            sql.Parameters.Add(new SqlParameter("@Parcela", despesa.Parcela));
            sql.Parameters.Add(new SqlParameter("@Observacoes", despesa.Observacoes));
            sql.Parameters.Add(new SqlParameter("@Tipo", tpDespesaDao.GetTipoDespesaId(despesa.Tipo)));


            cn.Open();
            sql.ExecuteNonQuery();
            cn.Close();
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Despesa despesa)
        {
            string str = "delete from Despesas where Id = @Id";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@Id", despesa.Id));

            cn.Open();
            sql.ExecuteNonQuery();
            cn.Close();
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Despesa despesa)
        {
            string str = @"update Despesas set FormaRecebimento = @FormaRecebimento,
                                               Valor = @Valor,
                                               DataVencimento = @DataVencimento,
                                               DataRecebimento = @DataRecebimento,
                                               TipoParcelamento = @TipoParcelamento,
                                               QtdParcelas = @QtdParcelas,
                                               Parcela = @Parcela,
                                               Observacoes = @Observacoes,
                                               Tipo = @Tipo
                           where Id = @Id";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@FormaRecebimento", despesa.FormaRecebimento));
            sql.Parameters.Add(new SqlParameter("@Valor", despesa.Valor));
            sql.Parameters.Add(new SqlParameter("@DataVencimento", despesa.DataVencimento));
            sql.Parameters.Add(new SqlParameter("@DataRecebimento", despesa.DataRecebimento));
            sql.Parameters.Add(new SqlParameter("@TipoParcelamento", despesa.TipoParcelamento));
            sql.Parameters.Add(new SqlParameter("@QtdParcelas", despesa.QtdParcelas));
            sql.Parameters.Add(new SqlParameter("@Parcela", despesa.Parcela));
            sql.Parameters.Add(new SqlParameter("@Observacoes", despesa.Observacoes));
            sql.Parameters.Add(new SqlParameter("@Tipo", tpDespesaDao.GetTipoDespesaId(despesa.Tipo)));
            sql.Parameters.Add(new SqlParameter("@Id", despesa.Id));

            cn.Open();
            sql.ExecuteNonQuery();
            cn.Close();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
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
                despesa.FormaRecebimento = sdr["FormaRecebimento"] as string;
                despesa.Valor = float.Parse(sdr["Valor"].ToString());
                despesa.DataVencimento = (DateTime)sdr["DataVencimento"];
                despesa.DataRecebimento = (DateTime)sdr["DataRecebimento"];
                despesa.TipoParcelamento = sdr["TipoParcelamento"] as string;
                despesa.QtdParcelas = int.Parse(sdr["QtdParcelas"].ToString());
                despesa.Parcela = int.Parse(sdr["Parcela"].ToString());
                despesa.Observacoes = sdr["Observacoes"] as string;
                despesa.Tipo = sdr["Tipo"] as string;

                listaDespesas.Add(despesa);
            }
            sdr.Close();
            cn.Close();

            return listaDespesas;
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Despesa> FiltrarDespesasVencProximo(DateTime dataIni, DateTime dataFim)
        {
            List<Despesa> listaDespesas = new List<Despesa>();

            string str = "select * from Despesas where DataVencimento >= @DataIni and DataVencimento <= @DataFim and DataRecebimento = @DataNull";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@DataIni", dataIni));
            sql.Parameters.Add(new SqlParameter("@DataFim", dataFim));
            sql.Parameters.Add(new SqlParameter("@DataNull", "01/01/0001"));

            cn.Open();

            SqlDataReader sdr = sql.ExecuteReader();

            while (sdr.Read())
            {
                Despesa despesa = new Despesa();
                despesa.FormaRecebimento = sdr["FormaRecebimento"] as string;
                despesa.Valor = float.Parse(sdr["Valor"].ToString());
                despesa.DataVencimento = (DateTime)sdr["DataVencimento"];
                despesa.DataRecebimento = (DateTime)sdr["DataRecebimento"];
                despesa.TipoParcelamento = sdr["TipoParcelamento"] as string;
                despesa.QtdParcelas = int.Parse(sdr["QtdParcelas"].ToString());
                despesa.Parcela = int.Parse(sdr["Parcela"].ToString());
                despesa.Observacoes = sdr["Observacoes"] as string;
                despesa.Tipo = sdr["Tipo"] as string;

                listaDespesas.Add(despesa);
            }
            sdr.Close();
            cn.Close();

            return listaDespesas;
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
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
                despesa.FormaRecebimento = sdr["FormaRecebimento"] as string;
                despesa.Valor = float.Parse(sdr["Valor"].ToString());
                despesa.DataVencimento = (DateTime)sdr["DataVencimento"];
                despesa.DataRecebimento = (DateTime)sdr["DataRecebimento"];
                despesa.TipoParcelamento = sdr["TipoParcelamento"] as string;
                despesa.QtdParcelas = int.Parse(sdr["QtdParcelas"].ToString());
                despesa.Parcela = int.Parse(sdr["Parcela"].ToString());
                despesa.Observacoes = sdr["Observacoes"] as string;
                despesa.Tipo = sdr["Tipo"] as string;

                listaDespesas.Add(despesa);
            }
            sdr.Close();
            cn.Close();

            return listaDespesas;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
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
                despesa.FormaRecebimento = sdr["FormaRecebimento"] as string;
                despesa.Valor = float.Parse(sdr["Valor"].ToString());
                despesa.DataVencimento = (DateTime)sdr["DataVencimento"];
                despesa.DataRecebimento = (DateTime)sdr["DataRecebimento"];
                despesa.TipoParcelamento = sdr["TipoParcelamento"] as string;
                despesa.QtdParcelas = int.Parse(sdr["QtdParcelas"].ToString());
                despesa.Parcela = int.Parse(sdr["Parcela"].ToString());
                despesa.Observacoes = sdr["Observacoes"] as string;
                despesa.Tipo = sdr["Tipo"] as string;

                listaDespesas.Add(despesa);
            }
            sdr.Close();
            cn.Close();

            return listaDespesas;
        }
    }
}