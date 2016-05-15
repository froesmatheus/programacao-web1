using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Exercicio12_03_16.Database
{
    public class ConnectionFactory
    {
        private static SqlConnection sqlConnection;

        public SqlConnection getConnection()
        {
            if (sqlConnection == null)
            {
                ConnectionStringSettingsCollection strConnection = ConfigurationManager.ConnectionStrings;
                sqlConnection = new SqlConnection(strConnection["ConnectionString2"].ConnectionString);
            }

            return sqlConnection;
        }
    }
}