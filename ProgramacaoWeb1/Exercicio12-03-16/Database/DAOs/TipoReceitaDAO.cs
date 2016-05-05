using Exercicio12_03_16.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Exercicio12_03_16.Database.DAOs
{
    public class TipoReceitaDAO
    {
        private SqlConnection cn;

        public TipoReceitaDAO()
        {
            cn = new ConnectionFactory().getConnection();
        }



        public void Insert(TipoReceita tipoReceita)
        {
            string str = @"INSERT INTO TipoReceita (Receita, Tipo, Status)
                                                            VALUES (@Receita, @Tipo, @Status)";
            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@Receita", tipoReceita.receita));
            sql.Parameters.Add(new SqlParameter("@Tipo", tipoReceita.tipoReceita));
            sql.Parameters.Add(new SqlParameter("@Status", tipoReceita.status));

            cn.Open();
            sql.ExecuteNonQuery();
            cn.Close();
        }
    }
}