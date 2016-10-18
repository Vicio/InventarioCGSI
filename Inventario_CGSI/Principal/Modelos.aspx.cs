using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inventario_CGSI.AppData.DataSetProcsTableAdapters;

namespace Inventario_CGSI.Principal
{
    public partial class Modelos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAgregar_Modelo_Click(object sender, EventArgs e)
        {
            ProcsTableAdapter procesos = new ProcsTableAdapter();

            procesos.agregar_modelo
                (
                    TxtAgregar_Modelo.Text
                );
            if (!Session["PaginaRetorno"].Equals(""))
            {
                Response.Redirect(Session["PaginaRetorno"].ToString());
            }
            else
            {
                GridViewModelo.DataBind();
            }
        }

        protected void ButtonCancelar_Modelo_Click(object sender, EventArgs e)
        {
            if (!Session["PaginaRetorno"].Equals(""))
            {
                Response.Redirect(Session["PaginaRetorno"].ToString());
            }
            else
            {
                TxtAgregar_Modelo.Text = "";
            }
        }
    }
}