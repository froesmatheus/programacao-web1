using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exercicio12_03_16
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebService webservice = new WebService();
            float temp = webservice.CelsiusParaFahrenheit(20);
            temp = webservice.FahrenheitParaCelsius(80);
        }
    }
}