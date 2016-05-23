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
            if (despesa.TipoParcelamento == Lancamento.PARCELADO)
            {
                InsertParcelado(despesa);
                return;
            }

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

        private void InsertParcelado(Despesa desp)
        {
            float valorParcela = desp.Valor / desp.QtdParcelas;
            DateTime DataVencimento = desp.DataVencimento;

            desp.Valor = valorParcela;
            desp.Parcela = 1;
            InsertParcela(desp);
            for (int i = 2; i <= desp.QtdParcelas; i++)
            {
                DataVencimento = DataVencimento.AddMonths(1);
                desp = new Despesa(desp.Tipo, desp.FormaRecebimento, valorParcela,
                                      DataVencimento, new DateTime(), desp.TipoParcelamento,
                                      desp.QtdParcelas, desp.Observacoes);
                desp.Parcela = i;
                InsertParcela(desp);
            }

        }

        private void InsertParcela(Despesa desp)
        {
            string str =
                @"INSERT INTO Despesas 
                        (FormaRecebimento, Valor, DataVencimento, DataRecebimento, TipoParcelamento, QtdParcelas, Parcela, Observacoes, Tipo)
                VALUES  (@FormaRecebimento, @Valor, @DataVencimento, @DataRecebimento, @TipoParcelamento, @QtdParcelas, @Parcela, @Observacoes, @Tipo)";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@FormaRecebimento", desp.FormaRecebimento));
            sql.Parameters.Add(new SqlParameter("@Valor", desp.Valor));
            sql.Parameters.Add(new SqlParameter("@DataVencimento", desp.DataVencimento));

            if (desp.DataRecebimento.Equals(DateTime.Parse("01/01/0001 00:00:00")))
            {
                sql.Parameters.Add(new SqlParameter("@DataRecebimento", DBNull.Value));
            } else
            {
                sql.Parameters.Add(new SqlParameter("@DataRecebimento", desp.DataRecebimento));
            }

            sql.Parameters.Add(new SqlParameter("@TipoParcelamento", desp.TipoParcelamento));
            sql.Parameters.Add(new SqlParameter("@QtdParcelas", desp.QtdParcelas));
            sql.Parameters.Add(new SqlParameter("@Parcela", desp.Parcela));
            sql.Parameters.Add(new SqlParameter("@Observacoes", desp.Observacoes));
            sql.Parameters.Add(new SqlParameter("@Tipo", tpDespesaDao.GetTipoDespesaId(desp.Tipo)));


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

            string str = @"select d.Id, 
                                  FormaRecebimento, 
                                  Valor, 
                                  DataVencimento, 
                                  DataRecebimento, 
                                  TipoParcelamento, 
                                  QtdParcelas, 
                                  Parcela, 
                                  Observacoes, 
                                  TipoDespesa, 
                                  cd.Categoria 
                                    from Despesas d 
                                        join TipoDespesa t on d.Tipo = t.Id 
                                        join CategoriaDespesa cd on t.Categoria = cd.Id";

            SqlCommand sql = new SqlCommand(str, cn);

            cn.Open();

            SqlDataReader sdr = sql.ExecuteReader();

            while (sdr.Read())
            {
                Despesa despesa = new Despesa();
                despesa.Id = int.Parse(sdr["Id"].ToString());
                despesa.FormaRecebimento = sdr["FormaRecebimento"] as string;
                despesa.Valor = float.Parse(sdr["Valor"].ToString());
                despesa.DataVencimento = (DateTime)sdr["DataVencimento"];

                DateTime datRec;
                DateTime.TryParse(sdr["DataRecebimento"].ToString(), out datRec);

                despesa.DataRecebimento = datRec;

                despesa.TipoParcelamento = sdr["TipoParcelamento"] as string;
                despesa.QtdParcelas = int.Parse(sdr["QtdParcelas"].ToString());
                despesa.Parcela = int.Parse(sdr["Parcela"].ToString());
                despesa.Observacoes = sdr["Observacoes"] as string;
                despesa.Tipo = sdr["TipoDespesa"].ToString() + "/" + sdr["Categoria"].ToString();

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


            string str = @"select d.Id, 
                                  FormaRecebimento, 
                                  Valor, 
                                  DataVencimento, 
                                  DataRecebimento, 
                                  TipoParcelamento, 
                                  QtdParcelas, 
                                  Parcela, 
                                  Observacoes, 
                                  TipoDespesa, 
                                  cd.Categoria 
                                    from Despesas d 
                                        join TipoDespesa t on d.Tipo = t.Id 
                                        join CategoriaDespesa cd on t.Categoria = cd.Id
                                        where DataVencimento >= @DataIni and DataVencimento <= @DataFim and DataRecebimento = @DataNull";
           
            //str = "select * from Despesas where DataVencimento >= @DataIni and DataVencimento <= @DataFim and DataRecebimento = @DataNull";

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

                DateTime datRec;
                DateTime.TryParse(sdr["DataRecebimento"].ToString(), out datRec);

                despesa.DataRecebimento = datRec;

                despesa.TipoParcelamento = sdr["TipoParcelamento"] as string;
                despesa.QtdParcelas = int.Parse(sdr["QtdParcelas"].ToString());
                despesa.Parcela = int.Parse(sdr["Parcela"].ToString());
                despesa.Observacoes = sdr["Observacoes"] as string;
                despesa.Tipo = sdr["TipoDespesa"].ToString() + "/" + sdr["Categoria"].ToString();

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

            string str = @"select d.Id, 
                                  FormaRecebimento, 
                                  Valor, 
                                  DataVencimento, 
                                  DataRecebimento, 
                                  TipoParcelamento, 
                                  QtdParcelas, 
                                  Parcela, 
                                  Observacoes, 
                                  TipoDespesa, 
                                  cd.Categoria 
                                    from Despesas d 
                                        join TipoDespesa t on d.Tipo = t.Id 
                                        join CategoriaDespesa cd on t.Categoria = cd.Id
                                            where DataVencimento >= @DataIni and DataVencimento <= @DataFim";
            //str = "select * from Despesas where DataVencimento >= @DataIni and DataVencimento <= @DataFim";

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

                DateTime datRec;
                DateTime.TryParse(sdr["DataRecebimento"].ToString(), out datRec);

                despesa.DataRecebimento = datRec;

                despesa.TipoParcelamento = sdr["TipoParcelamento"] as string;
                despesa.QtdParcelas = int.Parse(sdr["QtdParcelas"].ToString());
                despesa.Parcela = int.Parse(sdr["Parcela"].ToString());
                despesa.Observacoes = sdr["Observacoes"] as string;
                despesa.Tipo = sdr["TipoDespesa"].ToString() + "/" + sdr["Categoria"].ToString();

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

            string str = @"select d.Id, 
                                  FormaRecebimento, 
                                  Valor, 
                                  DataVencimento, 
                                  DataRecebimento, 
                                  TipoParcelamento, 
                                  QtdParcelas, 
                                  Parcela, 
                                  Observacoes, 
                                  TipoDespesa, 
                                  cd.Categoria 
                                    from Despesas d 
                                        join TipoDespesa t on d.Tipo = t.Id 
                                        join CategoriaDespesa cd on t.Categoria = cd.Id
                                            where DataVencimento <= @DataFim and DataRecebimento = @DataNull";
            
            //str = "select * from Despesas where DataVencimento <= @DataFim and DataRecebimento = @DataNull";

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

                DateTime datRec;
                DateTime.TryParse(sdr["DataRecebimento"].ToString(), out datRec);

                despesa.DataRecebimento = datRec;

                despesa.TipoParcelamento = sdr["TipoParcelamento"] as string;
                despesa.QtdParcelas = int.Parse(sdr["QtdParcelas"].ToString());
                despesa.Parcela = int.Parse(sdr["Parcela"].ToString());
                despesa.Observacoes = sdr["Observacoes"] as string;
                despesa.Tipo = sdr["TipoDespesa"].ToString() + "/" + sdr["Categoria"].ToString();

                listaDespesas.Add(despesa);
            }
            sdr.Close();
            cn.Close();

            return listaDespesas;
        }
    }
}