using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Exercicio12_03_16.Database
{
    public class ClienteDAO
    {
        private SqlConnection cn;

        public ClienteDAO()
        {
            cn = new ConnectionFactory().getConnection();
        }



        public void Insert(Cliente cliente)
        {
            string str = @"INSERT INTO Clientes (Nome, DataNasc, Email, Senha)
                                                            VALUES (@Nome, @DataNasc, @Email, @Senha)";
            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@Nome", cliente.nome));
            sql.Parameters.Add(new SqlParameter("@DataNasc", cliente.dataNasc));
            sql.Parameters.Add(new SqlParameter("@Email", cliente.email));
            sql.Parameters.Add(new SqlParameter("@Senha", cliente.senha));

            cn.Open();
            sql.ExecuteNonQuery();
            cn.Close();
        }
    }
}