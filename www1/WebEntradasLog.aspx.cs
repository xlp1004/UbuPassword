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
            if (WebForm1.registrado == false)
            {
                Response.Redirect("https://localhost:44338/InicioSesion.aspx");
            }

            DataTable tablaEntradaLog = new DataTable();
            tablaEntradaLog.Columns.Add("Id.", typeof(String));
            tablaEntradaLog.Columns.Add("Email", typeof(String));

            tablaEntradaLog.Columns.Add("Fecha", typeof(DateOnly));
            tablaEntradaLog.Columns.Add("HoraAcceso", typeof(String));

            tablaEntradaLog.Columns.Add("TipoAcceso", typeof(String));
            tablaEntradaLog.Columns.Add("Entrada", typeof(String));

            if (!Page.IsPostBack)
            {
                foreach (EntradaLog el in WebForm1.db1.TblEntradaLog.Values)
                {
                    if (el != null)
                    {
                        tablaEntradaLog.Rows.Add(el.IdLog, el.Usuario.EMail,el.Fecha,el.Hora.ToString(),el.Acceso.ToString(),el.Entrada.ToString());
                    }
                }
                gvwProyectos.DataSource = tablaEntradaLog;
                gvwProyectos.DataBind();
            }

        }

        protected void gvwProyectos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row = Convert.ToInt32(e.CommandArgument);
            Session["proyectoSeleccionado"] = gvwProyectos.Rows[row].Cells[0].Text;

        }

        protected void VolverAGestor(object sender, EventArgs e) {

            Server.Transfer("GestorWeb.aspx", true);
        
        }



    }
}