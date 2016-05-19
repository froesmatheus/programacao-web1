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
    public class TipoReceitaDAO
    {
        private SqlConnection cn;

        public TipoReceitaDAO()
        {
            cn = new ConnectionFactory().getConnection();
        }


        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(TipoReceita tipoReceita)
        {
            string str = @"INSERT INTO TipoReceita (TipoReceita, Categoria, Status)
                                                            VALUES (@TipoReceita, @Categoria, @Status)";
            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@TipoReceita", tipoReceita.tipoReceita));
            sql.Parameters.Add(new SqlParameter("@Categoria", tipoReceita.categoria));
            sql.Parameters.Add(new SqlParameter("@Status", tipoReceita.status));

            cn.Open();
            sql.ExecuteNonQuery();
            cn.Close();
        }

        public TipoReceita GetTipoReceita(string tpReceita)
        {
            string str = @"select Id, TipoReceita, Categoria, Status from TipoReceita where lower(TipoReceita) = lower(@TipoReceita)";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@TipoReceita", tpReceita));

            cn.Open();

            SqlDataReader sdr = sql.ExecuteReader();

            TipoReceita tipoReceita = null;
            if (sdr.Read())
            {
                tipoReceita = new TipoReceita();
                tipoReceita.id = int.Parse(sdr["Id"].ToString());
                tipoReceita.tipoReceita = sdr["TipoReceita"].ToString();
                tipoReceita.categoria = sdr["Categoria"].ToString();

                if (int.Parse(sdr["Status"].ToString()) == 0)
                {
                    tipoReceita.status = CategoriaDespesa.Status.ATIVO;
                }
                else
                {
                    tipoReceita.status = CategoriaDespesa.Status.DESATIVADO;
                }

            }
            sdr.Close();
            cn.Close();

            return tipoReceita;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(TipoReceita tipoReceita)
        {
            string str = @"update TipoReceita 
                                set TipoReceita = @TipoReceita, 
                                    Categoria = @Categoria,
                                    Status = @Status 
                                where Id = @Id";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@TipoReceita", tipoReceita.tipoReceita));
            sql.Parameters.Add(new SqlParameter("@Categoria", tipoReceita.categoria));
            sql.Parameters.Add(new SqlParameter("@Status", (tipoReceita.status == CategoriaDespesa.Status.ATIVO) ? 0 : 1));
            sql.Parameters.Add(new SqlParameter("@Id", tipoReceita.id));

            cn.Open();
            sql.ExecuteNonQuery();
            cn.Close();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<TipoReceita> GetTiposReceita(string categoriaReceita, string query)
        {
            List<TipoReceita> listaTipos = new List<TipoReceita>();

            string str = @"select Id, TipoReceita, Categoria, Status from TipoReceita 
                            where ((@Categoria is null and @Query is null)
                                or (Categoria = @Categoria and TipoReceita like '%'+@Query+'%'))
                                or Categoria = @Categoria";


            SqlCommand sql = new SqlCommand(str, cn);

            if (String.IsNullOrEmpty(categoriaReceita) || categoriaReceita.Equals("null") && query == null)
                sql.Parameters.Add(new SqlParameter("@Categoria", DBNull.Value));
            else
                sql.Parameters.Add(new SqlParameter("@Categoria", categoriaReceita));


            if (String.IsNullOrEmpty(query))
            {
                sql.Parameters.Add(new SqlParameter("@Query", DBNull.Value));
            }
            else
            {
                sql.Parameters.Add(new SqlParameter("@Query", query));
            }


            cn.Open();

            SqlDataReader sdr = sql.ExecuteReader();

            while (sdr.Read())
            {
                TipoReceita tipoReceita = new TipoReceita();
                tipoReceita.id = int.Parse(sdr["Id"].ToString());
                tipoReceita.tipoReceita = sdr["TipoReceita"].ToString();
                tipoReceita.categoria = sdr["Categoria"].ToString();

                if (int.Parse(sdr["Status"].ToString()) == 0)
                {
                    tipoReceita.status = CategoriaDespesa.Status.ATIVO;
                }
                else
                {
                    tipoReceita.status = CategoriaDespesa.Status.DESATIVADO;
                }

                listaTipos.Add(tipoReceita);
            }
            sdr.Close();
            cn.Close();

            return listaTipos;
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public TipoReceita GetTipoReceita(string tpReceita, string categoria)
        {
            string str = @"select Id, TipoReceita, Categoria, Status from TipoReceita where lower(TipoReceita) = @TipoReceita and Categoria = @Categoria";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@TipoReceita", tpReceita));
            sql.Parameters.Add(new SqlParameter("@Categoria", categoria));

            cn.Open();

            SqlDataReader sdr = sql.ExecuteReader();

            TipoReceita tipoReceita = null;
            if (sdr.Read())
            {
                tipoReceita = new TipoReceita();
                tipoReceita.id = int.Parse(sdr["Id"].ToString());
                tipoReceita.tipoReceita = sdr["TipoReceita"].ToString();
                tipoReceita.categoria = sdr["Categoria"].ToString();

                if (int.Parse(sdr["Status"].ToString()) == 0)
                {
                    tipoReceita.status = CategoriaDespesa.Status.ATIVO;
                }
                else
                {
                    tipoReceita.status = CategoriaDespesa.Status.DESATIVADO;
                }

            }
            sdr.Close();
            cn.Close();

            return tipoReceita;
        }


        public int GetTipoReceitaId(string tpReceita)
        {
            string str = @"select Id from TipoReceita
                            where lower(TipoReceita) = lower(@TipoReceita)";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@TipoReceita", tpReceita));

            cn.Open();

            SqlDataReader sdr = sql.ExecuteReader();

            int id = -1;
            if (sdr.Read())
            {
                id = int.Parse(sdr["Id"].ToString());
            }
            sdr.Close();
            cn.Close();

            return id;
        }


    }
}