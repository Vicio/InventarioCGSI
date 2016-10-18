using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inventario_CGSI.AppData.DataSetFuncsTableAdapters;
using Inventario_CGSI.AppData.DataSetProcsTableAdapters;
using Inventario_CGSI.AppData;

namespace Inventario_CGSI.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            SQLInjects inject = new SQLInjects();
            FuncsTableAdapter funciones = new FuncsTableAdapter();
            obtener_datos_validacion_usuarioTableAdapter datos_sesion = new obtener_datos_validacion_usuarioTableAdapter();
            ProcsTableAdapter procedimientos = new ProcsTableAdapter();
            string nombre = "";
            string nivel = "";
            string area = "";
            bool acceso;
            string hash = "";            
            bool activado;
            bool existe;
            int id;
            try
            {
                string correo = inject.Remover(TextBoxUsuario.Text);
                existe = (bool)funciones.verificar_correo_registrado(correo);
                if (existe == false) 
                {
                    error.Text = "Correo o password incorrectos";
                    TextBoxUsuario.Text = "";
                }
                else
                {
                    hash = funciones.obtener_hash_usuario(correo);
                    if (PasswordHash.ValidatePassword(TextBoxPassword.Text, hash))
                    {
                        activado = datos_sesion.GetData(hash)[0].activacion_usuario;
                        if (funciones.comprobar_multiple_acceso(correo, hash) == 1)
                            acceso = true;
                        else
                            acceso = false;
                        id = datos_sesion.GetData(hash)[0].id_usuario;
                        if (acceso)
                        {
                            TextBoxUsuario.Text = "";
                            TextBoxPassword.Text = "";
                            Session["Logged"] = false;
                            Session["Usuario"] = "";
                            Session["Permisos"] = "";
                            Session["Area"] = "";
                            Session["Activado"] = "";
                            error.Text = "Esta cuenta ha registrado un multiple acceso, esta cuenta ha sido desactivada por su seguridad";
                            procedimientos.desactivar_cuenta_usuario(id);
                            procedimientos.validar_salida_usuario(id);
                        }
                        else if (activado == false)
                        {
                            TextBoxUsuario.Text = "";
                            TextBoxPassword.Text = "";
                            Session["Logged"] = false;
                            Session["Usuario"] = "";
                            Session["Permisos"] = "";
                            Session["Area"] = "";
                            Session["Activado"] = "";
                            error.Text = "Esta cuenta no esta activa";
                        }
                        else
                        {
                            nivel = datos_sesion.GetData(hash)[0].nivel_usuario;
                            area = datos_sesion.GetData(hash)[0].area_usuario;
                            nombre = datos_sesion.GetData(hash)[0].nombre_usuario;
                            procedimientos.validar_entrada_usuario(id);
                            if (funciones.comprobar_multiple_acceso(correo, hash) == 1)
                                acceso = true;
                            else
                                acceso = false;
                            Session["ID"] = id;
                            Session["Logged"] = acceso;
                            Session["Usuario"] = nombre;
                            Session["Permisos"] = nivel;
                            Session["Area"] = area;
                            Session["Activado"] = activado;
                            Response.Redirect("../Principal/Inicio.aspx");
                        }
                    }
                    else
                    {
                        error.Text = "Correo o password incorrectos";
                        TextBoxUsuario.Text = "";
                    }
                }
            }
            catch (Exception ex) { error.Text = ex.ToString(); }
        }
    }
}