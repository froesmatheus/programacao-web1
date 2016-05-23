using Exercicio12_03_16.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Exercicio12_03_16.Database.DAOs
{
    [DataObject(true)]

    public class ReceitaDAO
    {
        private SqlConnection cn;
        private TipoReceitaDAO tpReceitaDao;

        public ReceitaDAO()
        {
            cn = new ConnectionFactory().getConnection();
            tpReceitaDao = new TipoReceitaDAO();
        }


        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Receita receita)
        {

            if (receita.TipoParcelamento == Lancamento.PARCELADO)
            {
                InsertParcelado(receita);
                return;
            }

            string str =
                @"INSERT INTO Receitas 
                        (FormaRecebimento, Valor, DataVencimento, DataRecebimento, TipoParcelamento, QtdParcelas, Parcela, Observacoes, Tipo)
                VALUES  (@FormaRecebimento, @Valor, @DataVencimento, @DataRecebimento, @TipoParcelamento, @QtdParcelas, @Parcela, @Observacoes, @Tipo)";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@FormaRecebimento", receita.FormaRecebimento));
            sql.Parameters.Add(new SqlParameter("@Valor", receita.Valor));
            sql.Parameters.Add(new SqlParameter("@DataVencimento", receita.DataVencimento));
            sql.Parameters.Add(new SqlParameter("@DataRecebimento", receita.DataRecebimento));
            sql.Parameters.Add(new SqlParameter("@TipoParcelamento", receita.TipoParcelamento));
            sql.Parameters.Add(new SqlParameter("@QtdParcelas", receita.QtdParcelas));
            sql.Parameters.Add(new SqlParameter("@Parcela", receita.Parcela));
            sql.Parameters.Add(new SqlParameter("@Observacoes", receita.Observacoes));
            sql.Parameters.Add(new SqlParameter("@Tipo", tpReceitaDao.GetTipoReceitaId(receita.Tipo)));


            cn.Open();
            sql.ExecuteNonQuery();
            cn.Close();
        }

        private void InsertParcelado(Receita receita)
        {
            float valorParcela = receita.Valor / receita.QtdParcelas;
            DateTime DataVencimento = receita.DataVencimento;

            receita.Valor = valorParcela;
            receita.Parcela = 1;
            InsertParcela(receita);
            for (int i = 2; i <= receita.QtdParcelas; i++)
            {
                DataVencimento = DataVencimento.AddMonths(1);
                receita = new Receita(receita.Tipo, receita.FormaRecebimento, valorParcela,
                                      DataVencimento, new DateTime(), receita.TipoParcelamento,
                                      receita.QtdParcelas, receita.Observacoes);
                receita.Parcela = i;
                InsertParcela(receita);
            }

        }

        private void InsertParcela(Receita receita)
        {
            string str =
                @"INSERT INTO Receitas 
                        (FormaRecebimento, Valor, DataVencimento, DataRecebimento, TipoParcelamento, QtdParcelas, Parcela, Observacoes, Tipo)
                VALUES  (@FormaRecebimento, @Valor, @DataVencimento, @DataRecebimento, @TipoParcelamento, @QtdParcelas, @Parcela, @Observacoes, @Tipo)";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@FormaRecebimento", receita.FormaRecebimento));
            sql.Parameters.Add(new SqlParameter("@Valor", receita.Valor));
            sql.Parameters.Add(new SqlParameter("@DataVencimento", receita.DataVencimento));

            if (receita.DataRecebimento.Equals(DateTime.Parse("01/01/0001 00:00:00")))
            {
                sql.Parameters.Add(new SqlParameter("@DataRecebimento", DBNull.Value));
            }
            else
            {
                sql.Parameters.Add(new SqlParameter("@DataRecebimento", receita.DataRecebimento));
            }

            sql.Parameters.Add(new SqlParameter("@TipoParcelamento", receita.TipoParcelamento));
            sql.Parameters.Add(new SqlParameter("@QtdParcelas", receita.QtdParcelas));
            sql.Parameters.Add(new SqlParameter("@Parcela", receita.Parcela));
            sql.Parameters.Add(new SqlParameter("@Observacoes", receita.Observacoes));
            sql.Parameters.Add(new SqlParameter("@Tipo", tpReceitaDao.GetTipoReceitaId(receita.Tipo)));


            cn.Open();
            sql.ExecuteNonQuery();
            cn.Close();
        }


        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Receita receita)
        {
            string str = "delete from Receitas where Id = @Id";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@Id", receita.Id));

            cn.Open();

            sql.ExecuteNonQuery();

            cn.Close();
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Receita receita)
        {
            string str = @"update Receitas set FormaRecebimento = @FormaRecebimento,
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

            sql.Parameters.Add(new SqlParameter("@FormaRecebimento", receita.FormaRecebimento));
            sql.Parameters.Add(new SqlParameter("@Valor", receita.Valor));
            sql.Parameters.Add(new SqlParameter("@DataVencimento", receita.DataVencimento));
            sql.Parameters.Add(new SqlParameter("@DataRecebimento", receita.DataRecebimento));
            sql.Parameters.Add(new SqlParameter("@TipoParcelamento", receita.TipoParcelamento));
            sql.Parameters.Add(new SqlParameter("@QtdParcelas", receita.QtdParcelas));
            sql.Parameters.Add(new SqlParameter("@Parcela", receita.Parcela));
            sql.Parameters.Add(new SqlParameter("@Observacoes", receita.Observacoes));
            sql.Parameters.Add(new SqlParameter("@Tipo", tpReceitaDao.GetTipoReceitaId(receita.Tipo)));
            sql.Parameters.Add(new SqlParameter("@Id", receita.Id));

            cn.Open();
            sql.ExecuteNonQuery();
            cn.Close();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Receita> GetReceitas()
        {
            List<Receita> listaReceitas = new List<Receita>();

            string str = @"select r.Id, 
                                  FormaRecebimento, 
                                  Valor, 
                                  DataVencimento, 
                                  DataRecebimento, 
                                  TipoParcelamento, 
                                  QtdParcelas, 
                                  Parcela, 
                                  Observacoes, 
                                  t.TipoReceita,
                                  t.Categoria
                           from Receitas r 
                           join TipoReceita t on r.Tipo = t.Id";

            SqlCommand sql = new SqlCommand(str, cn);

            cn.Open();

            SqlDataReader sdr = sql.ExecuteReader();

            while (sdr.Read())
            {
                Receita receita = new Receita();
                receita.FormaRecebimento = sdr["FormaRecebimento"].ToString();
                receita.Valor = float.Parse(sdr["Valor"].ToString());
                receita.DataVencimento = DateTime.Parse(sdr["DataVencimento"].ToString());

                DateTime datRec;
                DateTime.TryParse(sdr["DataRecebimento"].ToString(), out datRec);

                receita.DataRecebimento = datRec;

                receita.TipoParcelamento = sdr["TipoParcelamento"] as string;
                receita.QtdParcelas = int.Parse(sdr["QtdParcelas"].ToString());
                receita.Parcela = int.Parse(sdr["Parcela"].ToString());
                receita.Observacoes = sdr["Observacoes"].ToString();
                receita.Tipo = sdr["TipoReceita"].ToString() + "/" + sdr["Categoria"].ToString();
                receita.Id = int.Parse(sdr["Id"].ToString());

                listaReceitas.Add(receita);
            }

            sdr.Close();
            cn.Close();

            return listaReceitas;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Receita> FiltrarReceitasVencProximo(DateTime dataIni, DateTime dataFim)
        {
            List<Receita> listaReceitas = new List<Receita>();

            string str = @"select r.Id, 
                                  FormaRecebimento, 
                                  Valor, 
                                  DataVencimento, 
                                  DataRecebimento, 
                                  TipoParcelamento, 
                                  QtdParcelas, 
                                  Parcela, 
                                  Observacoes, 
                                  t.TipoReceita,
                                  t.Categoria
                           from Receitas r 
                           join TipoReceita t on r.Tipo = t.Id 
                           where DataVencimento >= @DataIni and DataVencimento <= @DataFim and DataRecebimento = @DataNull";
            

            //str = "select * from Receitas where DataVencimento >= @DataIni and DataVencimento <= @DataFim and DataRecebimento = @DataNull";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@DataIni", dataIni));
            sql.Parameters.Add(new SqlParameter("@DataFim", dataFim));
            sql.Parameters.Add(new SqlParameter("@DataNull", "01/01/0001"));

            cn.Open();

            SqlDataReader sdr = sql.ExecuteReader();

            while (sdr.Read())
            {
                Receita receita = new Receita();
                receita.FormaRecebimento = sdr["FormaRecebimento"] as string;
                receita.Valor = float.Parse(sdr["Valor"].ToString());
                receita.DataVencimento = (DateTime)sdr["DataVencimento"];

                DateTime datRec;
                DateTime.TryParse(sdr["DataRecebimento"].ToString(), out datRec);

                receita.DataRecebimento = datRec;

                receita.TipoParcelamento = sdr["TipoParcelamento"] as string;
                receita.QtdParcelas = int.Parse(sdr["QtdParcelas"].ToString());
                receita.Parcela = int.Parse(sdr["Parcela"].ToString());
                receita.Observacoes = sdr["Observacoes"] as string;
                receita.Tipo = sdr["TipoReceita"].ToString() + "/" + sdr["Categoria"].ToString();

                listaReceitas.Add(receita);
            }
            sdr.Close();
            cn.Close();

            return listaReceitas;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Receita> FiltrarReceitas(DateTime dataIni, DateTime dataFim)
        {
            List<Receita> listaReceitas = new List<Receita>();

            string str = @"select r.Id, 
                                  FormaRecebimento, 
                                  Valor, 
                                  DataVencimento, 
                                  DataRecebimento, 
                                  TipoParcelamento, 
                                  QtdParcelas, 
                                  Parcela, 
                                  Observacoes, 
                                  t.TipoReceita,
                                  t.Categoria
                           from Receitas r 
                           join TipoReceita t on r.Tipo = t.Id where DataVencimento >= @DataIni and DataVencimento <= @DataFim";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@DataIni", dataIni));
            sql.Parameters.Add(new SqlParameter("@DataFim", dataFim));

            cn.Open();

            SqlDataReader sdr = sql.ExecuteReader();

            while (sdr.Read())
            {
                Receita receita = new Receita();
                receita.FormaRecebimento = sdr["FormaRecebimento"] as string;
                receita.Valor = float.Parse(sdr["Valor"].ToString());
                receita.DataVencimento = (DateTime)sdr["DataVencimento"];

                DateTime datRec;
                DateTime.TryParse(sdr["DataRecebimento"].ToString(), out datRec);

                receita.DataRecebimento = datRec;

                receita.TipoParcelamento = sdr["TipoParcelamento"] as string;
                receita.QtdParcelas = int.Parse(sdr["QtdParcelas"].ToString());
                receita.Parcela = int.Parse(sdr["Parcela"].ToString());
                receita.Observacoes = sdr["Observacoes"] as string;
                receita.Tipo = sdr["TipoReceita"].ToString() + "/" + sdr["Categoria"].ToString();

                listaReceitas.Add(receita);
            }
            sdr.Close();
            cn.Close();

            return listaReceitas;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Receita> FiltrarReceitasVencidas(DateTime dataIni, DateTime dataFim)
        {
            List<Receita> listaReceitas = new List<Receita>();

            string str = @"select r.Id, 
                                  FormaRecebimento, 
                                  Valor, 
                                  DataVencimento, 
                                  DataRecebimento, 
                                  TipoParcelamento, 
                                  QtdParcelas, 
                                  Parcela, 
                                  Observacoes, 
                                  t.TipoReceita,
                                  t.Categoria
                           from Receitas r 
                           join TipoReceita t on r.Tipo = t.Id where DataVencimento <= @DataFim and DataRecebimento = @DataNull";

            //str = "select * from Receitas where DataVencimento <= @DataFim and DataRecebimento = @DataNull";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@DataFim", dataFim));
            sql.Parameters.Add(new SqlParameter("@DataNull", "01/01/0001"));

            cn.Open();

            SqlDataReader sdr = sql.ExecuteReader();

            while (sdr.Read())
            {
                Receita receita = new Receita();
                receita.FormaRecebimento = sdr["FormaRecebimento"] as string;
                receita.Valor = float.Parse(sdr["Valor"].ToString());
                receita.DataVencimento = (DateTime)sdr["DataVencimento"];

                DateTime datRec;
                DateTime.TryParse(sdr["DataRecebimento"].ToString(), out datRec);

                receita.DataRecebimento = datRec;

                receita.TipoParcelamento = sdr["TipoParcelamento"] as string;
                receita.QtdParcelas = int.Parse(sdr["QtdParcelas"].ToString());
                receita.Parcela = int.Parse(sdr["Parcela"].ToString());
                receita.Observacoes = sdr["Observacoes"] as string;
                receita.Tipo = sdr["TipoReceita"].ToString() + "/" + sdr["Categoria"].ToString();

                listaReceitas.Add(receita);
            }
            sdr.Close();
            cn.Close();

            return listaReceitas;
        }
    }
}