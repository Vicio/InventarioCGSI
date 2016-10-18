using System;
using Inventario_CGSI.AppData.DataSetProcsTableAdapters;

namespace Inventario_CGSI
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["Logged"] = false;
            Session["Usuario"] = "";
            Session["Permisos"] = "";
            Session["Area"] = "";
            Session["Activado"] = "";
            Session["ID"] = "";
            Session["Editar"] = false;
            Session["PaginaRetorno"] = "";
            Session["NoSerie"] = "";
            Session["Nombre"] = "";
            Session["Tipo"] = 0;
            Session["IP"] = "0.0.0.0";
            Session["Mac"] = "00:00:00:00:00:00";
            Session["Marca"] = 0;
            Session["Modelo"] = 0;
            Session["Estado"] = 0;
            Session["Medidas"] = 0;
            Session["Campus"] = 0;
            Session["Adscripcion"] = 0;
            Session["Ubicacion"] = 0;
            Session["Descripcion"] = "";
            Session["NumParte"] = "";
            Session["IdCompuesto"] = 0;
            Session["BtnAccion_Articulo"] = "";
            Session["BtnAccion_Parte"] = "";
            Session["Accion"] = "";
            Session["ID_Articulo"] = "";
            Session["ID_Parte"] = "";
            Session["DivActivo"] = "";
            Session["Imagen"] = "";
            Session["Cantidad"] = 0;
            Session["Puertos"] = 0;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            ProcsTableAdapter procesos = new ProcsTableAdapter();
            procesos.validar_salida_usuario((int)Session["ID"]);
            Session["Logged"] = false;
            Session["Usuario"] = "";
            Session["Permisos"] = "";
            Session["Area"] = "";
            Session["Activado"] = "";
            Session["ID"] = "";
            Session["PaginaRetorno"] = "";
            Session["NoSerie"] = "";
            Session["Nombre"] = "";
            Session["Tipo"] = 0;
            Session["IP"] = "0.0.0.0";
            Session["Mac"] = "00:00:00:00:00:00";
            Session["Marca"] = 0;
            Session["Modelo"] = 0;
            Session["Estado"] = 0;
            Session["Medidas"] = 0;
            Session["Campus"] = 0;
            Session["Adscripcion"] = 0;
            Session["Ubicacion"] = 0;
            Session["Descripcion"] = "";
            Session["NumParte"] = "";
            Session["IdCompuesto"] = 0;
            Session["BtnAccion_Articulo"] = "";
            Session["BtnAccion_Parte"] = "";
            Session["Accion"] = "";
            Session["ID_Articulo"] = "";
            Session["ID_Parte"] = "";
            Session["DivActivo"] = "";
            Session["Imagen"] = "";
            Session["Cantidad"] = 0;
            Session["Puertos"] = 0;
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}