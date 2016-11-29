using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SCFacturacion.main
{
    public partial class masterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            version.InnerText = "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            avisoPrivacidad.HRef = ConfigurationManager.AppSettings["AvisoPrivacidad"].ToString();

        }
    }
}