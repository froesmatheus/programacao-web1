using Exercicio12_03_16.Database.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Exercicio12_03_16
{
    /// <summary>
    /// Summary description for Servico
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Servico : System.Web.Services.WebService
    {
        private CategoriaDespesaDAO dao = new CategoriaDespesaDAO();
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public string[] GetCompletionList(string prefixText, int count)
        {
            List<CategoriaDespesa> categorias = dao.GetCategorias(prefixText);

            string[] array = new string[categorias.Count];

            int i = 0;
            foreach (CategoriaDespesa cat in categorias)
            {
                array[i] = cat.categoria;
                i++;
            }

            return array;
        }
    }
}
