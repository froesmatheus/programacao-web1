using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exercicio25_02_16
{
    public partial class CadastrarAluno : System.Web.UI.Page
    {
        private List<Aluno> listaAlunos;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["listaAlunos"] == null)
            {
                listaAlunos = new List<Aluno>();
                Session["listaAlunos"] = listaAlunos;
            }
            else
            {
                listaAlunos = (List<Aluno>)Session["listaAlunos"];
            }

            int matricula = Get_Matricula_Query_String();

            if (matricula != -1)
            {
                Preencher_Campos(matricula);
            }
            else
            {
                lblMatriculaNaoEncontrada.Visible = false;
            }
        }

        private void Preencher_Campos(int matricula)
        {
            foreach (var aluno in listaAlunos)
            {
                if (aluno.matricula == matricula)
                {

                    listaAlunos.Remove(aluno);
                    tbxNome.Text = aluno.nome;
                    tbxMatricula.Text = aluno.matricula + "";
                    tbxCreditos.Text = aluno.qtdCreditos + "";
                    tbxPercFaltas.Text = aluno.percFaltas + "";
                    tbxNota1.Text = aluno.nota1 + "";
                    tbxNota2.Text = aluno.nota2 + "";

                    lblMatriculaNaoEncontrada.Visible = false;
                    divCadastrarAluno.Visible = true;

                    btnSalvar.Text = "Atualizar";
                    return;
                }
            }

            lblMatriculaNaoEncontrada.Visible = true;
            divCadastrarAluno.Visible = false;
        }

        private int Get_Matricula_Query_String()
        {
            string matriculaStr = Request.QueryString["matricula"];
            int matricula = -1;

            try
            {
                matricula = int.Parse(matriculaStr);
            }
            catch (Exception) { }

            return matricula;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            int matricula = int.Parse(tbxMatricula.Text);
            string nome = tbxNome.Text;
            float nota1 = float.Parse(tbxNota1.Text);
            float nota2 = float.Parse(tbxNota2.Text);
            int percFaltas = int.Parse(tbxPercFaltas.Text);
            int qtdCreditos = int.Parse(tbxCreditos.Text);

            Aluno aluno = new Aluno(matricula, nome, nota1, nota2, percFaltas, qtdCreditos);
            listaAlunos.Add(aluno);

            Response.Redirect("VisualizarAlunos.aspx");
        }


        protected void tbxMatricula_TextChanged(object sender, EventArgs e)
        {
            TextBox tbx = (TextBox)sender;

            int matricula = -1;
            try
            {
                matricula = int.Parse(tbx.Text);
            }
            catch (Exception)
            {
                tbx.Text = "";
            }

            foreach (var aluno in listaAlunos)
            {
                if (aluno.matricula == matricula)
                {
                    lblMatriculaExistente.Visible = true;
                    btnSalvar.Enabled = false;
                    return;
                }
            }

            lblMatriculaExistente.Visible = false;
            btnSalvar.Enabled = true;

            tbxNome.Focus();
        }

        protected void btnVisualizarAlunos_Click(object sender, EventArgs e)
        {
            Response.Redirect("VisualizarAlunos.aspx");
        }
    }
}