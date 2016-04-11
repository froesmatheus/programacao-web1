using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Exercicio12_03_16
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public float CelsiusParaFahrenheit(float temperatura)
        {
            return ((temperatura * 9) / 5) + 32;
        }

        [WebMethod]
        public float FahrenheitParaCelsius(float temperatura)
        {
            return ((temperatura - 32) * 5) / 9;
        }
    }
}
