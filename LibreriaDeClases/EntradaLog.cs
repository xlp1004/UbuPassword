using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDeClases
{
    public enum TipoAcceso
    {
        Lectura,
        Escritura
    }

    public class EntradaLog
    {
        private Int16 idLog;
        private static Int16 contadorId = 0;
        private DateOnly fecha;
        private TimeOnly hora;
        private Usuario usuario;
        private Entrada entrada;
        private TipoAcceso acceso;

        public EntradaLog(Usuario usuario, Entrada entrada, TipoAcceso acceso)
        {

            idLog = contadorId;
            fecha = DateOnly.FromDateTime(DateTime.Now);
            hora = TimeOnly.FromDateTime(DateTime.Now);
            this.usuario = usuario;
            this.entrada = entrada;
            this.acceso = acceso;
            contadorId++;
        }

        public Int16 IdLog
        {
            get { return idLog; }
            set { idLog = value; }
        }

        public DateOnly Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public TimeOnly Hora
        {
            get { return hora; }
            set { hora = value; }
        }

        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public Entrada Entrada
        {
            get { return entrada; }
            set { entrada = value; }
        }
        public TipoAcceso Acceso
        {
            get { return acceso; }
            set { acceso = value; }
        }
    }
}
