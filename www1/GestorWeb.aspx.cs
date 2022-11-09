using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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
            Server.Transfer("UsuarioWeb.aspx", true);
        }

        protected void CerrarSesion_Click(object sender, EventArgs e)
        {
            WebForm1.registrado = false;

            Response.Redirect("https://localhost:44338/InicioSesion.aspx");
        }

        protected void EntradaLog_Click(object sender, EventArgs e)
        {
            Server.Transfer("WebEntradasLog.aspx",true);
        }
        protected void CrearUsuarioOnClick(object sender, EventArgs e)
        {
            Server.Transfer("CrearUsuarioGestorWeb.aspx", true);
        }

        protected void BorrarUsuarioOnClick(object sender, EventArgs e)
        {
            Server.Transfer("BorrarUsuarioGestorWeb.aspx", true);
        }

    }
}