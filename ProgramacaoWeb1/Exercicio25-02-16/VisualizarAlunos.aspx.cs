using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exercicio25_02_16
{
    public partial class VisualizarAluno : System.Web.UI.Page
    {
        private List<Aluno> listaAlunos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["listaAlunos"] != null)
            {
                Preencher_Lista();
            }
        }

        private void Preencher_Lista()
        {
            listaAlunos = (List<Aluno>)Session["listaAlunos"];

            if (lbxAlunos.Items.Count == 0)
            {
                grdView.DataSource = listaAlunos;
                grdView.DataBind();
                //for (int i = 0; i < listaAlunos.Count; i++)
                //{
                //    lbxAlunos.Items.Add(new ListItem(listaAlunos[i].ToString()));
                //}
            }

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (lbxAlunos.SelectedIndex != -1)
            {
                Response.Redirect("CadastrarAluno.aspx?matricula=" + Obter_Matricula());
            }
        }

        private int Obter_Matricula()
        {
            String strSelected = listaAlunos[lbxAlunos.SelectedIndex].ToString();

            strSelected = strSelected.Split('-')[0];

            return Convert.ToInt16(strSelected);
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            int index = lbxAlunos.SelectedIndex;

            if (index != -1)
            {
                lbxAlunos.Items.RemoveAt(index);
                listaAlunos.RemoveAt(index);

                if (listaAlunos.Count == 0)
                {
                    btnEditar.Enabled = false;
                    btnExcluir.Enabled = false;
                }
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastrarAluno.aspx", true);
        }

        protected void btnEditar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("CadastrarAluno.aspx?matricula=" + ((Button)sender).CommandArgument);
        }
    }
}