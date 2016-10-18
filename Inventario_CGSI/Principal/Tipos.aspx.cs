using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inventario_CGSI.AppData.DataSetProcsTableAdapters;

namespace Inventario_CGSI.Principal
{
    public partial class Tipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAgregar_Tipo_Click(object sender, EventArgs e)
        {
            ProcsTableAdapter procesos = new ProcsTableAdapter();

            procesos.agregar_tipo
                (
                    TxtAgregar_Tipo.Text
                );
            if (!Session["PaginaRetorno"].Equals(""))
            {
                Response.Redirect(Session["PaginaRetorno"].ToString());
            }
            else
            {
                GridViewTipo.DataBind();
            }
        }

        protected void ButtonCancelar_Tipo_Click(object sender, EventArgs e)
        {
            if (!Session["PaginaRetorno"].Equals(""))
            {
                Response.Redirect(Session["PaginaRetorno"].ToString());
            }
            else
            {
                TxtAgregar_Tipo.Text = "";
            }
        }

    }
}