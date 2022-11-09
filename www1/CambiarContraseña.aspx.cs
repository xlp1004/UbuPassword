using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace www1
{
    public partial class CambiarContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebForm1.registrado == false)
            {

                Response.Redirect("https://localhost:44338/InicioSesion.aspx");
            }
        }

        protected void CambiarContraseñaOnClick(object sender, EventArgs e) {

            string viejacontra = Password_Input.Text;
            string nuevacontra = NuevaContra.Text;
            string nuevacontraconf=NuevaContraConf.Text;
            viejacontra= WebForm1.usuarioIS.encriptar(viejacontra);

            if (viejacontra == "" || nuevacontra == "" || nuevacontraconf == "")
            {
                Response.Write("<script>alert('Rellena todos los campos')</script>");
                return;
            }
            if (nuevacontra.Length < 8)
            {
                Response.Write("<script>alert('La nueva contraseña debe tener más de 8 caracteres')</script>");
                return;

            }
            if (viejacontra != WebForm1.usuarioIS.Contrasenya) { 
                  Response.Write("<script>alert('contraseña incorrectas')</script>");
                return;
            }
            if (nuevacontra != nuevacontraconf)
            {
                Response.Write("<script>alert('Haz que coincidan las contraseñas')</script>");
                return;
            }
            String nuevacontraencr =WebForm1.usuarioIS.encriptar(nuevacontra);
            if (viejacontra == nuevacontraencr) { 
                Response.Write("<script>alert('la contraseña antigua no puede ser igual a la nueva')</script>");
                return;
            }

            if (viejacontra == WebForm1.usuarioIS.Contrasenya && nuevacontra == nuevacontraconf) {
                
                
                WebForm1.usuarioIS.CambiarContrasenya(viejacontra,nuevacontraconf);
                Response.Write("<script>alert('Contraseña cambiada con éxito')</script>");
                Server.Transfer("UsuarioWeb.aspx", true);
            }
        }

    }
}