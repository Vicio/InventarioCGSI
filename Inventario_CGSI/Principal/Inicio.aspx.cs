using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inventario_CGSI.Principal
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Etiqueta_Bienvenido.Text = "Bienvenido " + Session["Usuario"].ToString() +"!";
        }
    }
}