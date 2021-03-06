﻿using Inventario_CGSI.AppData.DataSetProcsTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inventario_CGSI.Principal
{
    public partial class Estados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAgregar_Estado_Click(object sender, EventArgs e)
        {
            ProcsTableAdapter procesos = new ProcsTableAdapter();

            procesos.agregar_estatus
                (
                    TxtAgregar_Estado.Text
                );
            if (!Session["PaginaRetorno"].Equals(""))
            {
                Response.Redirect(Session["PaginaRetorno"].ToString());
            }
            else
            {
                GridViewEstado.DataBind();
            }

        }

        protected void ButtonCancelar_Estado_Click(object sender, EventArgs e)
        {
            if (!Session["PaginaRetorno"].Equals(""))
            {
                Response.Redirect(Session["PaginaRetorno"].ToString());
            }
            else
            {
                TxtAgregar_Estado.Text = "";
            }

        }
    }
}