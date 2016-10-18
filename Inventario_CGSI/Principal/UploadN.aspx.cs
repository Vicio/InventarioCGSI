using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Inventario_CGSI.Principal
{
    public partial class UploadN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //checa el archivo
            if (FileUpload1.HasFile)
            {
                //path en donde sera guardado
                string fileName = Path.Combine(Server.MapPath("~/ImagenesArticulos"), FileUpload1.FileName);
                //guardar el archivo
                FileUpload1.SaveAs(fileName);
            }
        }
    }
}