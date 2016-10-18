using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inventario_CGSI.Principal;
using Inventario_CGSI.AppData.DataSetProcsTableAdapters;
namespace Inventario_CGSI.Principal
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public int anchoCuerpo
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (bool.Parse(Session["Logged"].ToString()) == true)
            {
                LabelSesion.Text = "Bienvenido " + (string)Session["Usuario"];
            }
            else
            {
                Response.Redirect("~/Login/Inicio.aspx");
            }
            if (Session["Permisos"].Equals("A"))
            {
                EtiquetaCuentas.Visible = true;
            }
            else if (Session["Permisos"].Equals("C"))
            {
                EtiquetaCuentas.Visible = true;
            }
            else if (Session["Permisos"].Equals("E"))
            {
                EtiquetaCuentas.Visible = false;
            }
            else
            {

            }

            if (Session["Area"].Equals("T"))
            {
                AP.Visible = true;
                Redes.Visible = true;
                SR.Visible = true;
                VC.Visible = true;
                CentroComputo.Visible = true;
            }
            else if (Session["Area"].Equals("R"))
            {
                AP.Visible = false;
                Redes.Visible = true;
                SR.Visible = false;
                VC.Visible = false;
                CentroComputo.Visible = false;

            }
            else if (Session["Area"].Equals("S"))
            {
                AP.Visible = false;
                Redes.Visible = false;
                SR.Visible = true;
                VC.Visible = false;
                CentroComputo.Visible = false;
            }
            else if (Session["Area"].Equals("A"))
            {
                AP.Visible = true;
                Redes.Visible = false;
                SR.Visible = false;
                VC.Visible = false;
                CentroComputo.Visible = false;
            }
            else if (Session["Area"].Equals("C"))
            {
                AP.Visible = false;
                Redes.Visible = false;
                SR.Visible = false;
                VC.Visible = false;
                CentroComputo.Visible = true;
            }
            else if (Session["Area"].Equals("V"))
            {
                AP.Visible = false;
                Redes.Visible = false;
                SR.Visible = false;
                VC.Visible = true;
                CentroComputo.Visible = false;
            }
            
        }
        protected void Limpiar_Gobal()
        {
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
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
        }
        /***************************************REDES************************************************************************/
        protected void Redes_Click(object sender, EventArgs e)
        {
            Limpiar_Gobal();
            EtiquetaTitulo.Text = "Redes";
            Response.Redirect("Redes.aspx");
        }
       
        /************************************CENTRO DE COMPUTO*******************************************************************/
        protected void Centro_Computo_Click(object sender, EventArgs e)
        {
            Limpiar_Gobal();
            Response.Redirect("CentroDeComputo.aspx");
            EtiquetaTitulo.Text = "Centro de Computo";
        }
       
        /***********************************SWITCHES & ROUTERS****************************************************************************/
        protected void SR_Click(object sender, EventArgs e)
        {
            Limpiar_Gobal();
            EtiquetaTitulo.Text = "Switches & Routers";
            Response.Redirect("Switch_Router.aspx");
        }
       
        /*****************************************ACCESS POINT****************************************************************************/
        protected void AP_Click(object sender, EventArgs e)
        {
            Limpiar_Gobal();
            EtiquetaTitulo.Text = "Access Point";
            Response.Redirect("AP.aspx");
        }
        /***********************************VIDEOCONFERENCIA****************************************************************************/

        protected void VC_Click(object sender, EventArgs e)
        {
            Limpiar_Gobal();
            EtiquetaTitulo.Text = "Videoconferencia";
            Response.Redirect("Videoconferencia.aspx");
        }

        /***********************************CONTROL DE CUENTAS****************************************************************************/
        protected void Cuentas_Click(object sender, EventArgs e)
        {
            EtiquetaTitulo.Text = "Control de Cuentas";
            Response.Redirect("Cuentas.aspx");
        }
       
        /***********************************CERRAR SESION****************************************************************************/
        protected void cerrar_session_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Session["ID"].ToString());
            ProcsTableAdapter procedimientos = new ProcsTableAdapter();
            procedimientos.validar_salida_usuario(id);
            Session["Logged"] = false;
            Session["Usuario"] = "";
            Session["Permisos"] = "";
            Session["Area"] = "";
            Session["ID"] = "";
            Response.Redirect("~/Login/Inicio.aspx");
        }
    }
}