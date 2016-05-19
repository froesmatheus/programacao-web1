using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Exercicio12_03_16.Database
{
    [DataObject(true)]
    public class ClienteDAO
    {
        private SqlConnection cn;

        public ClienteDAO()
        {
            cn = new ConnectionFactory().getConnection();
        }


        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Cliente cliente)
        {
            string str = @"INSERT INTO Clientes (Nome, DataNasc, Email, Senha)
                                                            VALUES (@Nome, @DataNasc, @Email, @Senha)";
            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@Nome", cliente.Nome));
            sql.Parameters.Add(new SqlParameter("@DataNasc", cliente.DataNasc));
            sql.Parameters.Add(new SqlParameter("@Email", cliente.Email));
            sql.Parameters.Add(new SqlParameter("@Senha", cliente.Senha));

            cn.Open();
            sql.ExecuteNonQuery();
            cn.Close();
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Cliente cliente)
        {

            string str = "delete from Clientes where Id = @Id";

            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@Id", cliente.Id));

            cn.Open();
            sql.ExecuteNonQuery();
            cn.Close();
        }


        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Cliente cliente)
        {
            string str = @"update Clientes set 
                                    Nome = @Nome,
                                    DataNasc = @DataNasc, 
                                    Email = @Email, 
                                    Senha = @Senha 
                            where Id = @Id";
            SqlCommand sql = new SqlCommand(str, cn);

            sql.Parameters.Add(new SqlParameter("@Nome", cliente.Nome));
            sql.Parameters.Add(new SqlParameter("@DataNasc", cliente.DataNasc));
            sql.Parameters.Add(new SqlParameter("@Email", cliente.Email));
            sql.Parameters.Add(new SqlParameter("@Senha", cliente.Senha));
            sql.Parameters.Add(new SqlParameter("@Id", cliente.Id));

            cn.Open();
            sql.ExecuteNonQuery();
            cn.Close();
        }



        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Cliente> GetClientes()
        {
            List<Cliente> lista = new List<Cliente>();

            string str = "select * from Clientes";

            SqlCommand sql = new SqlCommand(str, cn);

            cn.Open();

            SqlDataReader sdr = sql.ExecuteReader();
            
            while (sdr.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id = int.Parse(sdr["Id"].ToString());
                cliente.Nome = sdr["Nome"].ToString();
                cliente.DataNasc = DateTime.Parse(sdr["DataNasc"].ToString());
                cliente.Email = sdr["Email"].ToString();
                cliente.Senha = sdr["Senha"].ToString();

                lista.Add(cliente);
            }

            cn.Close();
            sdr.Close();

            return lista;
        }
    }
}