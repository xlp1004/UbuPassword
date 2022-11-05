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

        public Entrada(Usuario usuario, String contrasenya, String nombreEntrada)
        {
            if (usuario == null || contrasenya == null || nombreEntrada == null)
            {
                return;
            }
            if (Regex.IsMatch(nombreEntrada, patron) || contrasenya.Length < 8 || !Regex.IsMatch(contrasenya, patron2) || !Regex.IsMatch(contrasenya, patron3))
            {
                return;
            }
            this.idEntrada = contadorId;
            this.usuario = usuario;
            this.contrasenya = Encriptar(contrasenya);
            usuarios = new List<Usuario>();
            this.nombreEntrada = nombreEntrada;
            usuarios.Add(usuario);
            contadorId++;
        }

        public Int16 IdEntrada
        {
            get { return idEntrada; }
            set { idEntrada = value; }
        }

        public String NombreEntrada
        {
            get { return nombreEntrada; }
            set { nombreEntrada = value; }
        }
        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public String Contrasenya
        {
            get { return contrasenya; }
            set { contrasenya = value; }
        }

        public List<Usuario> Usuarios
        {
            get { return usuarios; }
            set { usuarios = value; }
        }

        public string Encriptar(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            SHA256 mySHA256 = SHA256.Create();
            bytes = mySHA256.ComputeHash(bytes);
            return (Encoding.ASCII.GetString(bytes));
        }

        //Metodo para añadir usuarios a la lista
        public Usuario AddUser(Usuario usuario)
        {
            if (usuario == null)
            {
                return null;
            }
            usuarios.Add(usuario);
            return usuario;
        }

        //Metodo para cambiar la descripcion
        public void DescripcionNueva(String descripcion)
        {
            if (descripcion == null)
            {
                return;
            }
            this.descripcion = descripcion;
        }

        //Metodo eliminar usuario de la lista de usuarios
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
    }
}