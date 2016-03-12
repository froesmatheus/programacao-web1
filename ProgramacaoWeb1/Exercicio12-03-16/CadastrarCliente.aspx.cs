using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace Exercicio12_03_16
{
    public partial class CadastrarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        



        private string GetMD5Hash(string senha)
        {
            MD5 md5 = MD5.Create();

            byte[] input = Encoding.ASCII.GetBytes(senha);

            byte[] hash = md5.ComputeHash(input);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("X2"));
            }

            return builder.ToString();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = tbxNome.Text;
            DateTime dataNasc = DateTime.Parse(tbxDataNasc.Text);
            string email = tbxEmail.Text;
            string senha = GetMD5Hash(tbxSenha.Text);

            Cliente cliente = new Cliente(nome, dataNasc, email, senha);
        }
    }
}