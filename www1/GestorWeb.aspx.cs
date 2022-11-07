using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace www1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebForm1.registrado == false) {
                
                Response.Redirect("https://localhost:44338/InicioSesion.aspx");
            }
        }

        protected void CambiarAUsuario(object sender, EventArgs e)
        {
            Response.Redirect("https://localhost:44338/UsuarioWeb.aspx");
        }

        protected void CerrarSesion_Click(object sender, EventArgs e)
        {
            WebForm1.registrado = false;

            Response.Redirect("https://localhost:44338/InicioSesion.aspx");
        }
    }
}