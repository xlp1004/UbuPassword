using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaDeClases;
using Data;
using DBPruebas;
using System.Diagnostics;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.Runtime.Remoting.Channels;

namespace www1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static DBPrueba db1;
       
        public static Usuario usuarioIS;
      
        public static Boolean registrado = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (db1==null)
            {
                db1 = new DBPrueba(); 
                
                Application["db"] = db1;

            }
            if (usuarioIS == null)
            {
                usuarioIS = (Usuario)Session["usuarioAutenticado"];
            }

        }
      
        public Boolean Registrado
        {
            get { return registrado; }
            set { registrado = value; }
        }
        private bool compruebaEmail(string email) {


            Usuario u = db1.LeeUsuario(email);

            if (u == null)
            {
               
                return false;
            }
            else {
               
                usuarioIS = u;
             
                return true;
            }
        }

        private bool compruebaPassword(string password)
        {
           
            
            
            password =  usuarioIS.encriptar(password);
           

            if (usuarioIS.Contrasenya == password) { return true; }
   
            return false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            
          
            if (compruebaEmail(Email_Input.Text) == true && compruebaPassword(Password_Input.Text) == true)
            {
                if (usuarioIS.Gestor == true)
                {
                    EntradaLog entradalog = new EntradaLog(usuarioIS);
                    db1.InsertarEntradaLog(entradalog);
                    registrado = true;
                    Server.Transfer("GestorWeb.aspx", true);
                 
                }
                else {
                    EntradaLog entradalog = new EntradaLog(usuarioIS);
                    db1.InsertarEntradaLog(entradalog);
                    registrado = true;
                    Server.Transfer("UsuarioWeb.aspx", true);
                  

                }
            }
            Response.Write("<script>alert('credenciales incorrectas')</script>");



        }
 
    }
}