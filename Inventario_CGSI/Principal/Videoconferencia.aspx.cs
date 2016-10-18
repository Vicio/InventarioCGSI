using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inventario_CGSI.AppData.DataSetProcsTableAdapters;
using Inventario_CGSI.AppData;
using Inventario_CGSI.AppData.DataSetFuncsTableAdapters;
using System.IO;
using System.Collections;
using System.Data;
namespace Inventario_CGSI.Principal
{
    public partial class Videoconferencia : System.Web.UI.Page
    {
        ProcsTableAdapter procedimientos = new ProcsTableAdapter();
        SQLInjects inject = new SQLInjects();
        public static int indice2;
        public static int indice1;
        public static int indice3;
        public static int indice2_parte;
        public static int indice1_parte;
        public static int indice3_parte;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBind();
                if ((string)Session["DivActivo"] == "ModificarParte")
                {
                    ModificarParte(int.Parse(Session["ID_Parte"].ToString()));
                }
                else if ((string)Session["DivActivo"] == "ModificarArticulo")
                {
                    ModificarArticulo(int.Parse(Session["ID_Articulo"].ToString()));
                    Mostrar_Articulos();
                    Habilita_Articulos();
                    Recuperar_Articulos_Global();
                    ImagenArticulo.Visible = true;
                    lbl_imagen_art_actual.Visible = true;
                }

                else if ((string)Session["DivActivo"] == "DetalleParte")
                {
                    DetalleParte(int.Parse(Session["ID_Parte"].ToString()));
                }

                else if ((string)Session["DivActivo"] == "DetalleArticulo")
                {
                    DetalleArticulo(int.Parse(Session["ID_Articulo"].ToString()));
                }
                else if (Session["DivActivo"].ToString().Equals("Articulos"))
                {
                    divArticulos.Visible = true;
                    divAgregarPartes.Visible = false;
                    divAgregarArticulos.Visible = false;
                    divPartes.Visible = false;
                }
                else if (Session["DivActivo"].ToString().Equals("Partes"))
                {
                    divArticulos.Visible = false;
                    divAgregarPartes.Visible = false;
                    divAgregarArticulos.Visible = false;
                    divPartes.Visible = true;
                }
                else { }
            }
        }
        protected void AgregarNuevoArticulo_Click(object sender, EventArgs e)
        {
            Agregar_Nuevo_Articulo();
            Session["BtnAccion_Articulo"] = "Agregar";
            lbl_id_articulo.Text = "";
        }
        public void Enviar_Articulos_Global()
        {
            Session["NoSerie"] = TxtNoSerie.Text;
            Session["Nombre"] = TxtNombre.Text;
            Session["Tipo"] = DDLTipo.SelectedIndex;
            Session["IP"] = txtIP_1.Text + "." +
                        txtIP_2.Text + "." +
                        txtIP_3.Text + "." +
                        txtIP_4.Text;
            Session["Mac"] = txtMac_1.Text +
                            ":" + txtMac_2.Text + ":" +
                            txtMac_3.Text + ":" +
                            txtMac_4.Text + ":" +
                            txtMac_5.Text + ":" + txtMac_6.Text;
            Session["Marca"] = DDLMarca.SelectedIndex;
            Session["Modelo"] = DDLModelo.SelectedIndex;
            Session["Estado"] = DDLEstado.SelectedIndex;
            Session["Medidas"] = DDLTamano.SelectedIndex;
            Session["Campus"] = DDLCampus.SelectedIndex;
            Session["Adscripcion"] = DDLAdscripcion.SelectedIndex;
            Session["Ubicacion"] = DDLUbicacion.SelectedIndex;
            Session["Descripcion"] = txtDescripcion.Text;
            Session["IdCompuesto"] = DDLPerteneceADispositivo.SelectedIndex;
            Session["PaginaRetorno"] = "Videoconferencia.aspx";
            Session["Imagen"] = ImagenArticulo.ImageUrl;
            Session["ID_Articulo"] = lbl_id_articulo.Text;
            Session["Puertos"] = TxtPuertos.Text;
        }
        public void Recuperar_Articulos_Global()
        {
            TxtNoSerie.Text = Session["NoSerie"].ToString();
            TxtNombre.Text = Session["Nombre"].ToString();
            DDLTipo.SelectedIndex = int.Parse(Session["Tipo"].ToString());
            string[] ipes = Session["IP"].ToString().Split('.');
            txtIP_1.Text = ipes[0];
            txtIP_2.Text = ipes[1];
            txtIP_3.Text = ipes[2];
            txtIP_4.Text = ipes[3];

            string[] macs = Session["Mac"].ToString().Split(':');

            txtMac_1.Text = macs[0];
            txtMac_2.Text = macs[1];
            txtMac_3.Text = macs[2];
            txtMac_4.Text = macs[3];
            txtMac_5.Text = macs[4];
            txtMac_6.Text = macs[5];

            DDLMarca.SelectedIndex = int.Parse(Session["Marca"].ToString());
            DDLModelo.SelectedIndex = int.Parse(Session["Modelo"].ToString());
            DDLEstado.SelectedIndex = int.Parse(Session["Estado"].ToString());
            DDLTamano.SelectedIndex = int.Parse(Session["Medidas"].ToString());
            DDLCampus.SelectedIndex = int.Parse(Session["Campus"].ToString());
            DDLAdscripcion.SelectedIndex = int.Parse(Session["Adscripcion"].ToString());
            DDLUbicacion.SelectedIndex = int.Parse(Session["Ubicacion"].ToString());
            txtDescripcion.Text = Session["Descripcion"].ToString();
            DDLPerteneceADispositivo.SelectedIndex = int.Parse(Session["IdCompuesto"].ToString());
            lbl_id_articulo.Text = Session["ID_Articulo"].ToString();
            ImagenArticulo.ImageUrl = Session["Imagen"].ToString();
            TxtPuertos.Text = Session["Puertos"].ToString();
        }
        public void Enviar_Partes_Global()
        {
            Session["Tipo"] = DDLTipo_Parte.SelectedValue.ToString();
            Session["Marca"] = DDLMarca_Parte.SelectedValue.ToString();
            Session["Modelo"] = DDLModelo.SelectedValue.ToString();
            Session["Estado"] = DDLEstado_Parte.SelectedValue.ToString();
            Session["Medidas"] = DDLTamano_Parte.SelectedValue.ToString();
            Session["Descripcion"] = TxtDescripcion_Parte.Text;
            Session["NumParte"] = TxtNo_Parte.Text;
            Session["IdCompuesto"] = DDLPartePerteneceA.SelectedValue.ToString();
            Session["ID_Parte"] = lbl_id_parte.Text;
            Session["PaginaRetorno"] = "Videoconferencia.aspx";
            Session["Imagen"] = ImagePartes.ImageUrl;
            Session["Cantidad"] = TxtCantidad_Parte.Text;
        }
        public void Recuperar_Partes_Global()
        {
            DDLTipo_Parte.SelectedIndex = int.Parse(Session["Tipo"].ToString());
            DDLMarca_Parte.SelectedIndex = int.Parse(Session["Marca"].ToString());
            DDLModelo_Parte.SelectedIndex = int.Parse(Session["Modelo"].ToString());
            DDLEstado_Parte.SelectedIndex = int.Parse(Session["Estado"].ToString());
            DDLTamano_Parte.SelectedIndex = int.Parse(Session["Medidas"].ToString());
            TxtDescripcion_Parte.Text = Session["Descripcion"].ToString();
            TxtNo_Parte.Text = Session["NumParte"].ToString();
            DDLPartePerteneceA.SelectedIndex = int.Parse(Session["IdCompuesto"].ToString());
            lbl_id_parte.Text = Session["ID_Parte"].ToString();
            ImagePartes.ImageUrl = Session["Imagen"].ToString();
            TxtCantidad_Parte.Text = Session["Cantidad"].ToString();
        }
        protected void Agregar_Nuevo_Articulo()
        {
            Mostrar_Articulos();
            Recuperar_Articulos_Global();
            Habilita_Articulos();
            ImagenArticulo.Visible = false;
            lbl_imagen_art_actual.Visible = false;
        }
        protected void Agregar_Nuevo_Partes()
        {
            Mostrar_Partes();
            Habilita_Partes();
        }
        protected void ButtonAgregarPartes_Click(object sender, EventArgs e)
        {
            Session["BtnAccion_Parte"] = "Agregar";
            Agregar_Nuevo_Partes();
            lbl_id_parte.Text = "";
            Recuperar_Partes_Global();
        }
        public void Agregar_Partes()
        {
            long? estatus;
            long? id_compuesto;
            long? tipo;
            long? marca;
            long? modelo;
            long? tamano;
            string num_parte;
            long? cantidad;
            string descripcion;

            estatus = long.Parse(inject.Remover(DDLEstado_Parte.SelectedValue.ToString()));
            id_compuesto = long.Parse(inject.Remover(DDLPartePerteneceA.SelectedValue.ToString()));
            tipo = long.Parse(inject.Remover(DDLTipo_Parte.SelectedValue.ToString()));
            marca = long.Parse(inject.Remover(DDLTipo_Parte.SelectedValue.ToString()));
            modelo = long.Parse(inject.Remover(DDLTipo_Parte.SelectedValue.ToString()));
            tamano = long.Parse(inject.Remover(DDLTipo_Parte.SelectedValue.ToString()));
            num_parte = inject.Remover(TxtNo_Parte.Text);
            cantidad = long.Parse(inject.Remover(TxtCantidad_Parte.Text));
            descripcion = inject.Remover(TxtDescripcion_Parte.Text);
            if (cantidad < 0) { LblExitoP_agregar.Text = "Solo puede usar valores positivos para las cantidades"; }
            else
            {
                try
                {
                    procedimientos.agregar_partes(5,
                        estatus,
                        id_compuesto,
                        tipo,
                        marca,
                        modelo,
                        tamano,
                        num_parte,
                        cantidad,
                        descripcion,
                        Lbl_slide_parte.Text);
                    LblExitoP_agregar.Text = "Datos agregados exitosamente!";
                    Session["BtnAccion_Parte"] = "";
                }
                catch { }
            }
        }
        public void Modificar_Partes()
        {
            long? estatus;
            long? id_compuesto;
            long? tipo;
            long? marca;
            long? modelo;
            long? tamano;
            string num_parte;
            long? cantidad;
            string descripcion;
            long? id_parte;

            estatus = long.Parse(inject.Remover(DDLEstado_Parte.SelectedValue.ToString()));
            id_compuesto = long.Parse(inject.Remover(DDLPartePerteneceA.SelectedValue.ToString()));
            tipo = long.Parse(inject.Remover(DDLTipo_Parte.SelectedValue.ToString()));
            marca = long.Parse(inject.Remover(DDLTipo_Parte.SelectedValue.ToString()));
            modelo = long.Parse(inject.Remover(DDLTipo_Parte.SelectedValue.ToString()));
            tamano = long.Parse(inject.Remover(DDLTipo_Parte.SelectedValue.ToString()));
            num_parte = inject.Remover(TxtNo_Parte.Text);
            cantidad = long.Parse(inject.Remover(TxtCantidad_Parte.Text));
            descripcion = inject.Remover(TxtDescripcion_Parte.Text);
            id_parte = long.Parse(lbl_id_parte.Text);
            if (cantidad < 0) { LblExitoP_agregar.Text = "Solo puede usar valores positivos para las cantidades"; }
            else
            {
                try
                {
                    procedimientos.actualizar_partes(id_parte,
                        5,
                        estatus,
                        marca,
                        modelo,
                        tipo,
                        tamano,
                        id_compuesto,
                        num_parte,
                        cantidad,
                        descripcion,
                        Lbl_slide_parte.Text);
                    Session["BtnAccion_Parte"] = "";
                }
                catch { }
            }
        }
        public void Agregar_Articulos()
        {
            string no_serie = "";
            string nombre = "";
            long? tipo = 0;
            string ip_dispositivo = "";
            string mac_dispositivo = "";
            long? modelo = 0;
            long? tamano = 0;
            long? marca = 0;
            long? estatus = 0;
            long? campus = 0;
            long? adscripcion = 0;
            long? ubicacion = 0;
            string descripcion = "";
            long? id_articulo_relacion = null;
            int aux = 0;
            long? puerto = 0;

            no_serie = inject.Remover(TxtNoSerie.Text);
            nombre = inject.Remover(TxtNombre.Text);
            tipo = long.Parse(inject.Remover(DDLTipo.SelectedValue.ToString()));
            bool validaIP1 = int.TryParse(txtIP_1.Text, out aux);
            bool validaIP2 = int.TryParse(txtIP_2.Text, out aux);
            bool validaIP3 = int.TryParse(txtIP_3.Text, out aux);
            bool validaIP4 = int.TryParse(txtIP_4.Text, out aux);

            string[] macs = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };

            modelo = int.Parse(inject.Remover(DDLModelo.SelectedValue.ToString()));
            tamano = long.Parse(inject.Remover(DDLTamano.SelectedValue.ToString()));
            marca = long.Parse(inject.Remover(DDLMarca.SelectedValue.ToString()));
            estatus = long.Parse(inject.Remover(DDLEstado.SelectedValue.ToString()));
            campus = long.Parse(inject.Remover(DDLCampus.SelectedValue.ToString()));
            adscripcion = long.Parse(inject.Remover(DDLAdscripcion.SelectedValue.ToString()));
            ubicacion = long.Parse(inject.Remover(DDLUbicacion.SelectedValue.ToString()));
            descripcion = inject.Remover(txtDescripcion.Text);
            puerto = long.Parse(inject.Remover(TxtPuertos.Text));
            try
            {
                id_articulo_relacion = long.Parse(inject.Remover(DDLPerteneceADispositivo.SelectedValue.ToString()));
            }
            catch { }
            if (validaIP1 && validaIP2 && validaIP3 && validaIP4)
            {
                ip_dispositivo = inject.Remover(txtIP_1.Text + "." +
                    txtIP_2.Text + "." +
                    txtIP_3.Text + "." +
                    txtIP_4.Text);
            }
            else
            {
                LblErrorIP_Agregar.Text = "*Numéricos";
            }
            if (txtMac_1.Text.Length > 1
                && txtMac_2.Text.Length > 1
                && txtMac_3.Text.Length > 1
                && txtMac_4.Text.Length > 1 &&
                txtMac_5.Text.Length > 1 &&
                txtMac_6.Text.Length > 1)
            {
                bool validaMac1_1 = macs.Contains(txtMac_1.Text.ToUpper().Substring(0, 1));
                bool validaMac2_1 = macs.Contains(txtMac_2.Text.ToUpper().Substring(0, 1));
                bool validaMac3_1 = macs.Contains(txtMac_3.Text.ToUpper().Substring(0, 1));
                bool validaMac4_1 = macs.Contains(txtMac_4.Text.ToUpper().Substring(0, 1));
                bool validaMac5_1 = macs.Contains(txtMac_5.Text.ToUpper().Substring(0, 1));
                bool validaMac6_1 = macs.Contains(txtMac_6.Text.ToUpper().Substring(0, 1));
                bool validaMac1_2 = macs.Contains(txtMac_1.Text.ToUpper().Substring(1, 1));
                bool validaMac2_2 = macs.Contains(txtMac_2.Text.ToUpper().Substring(1, 1));
                bool validaMac3_2 = macs.Contains(txtMac_3.Text.ToUpper().Substring(1, 1));
                bool validaMac4_2 = macs.Contains(txtMac_4.Text.ToUpper().Substring(1, 1));
                bool validaMac5_2 = macs.Contains(txtMac_5.Text.ToUpper().Substring(1, 1));
                bool validaMac6_2 = macs.Contains(txtMac_6.Text.ToUpper().Substring(1, 1));


                if (validaMac1_1 && validaMac2_1 && validaMac3_1 && validaMac4_1 && validaMac5_1 && validaMac6_1
                    && validaMac1_2 && validaMac2_2 && validaMac3_2 && validaMac4_2 && validaMac5_2 && validaMac6_2)
                {
                    mac_dispositivo = inject.Remover(txtMac_1.Text +
                        ":" + txtMac_2.Text + ":" +
                        txtMac_3.Text + ":" +
                        txtMac_4.Text + ":" +
                        txtMac_5.Text + ":" + txtMac_6.Text);
                }
                else
                {
                    LblErrorMac_Agregar.Text = "*Valores aceptados: 0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F";
                }
                try
                {
                    if (validaIP1 && validaIP2 && validaIP3 && validaIP4)
                    {
                        if (validaMac1_1 && validaMac2_1 && validaMac3_1 && validaMac4_1 && validaMac5_1 && validaMac6_1
                   && validaMac1_2 && validaMac2_2 && validaMac3_2 && validaMac4_2 && validaMac5_2 && validaMac6_2)
                        {
                            procedimientos.agregar_dispositivos_wireless(5,
                                marca,
                                modelo,
                                tipo,
                                tamano,
                                campus,
                                adscripcion,
                                ubicacion,
                                estatus,
                                id_articulo_relacion,
                                no_serie,
                                mac_dispositivo,
                                ip_dispositivo,
                                puerto,
                                nombre,
                                descripcion,
                                lbl_imagen.Text);
                            LimpiarGlobal();
                            Session["BtnAccion_Articulo"] = "";
                            LblErrorIP_Agregar.Text = "";
                            LblErrorMac_Agregar.Text = "";
                            LblExitoA_agregar.Text = "Datos agregados exitosamente!";
                        }
                    }
                }

                catch { }
            }
            else
            {
                LblErrorMac_Agregar.Text = "*Se necesitan almenos 2 valores en cada campo";
            }
        }
        public void Modificar_Articulos()
        {
            string no_serie = "";
            string nombre = "";
            long? tipo = 0;
            string ip_dispositivo = "";
            string mac_dispositivo = "";
            long? modelo = 0;
            long? tamano = 0;
            long? marca = 0;
            long? estatus = 0;
            long? campus = 0;
            long? adscripcion = 0;
            long? ubicacion = 0;
            string descripcion = "";
            long? id_articulo_relacion = null;
            int aux = 0;
            long? id_dispositivo = 0;
            long? puerto = 0;

            no_serie = inject.Remover(TxtNoSerie.Text);
            nombre = inject.Remover(TxtNombre.Text);
            tipo = long.Parse(inject.Remover(DDLTipo.SelectedValue.ToString()));
            id_dispositivo = long.Parse(inject.Remover(lbl_id_articulo.Text));
            bool validaIP1 = int.TryParse(txtIP_1.Text, out aux);
            bool validaIP2 = int.TryParse(txtIP_2.Text, out aux);
            bool validaIP3 = int.TryParse(txtIP_3.Text, out aux);
            bool validaIP4 = int.TryParse(txtIP_4.Text, out aux);

            string[] macs = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };

            modelo = int.Parse(inject.Remover(DDLModelo.SelectedValue.ToString()));
            tamano = long.Parse(inject.Remover(DDLTamano.SelectedValue.ToString()));
            marca = long.Parse(inject.Remover(DDLMarca.SelectedValue.ToString()));
            estatus = long.Parse(inject.Remover(DDLEstado.SelectedValue.ToString()));
            campus = long.Parse(inject.Remover(DDLCampus.SelectedValue.ToString()));
            adscripcion = long.Parse(inject.Remover(DDLAdscripcion.SelectedValue.ToString()));
            ubicacion = long.Parse(inject.Remover(DDLUbicacion.SelectedValue.ToString()));
            descripcion = inject.Remover(txtDescripcion.Text);
            puerto = long.Parse(inject.Remover(TxtPuertos.Text));

            try
            {
                id_articulo_relacion = long.Parse(inject.Remover(DDLPerteneceADispositivo.SelectedValue.ToString()));
            }
            catch { }

            if (validaIP1 && validaIP2 && validaIP3 && validaIP4)
            {
                ip_dispositivo = inject.Remover(txtIP_1.Text + "." +
                    txtIP_2.Text + "." +
                    txtIP_3.Text + "." +
                    txtIP_4.Text);
            }
            else
            {
                LblErrorIP_Agregar.Text = "*Numéricos";
            }
            if (txtMac_1.Text.Length > 1
                && txtMac_2.Text.Length > 1
                && txtMac_3.Text.Length > 1
                && txtMac_4.Text.Length > 1 &&
                txtMac_5.Text.Length > 1 &&
                txtMac_6.Text.Length > 1)
            {
                bool validaMac1_1 = macs.Contains(txtMac_1.Text.ToUpper().Substring(0, 1));
                bool validaMac2_1 = macs.Contains(txtMac_2.Text.ToUpper().Substring(0, 1));
                bool validaMac3_1 = macs.Contains(txtMac_3.Text.ToUpper().Substring(0, 1));
                bool validaMac4_1 = macs.Contains(txtMac_4.Text.ToUpper().Substring(0, 1));
                bool validaMac5_1 = macs.Contains(txtMac_5.Text.ToUpper().Substring(0, 1));
                bool validaMac6_1 = macs.Contains(txtMac_6.Text.ToUpper().Substring(0, 1));
                bool validaMac1_2 = macs.Contains(txtMac_1.Text.ToUpper().Substring(1, 1));
                bool validaMac2_2 = macs.Contains(txtMac_2.Text.ToUpper().Substring(1, 1));
                bool validaMac3_2 = macs.Contains(txtMac_3.Text.ToUpper().Substring(1, 1));
                bool validaMac4_2 = macs.Contains(txtMac_4.Text.ToUpper().Substring(1, 1));
                bool validaMac5_2 = macs.Contains(txtMac_5.Text.ToUpper().Substring(1, 1));
                bool validaMac6_2 = macs.Contains(txtMac_6.Text.ToUpper().Substring(1, 1));


                if (validaMac1_1 && validaMac2_1 && validaMac3_1 && validaMac4_1 && validaMac5_1 && validaMac6_1
                    && validaMac1_2 && validaMac2_2 && validaMac3_2 && validaMac4_2 && validaMac5_2 && validaMac6_2)
                {
                    mac_dispositivo = inject.Remover(txtMac_1.Text +
                        ":" + txtMac_2.Text + ":" +
                        txtMac_3.Text + ":" +
                        txtMac_4.Text + ":" +
                        txtMac_5.Text + ":" + txtMac_6.Text);
                }
                else
                {
                    LblErrorMac_Agregar.Text = "*Valores aceptados: 0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F";
                }
                try
                {
                    if (validaIP1 && validaIP2 && validaIP3 && validaIP4)
                    {
                        if (validaMac1_1 && validaMac2_1 && validaMac3_1 && validaMac4_1 && validaMac5_1 && validaMac6_1
                   && validaMac1_2 && validaMac2_2 && validaMac3_2 && validaMac4_2 && validaMac5_2 && validaMac6_2)
                        {
                            procedimientos.actualizar_wireless(id_dispositivo,
                                5,
                                marca,
                                modelo,
                                tipo,
                                tamano,
                                campus,
                                adscripcion,
                                ubicacion,
                                estatus,
                                id_articulo_relacion,
                                no_serie,
                                mac_dispositivo,
                                ip_dispositivo,
                                puerto,
                                nombre,
                                descripcion,
                                lbl_imagen.Text);
                            LimpiarGlobal();
                            Session["BtnAccion_Articulo"] = "";
                            LblErrorIP_Agregar.Text = "";
                            LblErrorMac_Agregar.Text = "";
                            LblExitoA_agregar.Text = "Datos agregados exitosamente!";
                        }
                    }
                }

                catch { }
            }
            else
            {
                LblErrorMac_Agregar.Text = "*Se necesitan almenos 2 valores en cada campo";
            }
        }
        protected void ButtonAgregarArticulos_Click(object sender, EventArgs e)
        {
            if ((string)Session["BtnAccion_Articulo"] == "Agregar")
            {
                Agregar_Articulos();
            }
            if ((string)Session["BtnAccion_Articulo"] == "Modificar")
            {
                Modificar_Articulos();
            }
        }
        public void LimpiarGlobal()
        {
            Session["NoSerie"] = "";
            Session["PerteneceA"] = "";
            Session["Nombre"] = "";
            Session["Tipo"] = 0;
            Session["IP"] = "000.000.000.000";
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
            Session["PaginaRetorno"] = "";
            Session["ID_Articulo"] = "";
            Session["ID_Parte"] = "";
            Session["Cantidad"] = 0;
            Session["Puertos"] = 0;
        }
        protected void DDLTabla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLTabla.SelectedValue.Equals("E"))
            {
                divArticulos.Visible = true;
                divAgregarPartes.Visible = false;
                divAgregarArticulos.Visible = false;
                divPartes.Visible = false;
                Session["DivActivo"] = "Articulos";

            }
            else if (DDLTabla.SelectedValue.Equals("C"))
            {
                divArticulos.Visible = false;
                divAgregarPartes.Visible = false;
                divAgregarArticulos.Visible = false;
                divPartes.Visible = true;
                Session["DivActivo"] = "Partes";
            }
        }
        protected void ButtonACancelar_Click(object sender, EventArgs e)
        {
            divArticulos.Visible = true;
            divAgregarPartes.Visible = false;
            divAgregarArticulos.Visible = false;
            divPartes.Visible = false;
            DDLTabla.Visible = true;
            LimpiarGlobal();
        }
        public void Habilita_Articulos()
        {
            TxtNoSerie.Enabled = true;
            DDLPerteneceADispositivo.Enabled = true;
            TxtNombre.Enabled = true;
            DDLTipo.Enabled = true;
            txtIP_1.Enabled = true;
            txtIP_2.Enabled = true;
            txtIP_3.Enabled = true;
            txtIP_4.Enabled = true;
            txtMac_1.Enabled = true;
            txtMac_2.Enabled = true;
            txtMac_3.Enabled = true;
            txtMac_4.Enabled = true;
            txtMac_5.Enabled = true;
            txtMac_6.Enabled = true;
            DDLMarca.Enabled = true;
            DDLModelo.Enabled = true;
            DDLEstado.Enabled = true;
            DDLTamano.Enabled = true;
            DDLCampus.Enabled = true;
            DDLAdscripcion.Enabled = true;
            DDLUbicacion.Enabled = true;
            slider.Visible = true;
            txtDescripcion.Enabled = true;
            TxtPuertos.Enabled = true;
        }
        public void Deshabilita_Articulos()
        {
            TxtNoSerie.Enabled = false;
            DDLPerteneceADispositivo.Enabled = false;
            TxtNombre.Enabled = false;
            DDLTipo.Enabled = false;
            txtIP_1.Enabled = false;
            txtIP_2.Enabled = false;
            txtIP_3.Enabled = false;
            txtIP_4.Enabled = false;
            txtMac_1.Enabled = false;
            txtMac_2.Enabled = false;
            txtMac_3.Enabled = false;
            txtMac_4.Enabled = false;
            txtMac_5.Enabled = false;
            txtMac_6.Enabled = false;
            DDLMarca.Enabled = false;
            DDLModelo.Enabled = false;
            DDLEstado.Enabled = false;
            DDLTamano.Enabled = false;
            DDLCampus.Enabled = false;
            DDLAdscripcion.Enabled = false;
            DDLUbicacion.Enabled = false;
            ImagenArticulo.Visible = true;
            lbl_imagen_art_actual.Visible = true;
            slider.Visible = false;
            txtDescripcion.Enabled = false;
            TxtPuertos.Enabled = false;
        }
        public void Habilita_Partes()
        {
            TxtNo_Parte.Enabled = true;
            DDLPartePerteneceA.Enabled = true;
            TxtCantidad_Parte.Enabled = true;
            DDLTipo_Parte.Enabled = true;
            DDLMarca_Parte.Enabled = true;
            DDLTamano_Parte.Enabled = true;
            DDLModelo_Parte.Enabled = true;
            DDLEstado_Parte.Enabled = true;
            DivSlidePartes.Visible = true;
            TxtDescripcion_Parte.Enabled = true;
        }
        public void Deshabilita_Partes()
        {
            TxtNo_Parte.Enabled = false;
            DDLPartePerteneceA.Enabled = false;
            TxtCantidad_Parte.Enabled = false;
            DDLTipo_Parte.Enabled = false;
            DDLMarca_Parte.Enabled = false;
            DDLTamano_Parte.Enabled = false;
            DDLModelo_Parte.Enabled = false;
            DDLEstado_Parte.Enabled = false;
            DivSlidePartes.Visible = false;
            TxtDescripcion_Parte.Enabled = false;
            ImagePartes.Visible = true;
        }
        public void Mostrar_Articulos()
        {
            divAgregarArticulos.Visible = true;
            divAgregarPartes.Visible = false;
            divArticulos.Visible = false;
            divPartes.Visible = false;
            LblErrorIP_Agregar.Text = "";
            LblErrorMac_Agregar.Text = "";
            LblExitoA_agregar.Text = "";
        }
        public void Mostrar_Partes()
        {
            divAgregarArticulos.Visible = false;
            divAgregarPartes.Visible = true;
            divArticulos.Visible = false;
            divPartes.Visible = false;
            LblExitoP_agregar.Text = "";
        }
        protected void ButtonPCancelar_Click(object sender, EventArgs e)
        {
            divArticulos.Visible = false;
            divAgregarPartes.Visible = false;
            divAgregarArticulos.Visible = false;
            divPartes.Visible = true;
            DDLTabla.Visible = true;
            LimpiarGlobal();
        }
        public void DetalleParte(int indice)
        {
            obtener_detalle_parteTableAdapter partes = new obtener_detalle_parteTableAdapter();
            int id_parte = indice;
            lbl_id_parte.Text = id_parte.ToString();
            TxtNo_Parte.Text = partes.GetData(id_parte)[0].num_parte;
            DDLTipo_Parte.SelectedValue = partes.GetData(id_parte)[0].id_tipo.ToString();
            TxtCantidad_Parte.Text = partes.GetData(id_parte)[0].cantidad_parte.ToString();
            DDLModelo_Parte.SelectedValue = partes.GetData(id_parte)[0].id_modelo.ToString();
            DDLMarca_Parte.SelectedValue = partes.GetData(id_parte)[0].id_marca.ToString();
            DDLTamano_Parte.SelectedValue = partes.GetData(id_parte)[0].id_tamano.ToString();
            DDLEstado_Parte.SelectedValue = partes.GetData(id_parte)[0].id_estatus.ToString();
            TxtDescripcion_Parte.Text = partes.GetData(id_parte)[0].descripcion_parte;

            ImagePartes.ImageUrl = "~/ImagenesArticulos/" + partes.GetData(id_parte)[0].imagen_parte;
            lbl_Imagen_actual_part.Text = "Imagen actual: " + partes.GetData(id_parte)[0].imagen_parte;
            try
            {
                DDLPartePerteneceA.SelectedValue = partes.GetData(id_parte)[0].id_parte_compuesto.ToString();
            }
            catch { }
            Mostrar_Partes();
            Deshabilita_Partes();
            Session["DivActivo"] = "DetalleParte";
        }
        public void ModificarParte(int indice)
        {
            ImagePartes.Visible = true;
            obtener_detalle_parteTableAdapter partes = new obtener_detalle_parteTableAdapter();
            int id_parte = indice;
            lbl_id_parte.Text = id_parte.ToString();
            TxtNo_Parte.Text = partes.GetData(id_parte)[0].num_parte;
            DDLTipo_Parte.SelectedValue = partes.GetData(id_parte)[0].id_tipo.ToString();
            TxtCantidad_Parte.Text = partes.GetData(id_parte)[0].cantidad_parte.ToString();
            DDLModelo_Parte.SelectedValue = partes.GetData(id_parte)[0].id_modelo.ToString();
            DDLMarca_Parte.SelectedValue = partes.GetData(id_parte)[0].id_marca.ToString();
            DDLTamano_Parte.SelectedValue = partes.GetData(id_parte)[0].id_tamano.ToString();
            DDLEstado_Parte.SelectedValue = partes.GetData(id_parte)[0].id_estatus.ToString();
            TxtDescripcion_Parte.Text = partes.GetData(id_parte)[0].descripcion_parte;
            try
            {
                DDLPartePerteneceA.SelectedValue = partes.GetData(id_parte)[0].id_parte_compuesto.ToString();
            }
            catch { }
            lbl_Imagen_actual_part.Text = "Imagen actual: " + partes.GetData(id_parte)[0].imagen_parte;
            ImagePartes.ImageUrl = "~/ImagenesArticulos/" + partes.GetData(id_parte)[0].imagen_parte;
            Session["BtnAccion_Parte"] = "Modificar";
            Mostrar_Partes();
            Habilita_Partes();
            Session["DivActivo"] = "ModificarParte";
        }
        public void DetalleArticulo(int indice)
        {
            obtener_detalle_dispositivos_wirelessTableAdapter dispositivos = new obtener_detalle_dispositivos_wirelessTableAdapter();
            int id_dispositivo = indice;
            lbl_id_articulo.Text = id_dispositivo.ToString();
            TxtNoSerie.Text = dispositivos.GetData(id_dispositivo)[0].num_serie_dispositivo;
            TxtNombre.Text = dispositivos.GetData(id_dispositivo)[0].nombre_dispositivo;
            DDLTipo.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_tipo.ToString();
            string[] ipes = dispositivos.GetData(id_dispositivo)[0].ip_dispositivo.Split('.');
            if (ipes.Length < 4) { }
            else
            {
                txtIP_1.Text = ipes[0];
                txtIP_2.Text = ipes[1];
                txtIP_3.Text = ipes[2];
                txtIP_4.Text = ipes[3];
            }
            string[] macs = dispositivos.GetData(id_dispositivo)[0].mac_dispositivo.Split(':');
            if (macs.Length < 6)
            { }
            else
            {
                txtMac_1.Text = macs[0];
                txtMac_2.Text = macs[1];
                txtMac_3.Text = macs[2];
                txtMac_4.Text = macs[3];
                txtMac_5.Text = macs[4];
                txtMac_6.Text = macs[5];
            }
            DDLModelo.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_modelo.ToString();
            DDLTamano.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_tamano.ToString();
            DDLMarca.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_marca.ToString();
            DDLEstado.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_estatus.ToString();
            DDLCampus.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_campus.ToString();
            DDLAdscripcion.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_adscripcion.ToString();
            DDLUbicacion.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_ubicacion.ToString();
            try
            {
                DDLPerteneceADispositivo.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_dispositivo_compuesto.ToString();
            }
            catch { }
            txtDescripcion.Text = dispositivos.GetData(id_dispositivo)[0].descripcion_dispositivo;
            ImagenArticulo.ImageUrl = "~/ImagenesArticulos/" + dispositivos.GetData(id_dispositivo)[0].imagen_dispositivo;
            lbl_imagen_art_actual.Text = "Imagen actual: " + dispositivos.GetData(id_dispositivo)[0].imagen_dispositivo;
            TxtPuertos.Text = dispositivos.GetData(id_dispositivo)[0].puerto_dispositivo.ToString();
            Mostrar_Articulos();
            Deshabilita_Articulos();
            Session["DivActivo"] = "DetalleArticulo";
        }
        public void ModificarArticulo(int indice)
        {
            ImagenArticulo.Visible = true;
            lbl_imagen_art_actual.Visible = true;
            Recuperar_Articulos_Global();
            obtener_detalle_dispositivos_wirelessTableAdapter dispositivos = new obtener_detalle_dispositivos_wirelessTableAdapter();
            int id_dispositivo = indice;
            lbl_id_articulo.Text = id_dispositivo.ToString();
            TxtNoSerie.Text = dispositivos.GetData(id_dispositivo)[0].num_serie_dispositivo;
            TxtNombre.Text = dispositivos.GetData(id_dispositivo)[0].nombre_dispositivo;
            DDLTipo.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_tipo.ToString();
            string[] ipes = dispositivos.GetData(id_dispositivo)[0].ip_dispositivo.Split('.');
            if (ipes.Length < 4) { }
            else
            {
                txtIP_1.Text = ipes[0];
                txtIP_2.Text = ipes[1];
                txtIP_3.Text = ipes[2];
                txtIP_4.Text = ipes[3];
            }

            string[] macs = dispositivos.GetData(id_dispositivo)[0].mac_dispositivo.Split(':');
            if (macs.Length < 6)
            { }
            else
            {
                txtMac_1.Text = macs[0];
                txtMac_2.Text = macs[1];
                txtMac_3.Text = macs[2];
                txtMac_4.Text = macs[3];
                txtMac_5.Text = macs[4];
                txtMac_6.Text = macs[5];
            }
            DDLModelo.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_modelo.ToString();
            DDLTamano.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_tamano.ToString();
            DDLMarca.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_marca.ToString();
            DDLEstado.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_estatus.ToString();
            DDLCampus.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_campus.ToString();
            DDLAdscripcion.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_adscripcion.ToString();
            DDLUbicacion.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_ubicacion.ToString();
            txtDescripcion.Text = dispositivos.GetData(id_dispositivo)[0].descripcion_dispositivo;
            try
            {
                DDLPerteneceADispositivo.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_dispositivo_compuesto.ToString();
            }
            catch { }
            ImagenArticulo.ImageUrl = "~/ImagenesArticulos/" + dispositivos.GetData(id_dispositivo)[0].imagen_dispositivo;
            lbl_imagen_art_actual.Text = "Imagen actual: " + dispositivos.GetData(id_dispositivo)[0].imagen_dispositivo;
            TxtPuertos.Text = dispositivos.GetData(id_dispositivo)[0].puerto_dispositivo.ToString();
            Session["BtnAccion_Articulo"] = "Modificar";
            Mostrar_Articulos();
            Habilita_Articulos();
            Session["DivActivo"] = "ModificarArticulo";
        }
        protected void GridViewPartes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("DetalleParte"))
            {
                GridViewRow fila = GridViewPartes.Rows[Convert.ToInt32(e.CommandArgument)];
                int id_parte = int.Parse(HttpUtility.HtmlDecode(GridViewPartes.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["ID"].ToString()));
                DetalleParte(id_parte);
            }

            if (e.CommandName.Equals("ModificarParte"))
            {
                GridViewRow fila = GridViewPartes.Rows[Convert.ToInt32(e.CommandArgument)];
                int id_parte = int.Parse(HttpUtility.HtmlDecode(GridViewPartes.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["ID"].ToString()));
                ModificarParte(id_parte);
            } Session["BtnAccion_Parte"] = "Modificar";
        }
        protected void GridViewArticulos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("DetalleArticulo"))
            {
                GridViewRow fila = GridViewArticulos.Rows[Convert.ToInt32(e.CommandArgument)];
                int id_dispositivo = int.Parse(HttpUtility.HtmlDecode(GridViewArticulos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["ID"].ToString()));
                DetalleArticulo(id_dispositivo);

            }

            if (e.CommandName.Equals("ModificarArticulo"))
            {
                GridViewRow fila = GridViewArticulos.Rows[Convert.ToInt32(e.CommandArgument)];
                int id_dispositivo = int.Parse(HttpUtility.HtmlDecode(GridViewArticulos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["ID"].ToString()));
                ModificarArticulo(id_dispositivo);
            }
        }
        protected void DDLTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLTipo.SelectedValue.Equals("1"))
            {
                Enviar_Articulos_Global();
                Response.Redirect("Tipos.aspx");
            }
        }
        protected void DDLModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLModelo.SelectedValue.Equals("1"))
            {
                Enviar_Articulos_Global();
                Response.Redirect("Modelos.aspx");
            }
        }
        protected void DDLTamano_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLTamano.SelectedValue.Equals("1"))
            {
                Enviar_Articulos_Global();
                Response.Redirect("Tamanos.aspx");
            }
        }
        protected void DDLMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLMarca.SelectedValue.Equals("1"))
            {
                Enviar_Articulos_Global();
                Response.Redirect("Marcas.aspx");
            }
        }
        protected void DDLEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLEstado.SelectedValue.Equals("1"))
            {
                Enviar_Articulos_Global();
                Response.Redirect("Estados.aspx");
            }
        }
        protected void DDLCampus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLCampus.SelectedValue.Equals("1"))
            {
                Enviar_Articulos_Global();
                Response.Redirect("Campi.aspx");
            }
        }
        protected void DDLAdscripcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLAdscripcion.SelectedValue.Equals("1"))
            {
                Enviar_Articulos_Global();
                Response.Redirect("Adscripciones.aspx");
            }
        }
        protected void DDLUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLUbicacion.SelectedValue.Equals("1"))
            {
                Enviar_Articulos_Global();
                Response.Redirect("Ubicaciones.aspx");
            }
        }
        protected void DDLTipo_Parte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLTipo_Parte.SelectedValue.Equals("1"))
            {
                Enviar_Partes_Global();
                Response.Redirect("Tipos.aspx");
            }
        }
        protected void DDLTamano_Parte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLTamano_Parte.SelectedValue.Equals("1"))
            {
                Enviar_Partes_Global();
                Response.Redirect("Tamanos.aspx");
            }
        }
        protected void DDLModelo_Parte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLModelo_Parte.SelectedValue.Equals("1"))
            {
                Enviar_Partes_Global();
                Response.Redirect("Modelos.aspx");
            }
        }
        protected void DDLMarca_Parte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLMarca_Parte.SelectedValue.Equals("1"))
            {
                Enviar_Partes_Global();
                Response.Redirect("Marcas.aspx");
            }
        }
        protected void DDLEstado_Parte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLEstado_Parte.SelectedValue.Equals("1"))
            {
                Enviar_Partes_Global();
                Response.Redirect("Estados.aspx");
            }
        }
        protected void ButtonCancelar_Agregar_Click(object sender, EventArgs e)
        {
            divArticulos.Visible = true;
            divAgregarPartes.Visible = false;
            divAgregarArticulos.Visible = false;
            divPartes.Visible = false;
            DDLTabla.Visible = true;
            LimpiarGlobal();
            Recuperar_Articulos_Global();
        }
        protected void ButtonAceptar_Parte_Click(object sender, EventArgs e)
        {
            if ((string)Session["BtnAccion_Parte"] == "Agregar")
            {
                Agregar_Partes();
            }
            if ((string)Session["BtnAccion_Parte"] == "Modificar")
            {
                Modificar_Partes();
            }
        }
        protected void BtnAnterior_Click(object sender, EventArgs e)
        {
            indice2--;
            indice1 = indice2 - 1;
            indice3 = indice2 + 1;
            buscar_imagenes();
        }
        protected void BtnSiguiente_Click(object sender, EventArgs e)
        {
            indice2++;
            indice1 = indice2 - 1;
            indice3 = indice2 + 1;
            buscar_imagenes();
        }
        public void buscar_imagenes()
        {
            string[] imagenes = { };
            ArrayList la_imagen = new ArrayList();
            string[] auxilio = { };
            imagenes = Directory.GetFiles(Server.MapPath("/ImagenesArticulos"), "*.jpg");
            if (imagenes.Length > 0)
            {
                for (int i = 0; i < imagenes.Length; i++)
                {
                    auxilio = imagenes[i].Split('\\');
                    la_imagen.Add(auxilio[auxilio.Length - 1]);
                }
                int tam = la_imagen.Count;
                if (indice2 <= 0) { indice2 = 0; }
                if (indice2 >= tam - 1) { indice2 = tam - 1; }
                if (indice2 == indice1) { indice1--; }
                if (indice3 == indice2) { indice3++; }
                if (indice1 < 0)
                {
                    indice1 = -1;
                    Imagen_slide_1.Visible = false;
                    Imagen_slide_3.Visible = true;
                    Imagen_slide_2.Visible = true;
                    Imagen_slide_2.ImageUrl = "~/ImagenesArticulos/" + la_imagen[indice2].ToString();
                    Imagen_slide_3.ImageUrl = "~/ImagenesArticulos/" + la_imagen[indice3].ToString();
                }
                else if (indice3 >= tam)
                {
                    indice3 = tam;
                    Imagen_slide_3.Visible = false;
                    Imagen_slide_1.Visible = true;
                    Imagen_slide_2.Visible = true;
                    Imagen_slide_1.ImageUrl = "~/ImagenesArticulos/" + la_imagen[indice1].ToString();
                    Imagen_slide_2.ImageUrl = "~/ImagenesArticulos/" + la_imagen[indice2].ToString();
                }
                else
                {
                    Imagen_slide_1.Visible = true;
                    Imagen_slide_3.Visible = true;
                    Imagen_slide_2.Visible = true;
                    Imagen_slide_1.ImageUrl = "~/ImagenesArticulos/" + la_imagen[indice1].ToString();
                    Imagen_slide_2.ImageUrl = "~/ImagenesArticulos/" + la_imagen[indice2].ToString();
                    Imagen_slide_3.ImageUrl = "~/ImagenesArticulos/" + la_imagen[indice3].ToString();
                }
                lbl_imagen.Text = la_imagen[indice2].ToString();
            }
            else
            {
                lbl_imagen.Text = "No se encontraron imagenes en el servidor";

                Imagen_slide_1.Visible = false;
                Imagen_slide_2.Visible = false;
                Imagen_slide_3.Visible = false;

            }
        }
        protected void BtnSiguiente_Parte_Click(object sender, EventArgs e)
        {
            indice2_parte++;
            indice1_parte = indice2_parte - 1;
            indice3_parte = indice2_parte + 1;
            buscar_imagenes_partes();
        }
        protected void BtnAnterior_Parte_Click(object sender, EventArgs e)
        {
            indice2_parte--;
            indice1_parte = indice2_parte - 1;
            indice3_parte = indice2_parte + 1;
            buscar_imagenes_partes();
        }
        public void buscar_imagenes_partes()
        {
            string[] imagenes = { };
            ArrayList la_imagen = new ArrayList();
            string[] auxilio = { };
            imagenes = Directory.GetFiles(Server.MapPath("/ImagenesArticulos"), "*.jpg");
            if (imagenes.Length > 0)
            {
                for (int i = 0; i < imagenes.Length; i++)
                {
                    auxilio = imagenes[i].Split('\\');
                    la_imagen.Add(auxilio[auxilio.Length - 1]);
                }
                int tam = la_imagen.Count;
                if (indice2_parte <= 0) { indice2_parte = 0; }
                if (indice2_parte >= tam - 1) { indice2_parte = tam - 1; }
                if (indice2_parte == indice1_parte) { indice1_parte--; }
                if (indice3_parte == indice2_parte) { indice3_parte++; }
                if (indice1_parte < 0)
                {
                    indice1_parte = -1;
                    Imagen_Parte1.Visible = false;
                    Imagen_Parte3.Visible = true;
                    Imagen_Parte2.Visible = true;
                    Imagen_Parte2.ImageUrl = "~/ImagenesArticulos/" + la_imagen[indice2_parte].ToString();
                    Imagen_Parte3.ImageUrl = "~/ImagenesArticulos/" + la_imagen[indice3_parte].ToString();
                }
                else if (indice3_parte >= tam)
                {
                    indice3_parte = tam;
                    Imagen_Parte3.Visible = false;
                    Imagen_Parte1.Visible = true;
                    Imagen_Parte2.Visible = true;
                    Imagen_Parte1.ImageUrl = "~/ImagenesArticulos/" + la_imagen[indice1_parte].ToString();
                    Imagen_Parte2.ImageUrl = "~/ImagenesArticulos/" + la_imagen[indice2_parte].ToString();
                }
                else
                {
                    Imagen_Parte1.Visible = true;
                    Imagen_Parte3.Visible = true;
                    Imagen_Parte2.Visible = true;
                    Imagen_Parte1.ImageUrl = "~/ImagenesArticulos/" + la_imagen[indice1_parte].ToString();
                    Imagen_Parte2.ImageUrl = "~/ImagenesArticulos/" + la_imagen[indice2_parte].ToString();
                    Imagen_Parte3.ImageUrl = "~/ImagenesArticulos/" + la_imagen[indice3_parte].ToString();
                }
                Lbl_slide_parte.Text = la_imagen[indice2_parte].ToString();
            }
            else
            {
                Lbl_slide_parte.Text = "No se encontraron imagenes en el servidor";

                Imagen_Parte1.Visible = false;
                Imagen_Parte2.Visible = false;
                Imagen_Parte3.Visible = false;
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void GridViewArticulos_Sorting(object sender, GridViewSortEventArgs e)
        {
            SQLInjects inject = new SQLInjects();

            buscar_wirelessTableAdapter buscarWireless = new buscar_wirelessTableAdapter();

            GridViewArticulos.DataSourceID = null;
            DataTable tabla = buscarWireless.GetData(inject.Remover(TextBoxBusqueda.Text));
            tabla.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            GridViewArticulos.DataSource = tabla;
            GridViewArticulos.DataBind();
        }

        protected void GridViewPartes_Sorting(object sender, GridViewSortEventArgs e)
        {
            SQLInjects inject = new SQLInjects();

            buscar_wirelessTableAdapter buscarWireless = new buscar_wirelessTableAdapter();

            GridViewPartes.DataSourceID = null;
            DataTable tabla = buscarWireless.GetData(inject.Remover(TextBoxBusqueda.Text));
            tabla.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            GridViewPartes.DataSource = tabla;
            GridViewPartes.DataBind();
        }

        private string GetSortDirection(string column)
        {

            // By default, set the sort direction to ascending.
            string sortDirection = "ASC";

            // Retrieve the last column that was sorted.
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            // Save new values in ViewState.
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }


        protected void ButtonBusqueda_Click(object sender, EventArgs e)
        {
            BuscarDatos(sender);
        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string NombreArchivo = "Reporte_Switches_" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + NombreArchivo);
            BuscarDatos(sender);
            Button boton = (Button)sender;

            if (boton.ID == "ButtonExportarExcel")
            {
                GridViewArticulos.Columns[7].Visible = false;
                GridViewArticulos.Columns[8].Visible = false;
                GridViewArticulos.AllowPaging = false;
                GridViewArticulos.AllowSorting = false;
                GridViewArticulos.DataBind();
                GridViewArticulos.GridLines = GridLines.Both;
                GridViewArticulos.HeaderStyle.Font.Bold = true;
                GridViewArticulos.RenderControl(htmltextwrtter);
            }
            else
            {
                GridViewPartes.Columns[7].Visible = false;
                GridViewPartes.Columns[8].Visible = false;
                GridViewPartes.AllowPaging = false;
                GridViewPartes.AllowSorting = false;
                GridViewPartes.DataBind();
                GridViewPartes.GridLines = GridLines.Both;
                GridViewPartes.HeaderStyle.Font.Bold = true;
                GridViewPartes.RenderControl(htmltextwrtter);

            }
            Response.Write(strwritter.ToString());
            Response.End();

        }

        protected void BuscarDatos(object sender)
        {
            SQLInjects inject = new SQLInjects();

            Button boton = (Button)sender;

            buscar_switchesTableAdapter datosBusqueda = new buscar_switchesTableAdapter();
            buscar_switches_partesTableAdapter datosBusquedaPartes = new buscar_switches_partesTableAdapter();


            DataTable datos;

            string[] palabrasClave;

            if (boton.ID == "ButtonBusqueda" || boton.ID == "ButtonExportarExcel")
            {
                datos = new DataSetFuncs.buscar_switchesDataTable();
                GridViewArticulos.DataSourceID = null;
                GridViewArticulos.DataSource = "";
                palabrasClave = TextBoxBusqueda.Text.Split(' ');
                foreach (string palabraClave in palabrasClave)
                {
                    datos.Merge(datosBusqueda.GetData(inject.Remover(palabraClave)));
                }
            }
            else
            {
                datos = new DataSetFuncs.buscar_switches_partesDataTable();
                GridViewPartes.DataSourceID = null;
                GridViewPartes.DataSource = "";
                palabrasClave = TextBoxBusquedaPartes.Text.Split(' ');
                foreach (string palabraClave in palabrasClave)
                {
                    datos.Merge(datosBusquedaPartes.GetData(inject.Remover(palabraClave)));
                }
            }



            bool[] palabrasEncontradas = new bool[palabrasClave.Length];


            for (int j = 0; j < datos.Rows.Count; j++)
            {
                for (int i = 0; i < palabrasClave.Count(); i++)
                {
                    palabrasEncontradas[i] = false;
                    for (int k = 0; k < datos.Columns.Count; k++)
                    {
                        if (datos.Rows[j][k].ToString().ToLower().Contains(palabrasClave[i].ToLower()))
                        {
                            palabrasEncontradas[i] = true;
                        }
                    }
                }

                for (int i = 0; i < palabrasEncontradas.Length; i++)
                {
                    if (palabrasEncontradas[i] == false)
                        datos.Rows[j].Delete();
                }
            }

            DataTable temporalDatos = datos.DefaultView.ToTable(true);

            if (boton.ID == "ButtonBusqueda" || boton.ID == "ButtonExportarExcel")
            {
                GridViewArticulos.DataSource = temporalDatos;
                GridViewArticulos.DataBind();
            }
            else
            {
                GridViewPartes.DataSource = temporalDatos;
                GridViewPartes.DataBind();

            }

        }
        protected void BajaArticulo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridViewArticulos.Rows.Count; i++)
            {
                GridViewRow fila = GridViewArticulos.Rows[i];
                if (((CheckBox)fila.FindControl("ChkBaja_Articulos")).Checked)
                {
                    long? id = long.Parse(GridViewArticulos.DataKeys[i].Value.ToString());
                    procedimientos.baja_dispositivo(id);
                }
            }

            Response.Redirect("Videoconferencia.aspx");
        }

        protected void BajaPartes_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridViewPartes.Rows.Count; i++)
            {
                GridViewRow fila = GridViewPartes.Rows[i];
                if (((CheckBox)fila.FindControl("ChkBaja_Partes")).Checked)
                {
                    long? id = long.Parse(GridViewPartes.DataKeys[i].Value.ToString());
                    procedimientos.baja_parte(id);
                }
            }

            Response.Redirect("Videoconferencia.aspx");
        }
        protected void AgregarComponentes_Click(object sender, EventArgs e)
        {
            if (DDLPartesDispositivos.SelectedValue.ToString() != null)
            {
                long? id_dispositivo = long.Parse(DDLPartesDispositivos.SelectedValue.ToString());
                for (int i = 0; i < GridViewPartes.Rows.Count; i++)
                {
                    GridViewRow fila = GridViewPartes.Rows[i];
                    if (((CheckBox)fila.FindControl("ChkComponentes")).Checked)
                    {
                        long? id = long.Parse(GridViewPartes.DataKeys[i].Value.ToString());
                        procedimientos.agregar_partes_dispositivos(id, id_dispositivo);
                    }
                }
                Response.Redirect("Videoconferencia.aspx");
            }
        }
    }
}