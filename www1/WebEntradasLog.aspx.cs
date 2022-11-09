using LibreriaDeClases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace www1
{
    public partial class WebEntradasLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (WebForm1.registrado == false)
            {
                Response.Redirect("https://localhost:44338/InicioSesion.aspx");
            }*/

            DataTable tablaEntradaLog = new DataTable();
            tablaEntradaLog.Columns.Add("Id.", typeof(String));
            tablaEntradaLog.Columns.Add("Email", typeof(String));
            tablaEntradaLog.Columns.Add("HoraAcceso", typeof(DateOnly));

          /*  if (!Page.IsPostBack)
            {
                foreach (EntradaLog entradaLog in )
                {
                    if (e != null)
                    {
                        tablaEntradaLog.Rows.Add(e.IdLog, e.Usuario.EMail,e.Fecha);
                    }
                }
                gvwProyectos.DataSource = tablaEntradaLog;
                gvwProyectos.DataBind();
            }*/

        }

        protected void gvwProyectos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            

        }
    }
}