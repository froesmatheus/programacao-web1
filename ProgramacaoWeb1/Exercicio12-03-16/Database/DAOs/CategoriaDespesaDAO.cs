using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Exercicio12_03_16.Database.DAOs
{
    [DataObject(true)]
    public class CategoriaDespesaDAO
    {
        private SqlConnection cn;

        public CategoriaDespesaDAO()
        {
            cn = new ConnectionFactory().getConnection();
        }


        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert(CategoriaDespesa categoriaDespesa)
        {
            if (Get(categoriaDespesa.categoria) != null)
            {
                return -1;
            } 

            string str = @"INSERT INTO CategoriaDespesa (Categoria, Status)
                                                            VALUES (@Categoria, @Status)";
            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@Categoria", categoriaDespesa.categoria));
            sql.Parameters.Add(new SqlParameter("@Status", categoriaDespesa.status));

            cn.Open();
            int rows =sql.ExecuteNonQuery();
            cn.Close();

            return rows;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public CategoriaDespesa Get(string categoria)
        {
            string str = "select * from CategoriaDespesa where lower(Categoria) = lower(@Categoria)";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@Categoria", categoria.Trim()));

            cn.Open();
            SqlDataReader sdr = sql.ExecuteReader();

            CategoriaDespesa categoriaDespesa = null;
            if (sdr.Read())
            {
                categoriaDespesa = new CategoriaDespesa();
                categoriaDespesa.id = int.Parse(sdr["Id"].ToString());
                categoriaDespesa.categoria = sdr["Categoria"].ToString();

                int status = int.Parse(sdr["Status"].ToString());

                if (status == 0)
                {
                    categoriaDespesa.status = CategoriaDespesa.Status.ATIVO;
                } else
                {
                    categoriaDespesa.status = CategoriaDespesa.Status.DESATIVADO;
                }
            }

            sdr.Close();
            cn.Close();

            return categoriaDespesa;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(CategoriaDespesa categoriaDespesa)
        {
            string str = "update CategoriaDespesa set Categoria = @Categoria, Status = @Status where Id = @Id";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@Categoria", categoriaDespesa.categoria));
            sql.Parameters.Add(new SqlParameter("@Status", categoriaDespesa.status));
            sql.Parameters.Add(new SqlParameter(@"Id", categoriaDespesa.id));

            cn.Open();
            sql.ExecuteNonQuery();
            cn.Close();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<CategoriaDespesa> GetCategorias(string query)
        {
            List<CategoriaDespesa> listaCategorias = new List<CategoriaDespesa>();

            string str = "select * from CategoriaDespesa where Categoria like '%'+@Query+'%' or @Query is null";

            SqlCommand sql = new SqlCommand(str, cn);

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
                CategoriaDespesa categoriaDespesa = new CategoriaDespesa();
                categoriaDespesa.id = int.Parse(sdr["Id"].ToString());
                categoriaDespesa.categoria = sdr["Categoria"].ToString();
               
                if (int.Parse(sdr["Status"].ToString()) == 0)
                {
                    categoriaDespesa.status = CategoriaDespesa.Status.ATIVO;
                } else
                {
                    categoriaDespesa.status = CategoriaDespesa.Status.DESATIVADO;
                }

                listaCategorias.Add(categoriaDespesa);
            }
            sdr.Close();
            cn.Close();

            return listaCategorias;
        }
    }
}