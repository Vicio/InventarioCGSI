using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inventario_CGSI.Principal
{
    public partial class SubirArchivo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void AjaxFileUp_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            string path = Server.MapPath("../ImagenesArticulos/") + System.IO.Path.GetFileName(e.FileName);
            AjaxFileUp.SaveAs(path);         
        }
    }
}