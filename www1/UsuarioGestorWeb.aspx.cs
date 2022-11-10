using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;
using LibreriaDeClases;

namespace www1
{
    public partial class UsuarioGestorWeb : System.Web.UI.Page
    {
        Usuario uIS = WebForm1.usuarioIS;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebForm1.registrado == false)
            {

                Server.Transfer("InicioSesion.aspx", true);

            }
        }
        protected void CambiarContraseña_Click(object sender, EventArgs e)
        {
            Server.Transfer("CambiarContraseña.aspx");
        }
        protected void CerrarSesion_Click(object sender, EventArgs e)
        {
            WebForm1.registrado = false;

            Response.Redirect("https://localhost:44312/InicioSesion.aspx");
        }
        protected void GestorBackOnClick(object sender, EventArgs e)
        {
            if(uIS.Gestor == true && WebForm1.registrado == true) {
                Server.Transfer("GestorWeb.aspx", true);
            }
  
        }

        protected void EntradaButton_Click(object sender, EventArgs e)
        {

            String nombreEntrada = EntradaNombre_Input.Text;
            String passwordEntrada = Password_Input.Text;
            if (uIS.ContadorSecretos < 5)
            {
                if (nombreEntrada == "" || passwordEntrada == "" || uIS == null)
                {
                    Response.Write("<script>alert('Algún campo es nulo ')</script>");
                    return;
                }
                else
                {

                    Entrada entrada = uIS.CrearEntrada(passwordEntrada, nombreEntrada);
                    if (entrada == null)
                    {
                        Response.Write("<script>alert('La contraseña debe incluir un longitud de más de 8 caracteres y un número ')</script>");
                    }
                    WebForm1.db1.InsertarEntrada(entrada);
                    // Response.Write("<script>alert('Entrada Creada')</script>");
                    return;
                }

            }
            else
            {
                //Response.Write("<script>alert('Has Superado los 5 secretos por hora ')</script>");
                Response.Write("Has completado los 5 secretos por hora");
            }




        }

        //Pruebas de aceptación a exportar es solo las de nuestro requisito  es decir las de enviar entrada 
        //Tambien hay que hacer las de seguridad con selenium recorder al igual que el de nuestro requisito pero no exportarlas a nuestro github


    }
}