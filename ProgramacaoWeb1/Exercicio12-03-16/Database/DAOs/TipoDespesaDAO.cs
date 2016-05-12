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
    public class TipoDespesaDAO
    {
        private SqlConnection cn;

        public TipoDespesaDAO()
        {
            cn = new ConnectionFactory().getConnection();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(TipoDespesa tipoDespesa)
        {
            string str = @"INSERT INTO TipoDespesa (TipoDespesa, Caracteristica, Categoria)
                                                            VALUES (@TipoDespesa, @Caracteristica, @Categoria)";
            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@TipoDespesa", tipoDespesa.tipoDespesa));
            sql.Parameters.Add(new SqlParameter("@Caracteristica", tipoDespesa.caracteristica));
            sql.Parameters.Add(new SqlParameter("@Categoria", tipoDespesa.categoria.id));

            cn.Open();
            sql.ExecuteNonQuery();
            cn.Close();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<TipoDespesa> GetTiposDespesa(string categoria, string query)
        {
            List<TipoDespesa> listaTipos = new List<TipoDespesa>();

            string str = @"select t.Id, c.Categoria, TipoDespesa, t.Status, t.Caracteristica 
                            from TipoDespesa t join CategoriaDespesa c on t.Categoria = c.Id
                            where ((@Categoria is null and @Query is null)
                                or (c.Categoria = @Categoria and TipoDespesa like '%'+@Query+'%'))
                                or c.Categoria = @Categoria";

           
            SqlCommand sql = new SqlCommand(str, cn);

            if (String.IsNullOrEmpty(categoria) || categoria.Equals("null") && query == null)
                sql.Parameters.Add(new SqlParameter("@Categoria", DBNull.Value));
            else
                sql.Parameters.Add(new SqlParameter("@Categoria", categoria));


            if (String.IsNullOrEmpty(query))
            {
                sql.Parameters.Add(new SqlParameter("@Query", DBNull.Value));
            } else
            {
                sql.Parameters.Add(new SqlParameter("@Query", query));
            }

            cn.Open();

            SqlDataReader sdr = sql.ExecuteReader();

            while (sdr.Read())
            {
                TipoDespesa tipoDespesa = new TipoDespesa();
                tipoDespesa.id = int.Parse(sdr["Id"].ToString());
                tipoDespesa.categoria = new CategoriaDespesa(sdr["Categoria"].ToString());
                tipoDespesa.caracteristica = sdr["Caracteristica"].ToString();
                tipoDespesa.tipoDespesa = sdr["TipoDespesa"].ToString();

                if (int.Parse(sdr["Status"].ToString()) == 0)
                {
                    tipoDespesa.status = CategoriaDespesa.Status.ATIVO;
                }
                else
                {
                    tipoDespesa.status = CategoriaDespesa.Status.DESATIVADO;
                }

                listaTipos.Add(tipoDespesa);
            }
            sdr.Close();
            cn.Close();

            return listaTipos;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<TipoDespesa> GetTiposDespesa()
        {
            List<TipoDespesa> listaTipos = new List<TipoDespesa>();

            string str = @"select t.Id, c.Categoria, TipoDespesa, t.Status, t.Caracteristica 
                            from TipoDespesa t join CategoriaDespesa c on t.Categoria = c.Id";


            SqlCommand sql = new SqlCommand(str, cn);


            cn.Open();

            SqlDataReader sdr = sql.ExecuteReader();

            while (sdr.Read())
            {
                TipoDespesa tipoDespesa = new TipoDespesa();
                tipoDespesa.id = int.Parse(sdr["Id"].ToString());
                tipoDespesa.categoria = new CategoriaDespesa(sdr["Categoria"].ToString());
                tipoDespesa.caracteristica = sdr["Caracteristica"].ToString();
                tipoDespesa.tipoDespesa = sdr["TipoDespesa"].ToString();

                if (int.Parse(sdr["Status"].ToString()) == 0)
                {
                    tipoDespesa.status = CategoriaDespesa.Status.ATIVO;
                }
                else
                {
                    tipoDespesa.status = CategoriaDespesa.Status.DESATIVADO;
                }

                listaTipos.Add(tipoDespesa);
            }
            sdr.Close();
            cn.Close();

            return listaTipos;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public TipoDespesa GetTipoDespesa(string categoria, string tpDespesa)
        {
            TipoDespesa tipoDespesa = null;

            string str = @"select t.Id, TipoDespesa, Caracteristica, c.Categoria, t.Status, c.Id 'Id_Categoria'
                            from TipoDespesa t join CategoriaDespesa c on t.Categoria = c.Id
                            where c.Categoria = @Categoria and TipoDespesa = @TipoDespesa";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@Categoria", categoria));
            sql.Parameters.Add(new SqlParameter("@TipoDespesa", tpDespesa));

            cn.Open();
            SqlDataReader sdr = sql.ExecuteReader();

            if (sdr.Read())
            {
                tipoDespesa = new TipoDespesa();

                tipoDespesa.id = int.Parse(sdr["Id"].ToString());
                tipoDespesa.tipoDespesa = sdr["TipoDespesa"].ToString();
                tipoDespesa.caracteristica = sdr["Caracteristica"].ToString();
                CategoriaDespesa categoriaDesp = new CategoriaDespesa(sdr["Categoria"].ToString());
                categoriaDesp.id = int.Parse(sdr["Id_Categoria"].ToString());
                tipoDespesa.categoria = categoriaDesp;
               
                if (int.Parse(sdr["Status"].ToString()) == 0)
                {
                    tipoDespesa.status = CategoriaDespesa.Status.ATIVO;
                } else
                {
                    tipoDespesa.status = CategoriaDespesa.Status.DESATIVADO;
                }
            }
            cn.Close();
            sdr.Close();

            return tipoDespesa;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public TipoDespesa GetTipoDespesa(string tpDespesa)
        {
            TipoDespesa tipoDespesa = null;

            string str = @"select t.Id, TipoDespesa, Caracteristica, c.Categoria, t.Status, c.Id 'Id_Categoria'
                            from TipoDespesa t join CategoriaDespesa c on t.Categoria = c.Id
                            where TipoDespesa = @TipoDespesa";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@TipoDespesa", tpDespesa));

            cn.Open();
            SqlDataReader sdr = sql.ExecuteReader();

            if (sdr.Read())
            {
                tipoDespesa = new TipoDespesa();

                tipoDespesa.id = int.Parse(sdr["Id"].ToString());
                tipoDespesa.tipoDespesa = sdr["TipoDespesa"].ToString();
                tipoDespesa.caracteristica = sdr["Caracteristica"].ToString();
                CategoriaDespesa categoriaDesp = new CategoriaDespesa(sdr["Categoria"].ToString());
                categoriaDesp.id = int.Parse(sdr["Id_Categoria"].ToString());
                tipoDespesa.categoria = categoriaDesp;

                if (int.Parse(sdr["Status"].ToString()) == 0)
                {
                    tipoDespesa.status = CategoriaDespesa.Status.ATIVO;
                }
                else
                {
                    tipoDespesa.status = CategoriaDespesa.Status.DESATIVADO;
                }
            }
            cn.Close();
            sdr.Close();

            return tipoDespesa;
        }


        public List<TipoDespesa> FiltrarTipos(string selectedValue, string query)
        {
            List<TipoDespesa> lista = new List<TipoDespesa>();

            string str = @"select t.Id, t.TipoDespesa, t.Caracteristica, t.Status, c.Categoria 
                            from TipoDespesa t join CategoriaDespesa c on t.Categoria = c.Id 
                            where TipoDespesa like '%@Query%' and c.Categoria = @Categoria";

            SqlCommand sql = new SqlCommand(str, cn);
            sql.Parameters.Add(new SqlParameter("@Query", query));
            sql.Parameters.Add(new SqlParameter("@Categoria", selectedValue));

            cn.Open();

            SqlDataReader sdr = sql.ExecuteReader();

            while (sdr.Read())
            {
                TipoDespesa tipoDespesa = new TipoDespesa();
                tipoDespesa.id = int.Parse(sdr["Id"].ToString());
                tipoDespesa.tipoDespesa = sdr["TipoDespesa"].ToString();
                tipoDespesa.caracteristica = sdr["Caracteristica"].ToString();
                tipoDespesa.categoria = new CategoriaDespesa(sdr["Categoria"].ToString());

                if (int.Parse(sdr["Status"].ToString()) == 0)
                {
                    tipoDespesa.status = CategoriaDespesa.Status.ATIVO;
                } else
                {
                    tipoDespesa.status = CategoriaDespesa.Status.DESATIVADO;
                }

                lista.Add(tipoDespesa);
            }
            cn.Close();
            sdr.Close();

            return lista;
        }


        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(TipoDespesa tipoDespesa)
        {
            string str = @"update TipoDespesa 
                                set TipoDespesa = @TipoDespesa, 
                                    Caracteristica = @Caracteristica, 
                                    Categoria = @Categoria,
                                    Status = @Status 
                                where Id = @Id";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@TipoDespesa", tipoDespesa.tipoDespesa));
            sql.Parameters.Add(new SqlParameter("@Caracteristica", tipoDespesa.caracteristica));
            sql.Parameters.Add(new SqlParameter("@Categoria", tipoDespesa.categoria.id));
            sql.Parameters.Add(new SqlParameter("@Status", (tipoDespesa.status == CategoriaDespesa.Status.ATIVO) ? 0 : 1));
            sql.Parameters.Add(new SqlParameter("@Id", tipoDespesa.id));

            cn.Open();
            sql.ExecuteNonQuery();
            cn.Close();
        }
    }
}