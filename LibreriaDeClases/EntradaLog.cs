using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDeClases
{
    /// <summary>
    /// Tipo de acceso de el historial de entradas
    /// </summary>
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

        /// <summary>
        /// Constructor de las entradasLog
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="entrada"></param>
        /// <param name="acceso"></param>
        public EntradaLog(Usuario usuario, Entrada entrada, TipoAcceso acceso)
        {
            if(entrada == null || usuario == null)
            {
                idLog = -1;
                return;
            }
            idLog = contadorId;
            fecha = DateOnly.FromDateTime(DateTime.Now);
            hora = TimeOnly.FromDateTime(DateTime.Now);
            this.usuario = usuario;
            this.entrada = entrada;
            this.acceso = acceso;
            contadorId++;
        }

        /// <summary>
        /// Id de la entradaLog
        /// </summary>
        public Int16 IdLog
        {
            get { return idLog; }
            set { idLog = value; }
        }

        /// <summary>
        /// Fecha de la entradaLog
        /// </summary>
        public DateOnly Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        /// <summary>
        /// Hora de lasentradaLog
        /// </summary>
        public TimeOnly Hora
        {
            get { return hora; }
            set { hora = value; }
        }

        /// <summary>
        /// Usuario de la entradaLog
        /// </summary>
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        /// <summary>
        /// Entrada de la entradaLog
        /// </summary>
        public Entrada Entrada
        {
            get { return entrada; }
            set { entrada = value; }
        }

        /// <summary>
        /// Tipo de acceso de la entradaLog
        /// </summary>
        public TipoAcceso Acceso
        {
            get { return acceso; }
            set { acceso = value; }
        }
    }
}
