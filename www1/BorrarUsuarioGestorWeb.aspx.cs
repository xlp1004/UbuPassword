using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaDeClases;

namespace www1
{
    public partial class BorrarUsuarioGestorWeb : System.Web.UI.Page
    {
        bool borrar = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebForm1.registrado == false)
            {
                Server.Transfer("InicioSesion.aspx", true);
             
            }
        }
        protected void BorrarUsuarioOnClick(object sender, EventArgs e)
        {
            String eMail = Email_Usuario_Input.Text;
            string patron2 = "[a-zA-Z0-9]+@ubu\\.es";
            if (eMail == "")
            {
                Response.Write("<script>alert('Rellene el Email ')</script>");
                return;
            }
            if (!Regex.IsMatch(eMail, patron2))
            {
                Response.Write("<script>alert('Introduzca el email con el formato example@ubu.es ')</script>");
                return;
            }



            if (borrar == true) {
                WebForm1.db1.BorraUsuario(eMail);
                Response.Write("<script>alert('Usuario eliminado con éxito')</script>");
                Server.Transfer("GestorWeb.aspx", true);
            }

        }
        protected void VolverAUsuarioGestorOnClick(object sender, EventArgs e)
        {
            Server.Transfer("GestorWeb.aspx", true);
        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (sender != null)
            {

                borrar = true;
            }
        }
    }
}