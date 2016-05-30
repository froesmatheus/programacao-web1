using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using Exercicio12_03_16.Database;

namespace Exercicio12_03_16
{
    public partial class CadastrarCliente : System.Web.UI.Page
    {
        private ClienteDAO dao;
        protected void Page_Load(object sender, EventArgs e)
        {
            dao = new ClienteDAO();
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

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx", true);
        }

        protected void ObjectDataSource1_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            Label label = (Label)ModalPopupExtender1.FindControl("LabelMessage");
            if (int.Parse(e.ReturnValue.ToString()) > 0)
            {
                label.Text = "Cliente adicionado com sucesso";
            }
            else
            {
                label.Text = "Cliente já existe";
            }
            ModalPopupExtender1.Show();
        }
    }
}