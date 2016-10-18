using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inventario_CGSI.AppData.DataSetProcsTableAdapters;
using Inventario_CGSI.AppData.DataSetFuncsTableAdapters;
using Inventario_CGSI.AppData;
using System.IO;
using System.Collections;
using System.Data;
namespace Inventario_CGSI.Principal
{

    public partial class CentroDeComputo : System.Web.UI.Page
    {
        ProcsTableAdapter procedimientos = new ProcsTableAdapter();
        SQLInjects inject = new SQLInjects();
        public static int indice2;
        public static int indice1;
        public static int indice3;
        public static string cadenaImagenes;
        int valido;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                buscar_imagenes();
                buscar_equipo_computoTableAdapter datosBusqueda = new buscar_equipo_computoTableAdapter();
                GridViewArticulos.DataSourceID = null;
                GridViewArticulos.DataSource = datosBusqueda.GetData(inject.Remover(TextBoxBusqueda.Text));
                DataBind();
                
                if ((string)Session["DivActivo"] == "ModificarArticulo")
                {
                    if (int.TryParse(Session["ID_Articulo"].ToString(),out valido))
                    {
                        ModificarArticulo(int.Parse(Session["ID_Articulo"].ToString()));
                        Mostrar_Articulos();
                        Habilita_Articulos();
                        Recuperar_Articulos_Global();
                        ImagenArticulo.Visible = true;
                        lbl_imagen_art_actual.Visible = true;
                    }
                }
                else if ((string)Session["DivActivo"] == "DetalleArticulo")
                {
                    DetalleArticulo(int.Parse(Session["ID_Articulo"].ToString()));
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

        protected void Agregar_Nuevo_Articulo()
        {
            Mostrar_Articulos();
            Recuperar_Articulos_Global();
            Habilita_Articulos();
        }

        public void Enviar_Articulos_Global()
        {
            Session["NoSerie"] = TxtNoSerie.Text;
            Session["Tipo"] = DDLTipo.SelectedIndex;
            Session["Marca"] = DDLMarca.SelectedIndex;
            Session["Modelo"] = DDLModelo.SelectedIndex;
            Session["Estado"] = DDLEstado.SelectedIndex;
            Session["Medidas"] = DDLTamano.SelectedIndex;
            Session["Descripcion"] = txtDescripcion.Text;
            Session["IdCompuesto"] = DDLPerteneceADispositivo.SelectedIndex;
            Session["PaginaRetorno"] = "CentroDeComputo.aspx";
            Session["Imagen"] = ImagenArticulo.ImageUrl;
            Session["ID_Articulo"] = lbl_id_articulo.Text;
        }
        public void Recuperar_Articulos_Global()
        {
            DataBind();
            TxtNoSerie.Text = Session["NoSerie"].ToString();
            DDLTipo.SelectedIndex = int.Parse(Session["Tipo"].ToString());
            DDLMarca.SelectedIndex = int.Parse(Session["Marca"].ToString());
            DDLModelo.SelectedIndex = int.Parse(Session["Modelo"].ToString());
            DDLEstado.SelectedIndex = int.Parse(Session["Estado"].ToString());
            DDLTamano.SelectedIndex = int.Parse(Session["Medidas"].ToString());
            txtDescripcion.Text = Session["Descripcion"].ToString();
            DDLPerteneceADispositivo.SelectedIndex = int.Parse(Session["IdCompuesto"].ToString());
            lbl_id_articulo.Text = Session["ID_Articulo"].ToString();
            ImagenArticulo.ImageUrl = Session["Imagen"].ToString();
        }
       
        public void Agregar_Articulos()
        {
            string no_serie = "";
            long? tipo = 0;
            long? modelo = 0;
            long? tamano = 0;
            long? marca = 0;
            long? estatus = 0;
            string descripcion = "";
            long? id_articulo_relacion = null;
            no_serie = inject.Remover(TxtNoSerie.Text);
            tipo = long.Parse(inject.Remover(DDLTipo.SelectedValue.ToString()));
            modelo = int.Parse(inject.Remover(DDLModelo.SelectedValue.ToString()));
            tamano = long.Parse(inject.Remover(DDLTamano.SelectedValue.ToString()));
            marca = long.Parse(inject.Remover(DDLMarca.SelectedValue.ToString()));
            estatus = long.Parse(inject.Remover(DDLEstado.SelectedValue.ToString()));
            descripcion = inject.Remover(txtDescripcion.Text);
            try
            {
                id_articulo_relacion = long.Parse(inject.Remover(DDLPerteneceADispositivo.SelectedValue.ToString()));
            }
            catch { }
            try
            {
                procedimientos.agregar_articulos(
                    4,
                    estatus,
                    id_articulo_relacion,
                    tipo,
                    marca,
                    modelo,
                    tamano,
                    no_serie,
                    descripcion,
                    lbl_imagen.Text);
                LimpiarGlobal();
                Session["BtnAccion_Articulo"] = "";
                TxtNoSerie.Text = "";
                txtDescripcion.Text = "";
                LblExitoA_agregar.Text = "Datos agregados exitosamente!";
            }
            catch {}

        }
        public void Modificar_Articulos()
        {
            string no_serie = "";
            long? tipo = 0;
            long? modelo = 0;
            long? tamano = 0;
            long? marca = 0;
            long? estatus = 0;
            long? id_articulo_relacion = null;
            long? id_dispositivo = 0;
            string descripcion = "";
            no_serie = inject.Remover(TxtNoSerie.Text);
            tipo = long.Parse(inject.Remover(DDLTipo.SelectedValue.ToString()));
            id_dispositivo = long.Parse(inject.Remover(lbl_id_articulo.Text));
            modelo = int.Parse(inject.Remover(DDLModelo.SelectedValue.ToString()));
            tamano = long.Parse(inject.Remover(DDLTamano.SelectedValue.ToString()));
            marca = long.Parse(inject.Remover(DDLMarca.SelectedValue.ToString()));
            estatus = long.Parse(inject.Remover(DDLEstado.SelectedValue.ToString()));
            descripcion = inject.Remover(txtDescripcion.Text);
            try
            {
                id_articulo_relacion = long.Parse(inject.Remover(DDLPerteneceADispositivo.SelectedValue.ToString()));
            }
            catch { }
            try
            {
                procedimientos.actualizar_articulos(
                    id_dispositivo,
                    4,
                    marca,
                    modelo,
                    tipo,
                    tamano,
                    estatus,
                    id_articulo_relacion,
                    no_serie,
                    descripcion,
                    lbl_imagen.Text);
                    LimpiarGlobal();
                    Session["BtnAccion_Articulo"] = "";
                    LblExitoA_agregar.Text = "Datos agregados exitosamente!";
            }
            catch { }
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
            Session["PerteneceA"] = 0;
            Session["Tipo"] = 0;
            Session["Marca"] = 0;
            Session["Modelo"] = 0;
            Session["Estado"] = 0;
            Session["Medidas"] = 0;
            Session["Descripcion"] = "";
            Session["NumParte"] = "";
            Session["IdCompuesto"] = 0;
            Session["Imagen"] = "";
            Session["PaginaRetorno"] = "";
            Session["ID_Articulo"] = "";
        }
       

        protected void ButtonACancelar_Click(object sender, EventArgs e)
        {
            divArticulos.Visible = true;
            divAgregarArticulos.Visible = false;
            LimpiarGlobal();
        }
        public void Habilita_Articulos()
        {
            TxtNoSerie.Enabled = true;
            DDLPerteneceADispositivo.Enabled = true;
            DDLTipo.Enabled = true;
            DDLMarca.Enabled = true;
            DDLModelo.Enabled = true;
            DDLEstado.Enabled = true;
            DDLTamano.Enabled = true;
            divSlideImagen.Visible = true;
            txtDescripcion.Enabled = true;
        }
        public void Deshabilita_Articulos()
        {
            TxtNoSerie.Enabled = false;
            DDLPerteneceADispositivo.Enabled = false;
            DDLTipo.Enabled = false;
            DDLMarca.Enabled = false;
            DDLModelo.Enabled = false;
            DDLEstado.Enabled = false;
            DDLTamano.Enabled = false;
            ImagenArticulo.Visible = true;
            lbl_imagen_art_actual.Visible = true;
            divSlideImagen.Visible = false;
            txtDescripcion.Enabled = false;
            ButtonAgregarArticulos.Visible = false;

        }

        public void Mostrar_Articulos()
        {
            divAgregarArticulos.Visible = true;        
            divArticulos.Visible = false;
            LblExitoA_agregar.Text = "";
        }

        public void DetalleArticulo(int indice)
        {
            Mostrar_Articulos();
            Deshabilita_Articulos();
            obtener_detalle_articuloTableAdapter dispositivos = new obtener_detalle_articuloTableAdapter();
            int id_dispositivo = indice; //
            lbl_id_articulo.Text = id_dispositivo.ToString();
            TxtNoSerie.Text = dispositivos.GetData(id_dispositivo)[0].num_serie_articulo;
            DDLTipo.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_tipo.ToString();
            DDLModelo.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_modelo.ToString();
            DDLTamano.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_tamano.ToString();
            DDLMarca.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_marca.ToString();
            DDLEstado.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_estatus.ToString();
            try
            {
                DDLPerteneceADispositivo.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_articulo_compuesto.ToString();
            }
            catch { }
            txtDescripcion.Text = dispositivos.GetData(id_dispositivo)[0].descripcion_articulo;
            ImagenArticulo.ImageUrl = "~/ImagenesArticulos/" + dispositivos.GetData(id_dispositivo)[0].imagen_articulo;
            Session["DivActivo"] = "DetalleArticulo";
            lbl_imagen_art_actual.Text = "Imagen actual: " + dispositivos.GetData(id_dispositivo)[0].imagen_articulo;
        }

        public void ModificarArticulo(int indice)
        {
            ImagenArticulo.Visible = true;
            lbl_imagen_art_actual.Visible = true;
            obtener_detalle_articuloTableAdapter dispositivos = new obtener_detalle_articuloTableAdapter();
            int id_dispositivo = indice;
            lbl_id_articulo.Text = id_dispositivo.ToString();
            TxtNoSerie.Text = dispositivos.GetData(id_dispositivo)[0].num_serie_articulo;
            DDLTipo.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_tipo.ToString();
            DDLModelo.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_modelo.ToString();
            DDLTamano.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_tamano.ToString();
            DDLMarca.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_marca.ToString();
            DDLEstado.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_estatus.ToString();
            txtDescripcion.Text = dispositivos.GetData(id_dispositivo)[0].descripcion_articulo;
            try
            {
                DDLPerteneceADispositivo.SelectedValue = dispositivos.GetData(id_dispositivo)[0].id_articulo_compuesto.ToString();
            }
            catch { }
            ImagenArticulo.ImageUrl = "~/ImagenesArticulos/" + dispositivos.GetData(id_dispositivo)[0].imagen_articulo;
            lbl_imagen_art_actual.Text = "Imagen actual: " + dispositivos.GetData(id_dispositivo)[0].imagen_articulo;
            Session["BtnAccion_Articulo"] = "Modificar";
            Mostrar_Articulos();
            Habilita_Articulos();
            Session["DivActivo"] = "ModificarArticulo";
        }


        protected void GridViewArticulos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("DetalleArticulo"))
            {
                GridViewRow fila = GridViewArticulos.Rows[Convert.ToInt32(e.CommandArgument)];
                int articulo = int.Parse(HttpUtility.HtmlDecode(GridViewArticulos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["ID"].ToString()));
                DetalleArticulo(articulo);
                Session["ID_Articulo"]=articulo;
                Session["DivActivo"] = "DetalleArticulo";
            }

            if (e.CommandName.Equals("ModificarArticulo"))
            {
                GridViewRow fila = GridViewArticulos.Rows[Convert.ToInt32(e.CommandArgument)];
                int articulo = int.Parse(HttpUtility.HtmlDecode(GridViewArticulos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["ID"].ToString()));
                ModificarArticulo(articulo);
                Session["ID_Articulo"] = articulo;
                Session["DivActivo"] = "ModificarArticulo";
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
        
        protected void ButtonCancelar_Agregar_Click(object sender, EventArgs e)
        {
            divArticulos.Visible = true;
            divAgregarArticulos.Visible = false;
            LimpiarGlobal();
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
            imagenes = Directory.GetFiles(Server.MapPath("/inventario/ImagenesArticulos"), "*.jpg");
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
        protected void imagen_selected(Object sender, Image e)
        {
            try
            {
                lbl_imagen.Text = e.ImageUrl.ToString();
            }
            catch
            {
                lbl_imagen.Text = "algo no anda bien";
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void GridViewArticulos_Sorting(object sender, GridViewSortEventArgs e)
        {
            SQLInjects inject = new SQLInjects();


            buscar_equipo_computoTableAdapter buscarEquipoComputo = new buscar_equipo_computoTableAdapter();

            GridViewArticulos.DataSourceID = null;
            DataTable tabla = buscarEquipoComputo.GetData(inject.Remover(TextBoxBusqueda.Text));
            tabla.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            GridViewArticulos.DataSource = tabla;
            GridViewArticulos.DataBind();
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

        protected void BuscarDatos(object sender)
        {
            SQLInjects inject = new SQLInjects();

            Button boton = (Button)sender;

            buscar_equipo_computoTableAdapter datosBusqueda = new buscar_equipo_computoTableAdapter();


            DataTable datos;

            string[] palabrasClave;

            //if (boton.ID == "ButtonBusqueda" || boton.ID == "ButtonExportarExcel")
            //{
            datos = new DataSetFuncs.buscar_equipo_computoDataTable();
            GridViewArticulos.DataSourceID = null;
            GridViewArticulos.DataSource = "";
            palabrasClave = TextBoxBusqueda.Text.Split(' ');
            foreach (string palabraClave in palabrasClave)
            {
                datos.Merge(datosBusqueda.GetData(inject.Remover(palabraClave)));
            }
            //}
            //else
            //{
            //    datos = new DataSetFuncs.buscar_wireless_partesDataTable();
            //    GridViewPartes.DataSourceID = null;
            //    GridViewPartes.DataSource = "";
            //    palabrasClave = TextBoxBusquedaPartes.Text.Split(' ');
            //    foreach (string palabraClave in palabrasClave)
            //    {
            //        datos.Merge(datosBusquedaPartes.GetData(inject.Remover(palabraClave)));
            //    }
            //}



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

            //if (boton.ID == "ButtonBusqueda" || boton.ID == "ButtonExportarExcel")
            //{
            GridViewArticulos.DataSource = temporalDatos;
            GridViewArticulos.DataBind();
            //}
            //else
            //{
            //    GridViewPartes.DataSource = temporalDatos;
            //    GridViewPartes.DataBind();

            //}

        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string NombreArchivo = "Reporte_Equipo_de_Computo_" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + NombreArchivo);
            BuscarDatos(sender);
            Button boton = (Button)sender;

            //if (boton.ID == "ButtonExportarExcel")
            //{
            GridViewArticulos.Columns[7].Visible = false;
            GridViewArticulos.Columns[8].Visible = false;
            GridViewArticulos.AllowPaging = false;
            GridViewArticulos.AllowSorting = false;
            GridViewArticulos.DataBind();
            GridViewArticulos.GridLines = GridLines.Both;
            GridViewArticulos.HeaderStyle.Font.Bold = true;
            GridViewArticulos.RenderControl(htmltextwrtter);
            //}
            //else
            //{
            //    GridViewPartes.Columns[7].Visible = false;
            //    GridViewPartes.Columns[8].Visible = false;
            //    GridViewPartes.AllowPaging = false;
            //    GridViewPartes.AllowSorting = false;
            //    GridViewPartes.DataBind();
            //    GridViewPartes.GridLines = GridLines.Both;
            //    GridViewPartes.HeaderStyle.Font.Bold = true;
            //    GridViewPartes.RenderControl(htmltextwrtter);

            //}
            Response.Write(strwritter.ToString());
            Response.End(); 

        }

        protected void BajaArticulo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridViewArticulos.Rows.Count; i++)
            {
                GridViewRow fila = GridViewArticulos.Rows[i];
                if (((CheckBox)fila.FindControl("ChkBaja_Articulos")).Checked)
                {
                    long? id = long.Parse(GridViewArticulos.DataKeys[i].Value.ToString());
                    procedimientos.baja_articulo(id);
                }
            }
            Response.Redirect("CentroDeComputo.aspx");
        }
    }
}