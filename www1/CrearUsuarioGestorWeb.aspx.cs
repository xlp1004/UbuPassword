using LibreriaDeClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace www1
{
    public partial class CrearUsuarioGestorWeb : System.Web.UI.Page
    {
        private bool esGestor = false;
        Usuario uIS = WebForm1.usuarioIS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebForm1.registrado == false) {
                Server.Transfer("InicioSesion.aspx", true);
            }
        }
        protected void CrearUsuarioOnClick(object sender, EventArgs e)
        {
            String nombre = Nombre_Usuario_Input.Text;
            String apellidos = Apellido_Usuario_Input.Text;
            String eMail = Email_Usuario_Input.Text;
            string patron2 = "[a-zA-Z0-9]+@ubu\\.es";
            if (!Regex.IsMatch(eMail, patron2)) {
                Response.Write("<script>alert('Introduzca el email con el formato example@ubu.es ')</script>");
                return;
            }
            String contrasenya = Password_Input.Text;
            if (contrasenya.Length < 8) {
                Response.Write("<script>alert('La contraseña tiene menos de 8 caracteres ')</script>");
                return;
            }
            if (nombre == "" || apellidos == "" || eMail == "" || contrasenya == "") {
                Response.Write("<script>alert('Rellene todos los datos')</script>");
                return;
            }
            
            Usuario nuevoUsuario = uIS.CrearUsuario(nombre, apellidos, eMail, contrasenya);
            if (esGestor == true) {

                nuevoUsuario.Gestor = true;

            }
            WebForm1.db1.InsertarUsuario(nuevoUsuario);
            if (nuevoUsuario != null) {
                Response.Write("<script>alert('Usuario creado con éxito')</script>");
                Server.Transfer("GestorWeb.aspx", true);
            }
        }
        protected void VolverAUsuarioGestorOnClick(object sender, EventArgs e)
        {
            Server.Transfer("GestorWeb.aspx", true);
        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (sender != null) { 
            
                esGestor = true;
            }
        }
    }
}