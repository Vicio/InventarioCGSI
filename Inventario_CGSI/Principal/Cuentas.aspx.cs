using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inventario_CGSI.AppData.DataSetProcsTableAdapters;
using Inventario_CGSI.AppData;

namespace Inventario_CGSI.Principal
{
    public partial class Cuentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 if(Session["Area"].Equals("T"))
                {
                    DDLArea_usuario.Items.Insert(0, new ListItem("Wireless", "A"));
                    DDLArea_usuario.Items.Insert(1, new ListItem("Redes", "R"));
                    DDLArea_usuario.Items.Insert(2, new ListItem("Switch & Router", "S"));
                    DDLArea_usuario.Items.Insert(3, new ListItem("Centro de Computo", "C"));
                    DDLArea_usuario.Items.Insert(3, new ListItem("Videoconferencia", "V"));
                    DDLArea_usuario.Items.Insert(4, new ListItem("Total", "T"));
                }
                else if(Session["Area"].Equals("A"))
                {
                    DDLArea_usuario.Items.Insert(0, new ListItem("Wireless", "A"));
                }
                else if(Session["Area"].Equals("R"))
                {
                    DDLArea_usuario.Items.Insert(0, new ListItem("Redes", "R"));
                }
                else if (Session["Area"].Equals("S"))
                {
                    DDLArea_usuario.Items.Insert(0, new ListItem("Switch & Router", "S"));
                }
                else if(Session["Area"].Equals("C"))
                {
                    DDLArea_usuario.Items.Insert(0, new ListItem("Centro de Computo", "C"));
                }
                 else if (Session["Area"].Equals("V"))
                 {
                     DDLArea_usuario.Items.Insert(0, new ListItem("Videoconferencia", "V"));
                 }
            //===================================================================================================
                if (Session["Permisos"].Equals("A"))
                {
                    DDLNivel_usuario.Items.Insert(0, new ListItem("Administrador", "A"));
                    DDLNivel_usuario.Items.Insert(1, new ListItem("Coordinador", "C"));
                    DDLNivel_usuario.Items.Insert(2, new ListItem("Encargado", "E"));
                }
                else if (Session["Permisos"].Equals("C"))
                {
                    DDLNivel_usuario.Items.Insert(0, new ListItem("Encargado", "E"));
                }
            }
        }

        protected void ButtonNuevoUsuario_Click(object sender, EventArgs e)
        {
            divCuenta.Visible = false;
            divNewCuenta.Visible = true;
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            SQLInjects inject = new SQLInjects();
            ProcsTableAdapter procedimientos = new ProcsTableAdapter();

            if(txtNombre_usuario.Text!=""&& txtHash_usuario.Text!=""&&txtCorreo_usuario.Text!=""&&txtApellido_usuario.Text!="")
            {
                string nombre = inject.Remover(txtNombre_usuario.Text);
                string correo = inject.Remover(txtCorreo_usuario.Text);
                string apellido = inject.Remover(txtApellido_usuario.Text);
                string area = inject.Remover(DDLArea_usuario.SelectedValue.ToString());
                string nivel = inject.Remover(DDLNivel_usuario.SelectedValue.ToString());
                string hash = PasswordHash.CreateHash(txtHash_usuario.Text);
                bool activacion = CheckBoxActivacion.Checked;
                if((bool)Session["Editar"])
                {
                    {
                        int id = int.Parse(labelIDUsuario.InnerHtml);
                        try
                        {
                            procedimientos.update_usuario
                                (
                                    id,
                                    nombre,
                                    apellido,
                                    correo,
                                    hash,
                                    nivel,
                                    area,
                                    activacion,
                                    false
                                );
                        }
                        catch (Exception ex)
                        {
                            lbl_error_correo.Text = ex.ToString();
                        }
                    }
                }
                else
                {
                    try
                    {
                        procedimientos.agregar_usuarios(nombre, apellido, correo, hash, nivel, area, activacion, false);
                    }
                    catch (Exception ex)
                    {
                        lbl_error_correo.Text = ex.ToString();
                    }

                }
            }
            else
            {
                lbl_error_correo.Text = "Hay campos vacios";
            }
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            divCuenta.Visible = true;
            divNewCuenta.Visible = false;
        }

        protected void GridViewCuentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Editar"))
            {
                SQLInjects injects = new SQLInjects();
                Session["Editar"] = true;
                int indice = Convert.ToInt32(e.CommandArgument);
                divCuenta.Visible = false;
                divNewCuenta.Visible = true;
                GridViewRow fila = GridViewCuentas.Rows[indice];
                labelIDUsuario.InnerHtml = HttpUtility.HtmlDecode(GridViewCuentas.DataKeys[indice].Values["ID"].ToString());
                txtNombre_usuario.Text = HttpUtility.HtmlDecode(fila.Cells[1].Text);
                txtApellido_usuario.Text = HttpUtility.HtmlDecode(fila.Cells[2].Text);
                txtCorreo_usuario.Text = HttpUtility.HtmlDecode(fila.Cells[3].Text);
                for (int i = 0; i < DDLNivel_usuario.Items.Count; i++)
                    if (DDLNivel_usuario.Items[i].Value.Equals(HttpUtility.HtmlDecode(fila.Cells[4].Text)))
                        DDLNivel_usuario.Items[i].Selected = true;
                    else
                        DDLNivel_usuario.Items[i].Selected = false;
                for (int i = 0; i < DDLArea_usuario.Items.Count; i++)
                    if (DDLArea_usuario.Items[i].Value.Equals(HttpUtility.HtmlDecode(fila.Cells[5].Text)))
                        DDLArea_usuario.Items[i].Selected = true;
                    else
                        DDLArea_usuario.Items[i].Selected = false;

            }

        }
    }
}