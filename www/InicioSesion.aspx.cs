using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaDeClases;
using Data;
namespace www
{
    public partial class InicioSesion : System.Web.UI.Page
    {
        private Usuario u;
        private DBPruebas db;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = DBPruebas.GetInstance();
        }

    }
}