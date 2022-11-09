using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibreriaDeClases
{
    public class Entrada
    {
        private Int16 idEntrada;
        private String nombreEntrada;
        private static Int16 contadorId = 0;
        private String descripcion = "";
        private Usuario usuario;
        private String contrasenya;
        private List<Usuario> usuarios;

        private readonly string patron = "[!\"·$%&/()=¿¡?'_:;,|@#€*+.]";
        private readonly string patron2 = "[0-9]";
        private readonly string patron3 = "[a-zA-Z]";

        /// <summary>
        /// Constructor de las entradas
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasenya"></param>
        /// <param name="nombreEntrada"></param>
        public Entrada(Usuario usuario, String contrasenya, String nombreEntrada)
        {
            if (usuario == null || contrasenya == null || nombreEntrada == null)
            {
                this.idEntrada = -1;
                return;
            }
            if (Regex.IsMatch(nombreEntrada, patron) || contrasenya.Length < 8 || !Regex.IsMatch(contrasenya, patron2) || !Regex.IsMatch(contrasenya, patron3))
            {
                this.idEntrada = -1;
                return;
            }
            this.idEntrada = contadorId;
            this.usuario = usuario;
            this.contrasenya = Encriptar(contrasenya);
            usuarios = new List<Usuario>();
            this.nombreEntrada = nombreEntrada;
            this.descripcion = nombreEntrada;
            usuarios.Add(usuario);
            contadorId++;
        }

        /// <summary>
        /// Id de las entradas
        /// </summary>
        public Int16 IdEntrada
        {
            get { return idEntrada; }
            set { idEntrada = value; }
        }

        /// <summary>
        /// Nombre de las entradas
        /// </summary>
        public String NombreEntrada
        {
            get { return nombreEntrada; }
            set { nombreEntrada = value; }
        }

        /// <summary>
        /// Descripcion de las entradas
        /// </summary>
        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        /// <summary>
        /// Usuario de la entrada
        /// </summary>
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        /// <summary>
        /// Contrasenya de la entrada
        /// </summary>
        public String Contrasenya
        {
            get { return contrasenya; }
            set { contrasenya = value; }
        }

        /// <summary>
        /// Lista de usuarios que pueden acceder a la entrada
        /// </summary>
        public List<Usuario> Usuarios
        {
            get { return usuarios; }
            set { usuarios = value; }
        }

        /// <summary>
        /// Metodo para encriptar la contrasenya de la entrada
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string Encriptar(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            SHA256 mySHA256 = SHA256.Create();
            bytes = mySHA256.ComputeHash(bytes);
            return (Encoding.ASCII.GetString(bytes));
        }

        /// <summary>
        /// Metodo para añadir usuarios a la lista 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public void AddUser(Usuario usuario)
        {
            if (usuario == null)
            {
                return;
            }
            if (usuarios.Contains(usuario))
            {
                return;
            }
            usuarios.Add(usuario);
        }

        /// <summary>
        /// Metodo para cambiar la descripcion 
        /// </summary>
        /// <param name="descripcion"></param>
        public void DescripcionNueva(String descripcion)
        {
            if (descripcion == null)
            {
                return;
            }
            this.descripcion = descripcion;
        }

        /// <summary>
        /// Metodo eliminar usuario de la lista de usuarios 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool DeleteUser(Usuario usuario)
        {
            if (usuario == null)
            {
                return false;
            }
            if (!usuarios.Contains(usuario) || usuario.Gestor)
            {
                return false;
            }
            return usuarios.Remove(usuario);
        }

        /// <summary>
        /// Crea una entradaLog cuando el usuario lee una entrada.
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        public EntradaLog LeerEntrada(Usuario usuario)
        {
            if (usuario == null)
            {
                return null;
            }
            if (!usuarios.Contains(usuario))
            {
                return null;
            }
            EntradaLog entradaLog = new EntradaLog(usuario, this, TipoAcceso.Lectura);
            return entradaLog;
        }
    }
}