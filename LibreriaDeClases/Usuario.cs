using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace LibreriaDeClases
{
    public class Usuario
    {
        private Int16 idPropietario;
        private static Int16 contadorId;
        private String nombre;
        private String apellidos;
        private String eMail;
        private String contrasenya;
        private Boolean gestor = false;
        public Int16 contadorSecretos = 0;
        public const Int16 numMaxSecretosH = 5;
        private TimeOnly tiempoPrimerSecreto;
        private readonly string patron = "[!\"·$%&/()=¿¡?'_:;,|@#€*+.]";
        private readonly string patron2 = "[a-zA-Z0-9]+@ubu\\.es";
        private readonly string patron3 = "[0-9]";
        private readonly string patron4 = "[a-zA-Z]";

        /// <summary>
        /// Constructor de usuario
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellidos"></param>
        /// <param name="eMail"></param>
        /// <param name="contrasenya"></param>
        public Usuario(string nombre, string apellidos, string eMail, string contrasenya)
        {
            if(nombre == null || apellidos == null || eMail == null || contrasenya == null)
            {
                this.idPropietario = -1;
                return;
            }
            if (Regex.IsMatch(nombre, patron) || Regex.IsMatch(apellidos, patron) || !Regex.IsMatch(eMail, patron2) 
                || contrasenya.Length < 8 || !Regex.IsMatch(contrasenya, patron3) || !Regex.IsMatch(contrasenya, patron4))
            {
                this.idPropietario = -1;
                return;
            }
            this.idPropietario = contadorId;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.eMail = eMail;
            this.contrasenya = encriptar(contrasenya);
            contadorId++;
        }

        /// <summary>
        /// Id del usuario
        /// </summary>
        public Int16 IdUsuario  //El constructor del atriburo(por eso las mayusculas)
        {
            get { return idPropietario; }
            set { idPropietario = value; }
        }

        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// Apellidos del usuario
        /// </summary>
        public String Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        /// <summary>
        /// Email del usuario
        /// </summary>
        public string EMail
        {
            get { return eMail; }
            set
            { eMail = value; }
        }

        /// <summary>
        /// Contrasenya del usuario
        /// </summary>
        public String Contrasenya
        {
            get { return contrasenya; }
            set
            { contrasenya = value; }
        }

        /// <summary>
        /// Usuario es gestor o no
        /// </summary>
        public Boolean Gestor
        {
            get { return gestor; }
            set { gestor = value; }
        }

        /// <summary>
        /// Contador de entradas del usuario
        /// </summary>
        public Int16 ContadorSecretos
        {
            get { return contadorSecretos; }
            set { contadorSecretos = value; }
        }

        /// <summary>
        /// Tiempo del primer secreto de la hora del usuario
        /// </summary>
        public TimeOnly TiempoPrimerSecreto
        {
            get { return tiempoPrimerSecreto; }
            set { tiempoPrimerSecreto = value; }
        }

        /// <summary>
        /// Metodo para encriptar la contrasenya
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string encriptar(string password)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);
            SHA256 mySHA256 = SHA256.Create();
            bytes = mySHA256.ComputeHash(bytes);
            return (System.Text.Encoding.ASCII.GetString(bytes));
        }

        /// <summary>
        /// Metodo para convertir un usuario en gestor, si el usuario actual es un gestor.
        /// </summary>
        /// <param name="usuario"></param>
        public bool CrearGestor(Usuario usuario)
        {
            if (usuario == null)
            {
                return false;
            }
            else if (gestor && usuario.gestor == false)
            {
                usuario.gestor = true;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Metodo para crear un nuevo usuario, si el usuario actual es gestor.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellidos"></param>
        /// <param name="eMail"></param>
        /// <param name="contrasenya"></param>
        /// <returns></returns>
        public Usuario CrearUsuario(string nombre, string apellidos, string eMail, string contrasenya)
        {
            Usuario usuario;
            if (gestor && nombre != null && apellidos != null && eMail != null && contrasenya != null)
            {
                usuario = new Usuario(nombre, apellidos, eMail, contrasenya);
                return usuario;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Metodo para cambiar la contraseña de el usuario.
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="password"></param>
        public void CambiarContrasenya(String oldPassword, String password)
        {
            if (password == null || oldPassword == null)
            {
                return;
            }
            else if (oldPassword.Equals(password))
            {
                return;
            }
            else if (password.Length < 8 || !Regex.IsMatch(password, patron3) || !Regex.IsMatch(password, patron4))
            {
                return;
            }
            else if (encriptar(oldPassword).Equals(contrasenya))
            {
                 contrasenya = encriptar(password);
            }
        }

        /// <summary>
        /// Metodo para crear una entrada.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Entrada CrearEntrada(String contrasenya, String nombreEntrada)
        {
            Entrada entrada;
            if (contrasenya == null || nombreEntrada == null)
            {
                return null;
            }
            else
            {
                ReiniciarContador();
                if(contadorSecretos < numMaxSecretosH)
                {
                    if (contadorSecretos == 0)
                    {
                          tiempoPrimerSecreto = TimeOnly.FromDateTime(DateTime.Now);
                    }
                    entrada = new Entrada(this, contrasenya, nombreEntrada);
                    if (entrada.IdEntrada == -1)
                    {
                        return null;
                    }
                    contadorSecretos++;
                }
                else
                {
                    return null;
                }
            }
            return entrada;
        }

        /// <summary>
        /// Metodo para reiniciar los secretos de esta hora.
        /// </summary>
        public void ReiniciarContador()
        {
            TimeOnly tiempoActual = TimeOnly.FromDateTime(DateTime.Now);
            TimeOnly tiempoPrimerSecretoPrueba = tiempoPrimerSecreto;
            TimeOnly tiempoPrimerSecretoPrueba2 = tiempoPrimerSecreto;
            if (tiempoPrimerSecretoPrueba.AddMinutes(60) <= tiempoActual && tiempoPrimerSecretoPrueba2 <= tiempoActual.AddMinutes(-60))
            {
                contadorSecretos = 0;
            }

            
        }
    }
}