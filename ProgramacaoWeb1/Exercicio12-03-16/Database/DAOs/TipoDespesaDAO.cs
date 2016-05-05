using Exercicio12_03_16.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Exercicio12_03_16.Database.DAOs
{
    public class TipoDespesaDAO
    {
        private SqlConnection cn;

        public TipoDespesaDAO()
        {
            cn = new ConnectionFactory().getConnection();
        }


        public void Insert(TipoDespesa tipoDespesa)
        {
            string str = @"INSERT INTO TipoDespesa (TipoDespesa, Caracteristica, Categoria)
                                                            VALUES (@TipoDespesa, @Caracteristica, @Categoria)";
            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@Categoria", tipoDespesa.tipoDespesa));
            sql.Parameters.Add(new SqlParameter("@Caracteristica", tipoDespesa.caracteristica));
            sql.Parameters.Add(new SqlParameter("@Categoria", tipoDespesa.categoria));

            cn.Open();
            sql.ExecuteNonQuery();
            cn.Close();
        }
    }
}