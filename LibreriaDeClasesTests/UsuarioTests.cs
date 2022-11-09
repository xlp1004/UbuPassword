using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibreriaDeClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibreriaDeClases.Tests
{
    [TestClass()]
    public class UsuarioTests
    {

        private const string Nombre = "Alvaro";
        private const string Apellidos = "Lopez";
        private const string Email = "Alv@ubu.es";
        private const string Password = "pass1234";

        private const string Nombre2 = "Adolfo";
        private const string Apellidos2 = "Vine";
        private const string Email2 = "Adf@ubu.es";
        private const string Password2 = "contra4321";

        private Usuario usuarioPrueba = new Usuario(Nombre, Apellidos, Email, Password);
        private Usuario usuarioPruebaNoGestor = new Usuario(Nombre2, Apellidos2, Email2, Password2);
        private Usuario usuarioPrueba2 = null;
        private Usuario usuarioPrueba3 = new Usuario(null, null, null, null);

        /// <summary>
        /// Test de usuarios creados
        /// </summary>
        [TestMethod()]
        public void UsuarioCreado()
        {
            Assert.IsNotNull(usuarioPrueba);                                    //Usuario gestor correcto
            Assert.IsInstanceOfType(usuarioPrueba, typeof(Usuario));
            Assert.IsNotNull(usuarioPruebaNoGestor);                            //Usuario no gestor correcto
            Assert.IsInstanceOfType(usuarioPruebaNoGestor, typeof(Usuario));
            Assert.IsNotNull(usuarioPrueba3);                                   //Usuario con datos null
            Assert.IsInstanceOfType(usuarioPrueba3, typeof(Usuario));
            Assert.IsNull(usuarioPrueba2);                                      //Usuario null
            Assert.IsNotInstanceOfType(usuarioPrueba2, typeof(Usuario));
        }

        /// <summary>
        /// Test general de los datos del usuario
        /// </summary>
        [TestMethod]
        public void ParametrosUsuarioCreado()
        {
            Assert.IsNotNull(usuarioPrueba.Nombre);                             //Usuario correcto
            Assert.IsNotNull(usuarioPrueba.Apellidos);
            Assert.IsNotNull(usuarioPrueba.EMail);
            Assert.IsNotNull(usuarioPrueba.Contrasenya);
            Assert.IsNull(usuarioPrueba3.Nombre);                               //Usuario con datos null
            Assert.IsNull(usuarioPrueba3.Apellidos);
            Assert.IsNull(usuarioPrueba3.EMail);
            Assert.IsNull(usuarioPrueba3.Contrasenya);
            Assert.IsFalse(usuarioPrueba3.Gestor);
            Assert.IsNotNull(usuarioPrueba3.IdUsuario);
            Assert.IsTrue(usuarioPrueba3.IdUsuario == -1);
        }

        /// <summary>
        /// Test de Id de los usuarios
        /// </summary>
        [TestMethod()]
        public void TestIdDistintas()
        {
            Assert.IsInstanceOfType(usuarioPrueba.IdUsuario, typeof(Int16));                    //Las id son de tipo int
            Assert.IsInstanceOfType(usuarioPruebaNoGestor.IdUsuario, typeof(Int16));
            Assert.IsTrue(usuarioPrueba.IdUsuario < usuarioPruebaNoGestor.IdUsuario);           //Dos usuarios creados tienen id conjutas
            Assert.IsTrue((usuarioPrueba.IdUsuario + 1) == usuarioPruebaNoGestor.IdUsuario);
        }

        /// <summary>
        /// Test sobre la valided del nombre del usuario
        /// </summary>
        [TestMethod()]
        public void TestUsuarioNombreValido()
        {
            Usuario usuarioPrueba4 = new Usuario("@", Apellidos, Email, Password);
            Usuario usuarioPrueba5 = new Usuario(null, Apellidos, Email, Password);

            Assert.IsNull(usuarioPrueba3.Nombre);                               //Nombres no validos, siendo el usuario existente
            Assert.IsNull(usuarioPrueba4.Nombre);
            Assert.IsNull(usuarioPrueba5.Nombre);
            Assert.IsNotNull(usuarioPrueba5);
            Assert.IsInstanceOfType(usuarioPrueba.Nombre, typeof(String));      //Nombres validos
            Assert.AreEqual(usuarioPrueba.Nombre, "Alvaro");
            Assert.AreEqual(usuarioPruebaNoGestor.Nombre, "Adolfo");
        }

        /// <summary>
        /// Test sobre la valided del apellido del usuario
        /// </summary>
        [TestMethod()]
        public void TestUsuarioApellidoValido()
        {
            Usuario usuarioPrueba4 = new Usuario(Nombre, "@", Email, Password);
            Usuario usuarioPrueba5 = new Usuario(Nombre, null, Email, Password);

            Assert.IsNull(usuarioPrueba4.Apellidos);                            //Apellidos no validos, siendo el usuario existente
            Assert.IsNull(usuarioPrueba3.Apellidos);
            Assert.IsNull(usuarioPrueba5.Apellidos);
            Assert.IsNotNull(usuarioPrueba5);
            Assert.IsInstanceOfType(usuarioPrueba.Apellidos, typeof(String));   //Apellidos validos
            Assert.AreEqual(usuarioPrueba.Apellidos, "Lopez");
            Assert.AreEqual(usuarioPruebaNoGestor.Apellidos, "Vine");
        }

        /// <summary>
        /// Test sobre la valided del email del usuario
        /// </summary>
        [TestMethod()]
        public void TestUsuarioEmailValido()
        {
            Usuario usuarioPrueba4 = new Usuario(Nombre, Apellidos, "-", Password);
            Usuario usuarioPrueba5 = new Usuario(Nombre, Apellidos, null, Password);

            Assert.IsNull(usuarioPrueba4.EMail);                                //Email no validos, siendo el usuario existente
            Assert.IsNull(usuarioPrueba3.EMail);
            Assert.IsNull(usuarioPrueba5.EMail);
            Assert.IsNotNull(usuarioPrueba5);
            Assert.IsInstanceOfType(usuarioPrueba.EMail, typeof(String));       //Email validos
            Assert.AreEqual(usuarioPrueba.EMail, "Alv@ubu.es");
            Assert.AreEqual(usuarioPruebaNoGestor.EMail, "Adf@ubu.es");
        }

        /// <summary>
        /// Test sobre la valided de la contrasenya del usuario
        /// </summary>
        [TestMethod()]
        public void TestUsuarioContrasenyaValido()
        {
            Usuario usuarioPruebaMala1 = new Usuario(Nombre, Apellidos, Email, "1234567");
            Usuario usuarioPruebaMala2 = new Usuario(Nombre, Apellidos, Email, "12345678");
            Usuario usuarioPruebaMala3 = new Usuario(Nombre, Apellidos, Email, "abcdefghi");
            Usuario usuarioPruebaMala4 = new Usuario(Nombre, Apellidos, Email, null);

            Assert.IsNull(usuarioPruebaMala1.Contrasenya);                                                      //Contrasenya no validas, siendo el usuario existente
            Assert.IsNull(usuarioPruebaMala2.Contrasenya);
            Assert.IsNull(usuarioPruebaMala3.Contrasenya);
            Assert.IsNull(usuarioPruebaMala4.Contrasenya);
            Assert.IsNotNull(usuarioPruebaMala4);
            Assert.IsNull(usuarioPrueba3.Contrasenya);
            Assert.IsInstanceOfType(usuarioPrueba.Contrasenya, typeof(String));                                 //Contrasenyas validas
            Assert.AreEqual(usuarioPrueba.Contrasenya, usuarioPrueba.encriptar("pass1234"));
            Assert.AreEqual(usuarioPruebaNoGestor.Contrasenya, usuarioPruebaNoGestor.encriptar("contra4321"));
        }

        /// <summary>
        /// Test sobre si el usuario es gestor o no
        /// </summary>
        [TestMethod()]
        public void TestEsGestor()
        {
            Assert.IsFalse(usuarioPrueba.Gestor);
            usuarioPrueba.Gestor = true;
            Assert.IsTrue(usuarioPrueba.Gestor);
        }

        /// <summary>
        /// Test del metodo de convertir un usuario a gestor
        /// </summary>
        [TestMethod()]
        public void CrearGestorTest()
        {
            Usuario usuarioPrueba4 = new Usuario(Nombre, Apellidos, Email, Password);
            usuarioPrueba.Gestor = true;

            Assert.IsFalse(usuarioPrueba.CrearGestor(usuarioPrueba2));          //Usuario 2 es null
            Assert.IsFalse(usuarioPruebaNoGestor.CrearGestor(usuarioPrueba4));  //Usuario 1 es no gestor
            Assert.IsFalse(usuarioPrueba.CrearGestor(usuarioPrueba));           //Usuario 2 es gestor
            Assert.IsTrue(usuarioPrueba.CrearGestor(usuarioPrueba4));           //Usuario 1 es gestor y 2 no lo es
        }

        /// <summary>
        /// Test del metodo pra crear usuarios
        /// </summary>
        [TestMethod()]
        public void CrearUsuarioTest()
        {
            Usuario usuarioPrueba4 = usuarioPrueba.CrearUsuario(Nombre, Apellidos, Email, Password);
            Assert.IsNull(usuarioPrueba4);                                                              //Usuario 1 no es gestor

            usuarioPrueba.Gestor = true;

            usuarioPrueba4 = usuarioPrueba.CrearUsuario(null, Apellidos, Email, Password);
            Assert.IsNull(usuarioPrueba4);                                                              //Nombre null

            usuarioPrueba4 = usuarioPrueba.CrearUsuario(Nombre, null, Email, Password);
            Assert.IsNull(usuarioPrueba4);                                                              //Apellidos null

            usuarioPrueba4 = usuarioPrueba.CrearUsuario(Nombre, Apellidos, null, Password);
            Assert.IsNull(usuarioPrueba4);                                                              //Email null

            usuarioPrueba4 = usuarioPrueba.CrearUsuario(Nombre, Apellidos, Email, null);
            Assert.IsNull(usuarioPrueba4);                                                              //Password null

            usuarioPrueba4 = usuarioPrueba.CrearUsuario(Nombre, Apellidos, Email, Password);
            Assert.IsNotNull(usuarioPrueba4);                                                           //Datos correctos.
        }

        /// <summary>
        /// Test sobre el metodo de cambiar contrasenyas del usuario
        /// </summary>
        [TestMethod()]
        public void CambiarContrasenyaTest()
        {
            Usuario usuarioPrueba4 = new Usuario(Nombre, Apellidos, Email, Password);

            usuarioPrueba4.CambiarContrasenya(Password, null);
            Assert.AreEqual(usuarioPrueba4.Contrasenya, usuarioPrueba4.encriptar(Password));            // Nueva contraseña null. Usuario sigue con su contraseña vieja

            usuarioPrueba4.CambiarContrasenya(null, Password2);
            Assert.AreEqual(usuarioPrueba4.Contrasenya, usuarioPrueba4.encriptar(Password));            // Vieja contraseña null. Usuario sigue con su contraseña vieja

            usuarioPrueba4.CambiarContrasenya("otraPass123", Password2);
            Assert.AreEqual(usuarioPrueba4.Contrasenya, usuarioPrueba4.encriptar(Password));            // Vieja contraseña no coincide. Usuario sigue con su contraseña vieja

            usuarioPrueba4.CambiarContrasenya(Password, Password2);
            Assert.AreEqual(usuarioPrueba4.Contrasenya, usuarioPrueba4.encriptar(Password2));           // La contraseña se cambia
        }

        /// <summary>
        /// Test sobre el metodo de cambiar la contrasenya de otro usuario
        /// </summary>
        [TestMethod()]
        public void CambiarContrasenyaUsuarioGestorTest()
        {
            Usuario usuarioPrueba4 = new Usuario(Nombre, Apellidos, Email, Password);

            usuarioPrueba.CambiarContrasenyaUsuarioGestor(Password, Password2, usuarioPrueba4);
            Assert.AreEqual(usuarioPrueba4.Contrasenya, usuarioPrueba4.encriptar(Password));            //Usuario no es gestor

            usuarioPrueba.Gestor = true;

            usuarioPrueba.CambiarContrasenyaUsuarioGestor(null, Password2, usuarioPrueba4);
            Assert.AreEqual(usuarioPrueba4.Contrasenya, usuarioPrueba4.encriptar(Password));            // Vieja contraseña null. Usuario sigue con su contraseña vieja

            usuarioPrueba.CambiarContrasenyaUsuarioGestor(Password, null, usuarioPrueba4);
            Assert.AreEqual(usuarioPrueba4.Contrasenya, usuarioPrueba4.encriptar(Password));            // Nueva contraseña null. Usuario sigue con su contraseña vieja

            usuarioPrueba.CambiarContrasenyaUsuarioGestor(Password, Password2, null);
            Assert.AreEqual(usuarioPrueba4.Contrasenya, usuarioPrueba4.encriptar(Password));            //Usuario a cambiar la contraseña no existe

            usuarioPrueba.CambiarContrasenyaUsuarioGestor("otraPass123", Password2, usuarioPrueba4);
            Assert.AreEqual(usuarioPrueba4.Contrasenya, usuarioPrueba4.encriptar(Password));           // Vieja contraseña no coincide. Usuario sigue con su contraseña vieja

            usuarioPrueba.CambiarContrasenyaUsuarioGestor(Password, Password2, usuarioPrueba4);
            Assert.AreEqual(usuarioPrueba4.Contrasenya, usuarioPrueba4.encriptar(Password2));          // La contraseña se cambia
        }

        /// <summary>
        /// Test del metodo de crear entradas
        /// </summary>
        [TestMethod()]
        public void CrearEntradaTest()
        {
            Assert.IsTrue(usuarioPrueba.ContadorSecretos == 0);                                         //Contador de secretos por defecto es 0
            Entrada entrada = usuarioPrueba.CrearEntrada(Password, Nombre);
            Assert.IsNotNull(entrada);
            Entrada entrada1 = usuarioPrueba.CrearEntrada(null, Nombre);
            Assert.IsNull(entrada1);                                                 
            Entrada entrada2 = usuarioPrueba.CrearEntrada(Password, null);
            Assert.IsNull(entrada2);
            Entrada entrada3 = usuarioPrueba.CrearEntrada("a", Nombre);
            Assert.IsNull(entrada3);
            Assert.IsTrue(usuarioPrueba.ContadorSecretos == 1);                                         //Solo una entrada valida creada. Contador aumenta en 1
            usuarioPrueba.CrearEntrada(Password, Nombre);
            Assert.IsTrue(usuarioPrueba.ContadorSecretos == 2);                                         //Contador aumenta a 2 entradas
            usuarioPrueba.CrearEntrada(Password, Nombre);
            Assert.IsTrue(usuarioPrueba.ContadorSecretos == 3);                                         //Contador aumenta a 4 entradas
            usuarioPrueba.CrearEntrada(Password, Nombre);
            Assert.IsTrue(usuarioPrueba.ContadorSecretos == 4);                                         //Contador aumenta a 4 entradas
            usuarioPrueba.CrearEntrada(Password, Nombre);
            Assert.IsTrue(usuarioPrueba.ContadorSecretos == 5);                                         //Contador aumenta a 5 entradas
            Entrada entrada4 = usuarioPrueba.CrearEntrada(Password, Nombre);                            
            Assert.IsTrue(usuarioPrueba.ContadorSecretos == 5);                                         //Contador lleno, se mantiene en 5
            Assert.IsNull(entrada4);                                                                    //Futuras entradas son null

            Assert.IsTrue(usuarioPruebaNoGestor.ContadorSecretos == 0);                                 //Un usuario nuevo puede crear entradas de forma independiente
            usuarioPruebaNoGestor.CrearEntrada(Password, Nombre);
            Assert.IsTrue(usuarioPruebaNoGestor.ContadorSecretos == 1);
        }

        /// <summary>
        /// Test sobre el metodo de reiniciar el contador de secretos
        /// </summary>
        [TestMethod()]
        public void ReiniciarContadorTest()
        {
            Usuario usuarioPrueba4 = new Usuario(Nombre, Apellidos, Email, Password);
            usuarioPrueba4.CrearEntrada(Password, Nombre);
            Assert.IsTrue(usuarioPrueba4.ContadorSecretos == 1);                                        //Solo hay una entrada
            TimeOnly tiempoPrimerSMasTiempo = (usuarioPrueba4.TiempoPrimerSecreto).AddMinutes(-60);

            usuarioPrueba4.ReiniciarContador();
            Assert.IsTrue(usuarioPrueba4.ContadorSecretos == 1);                                        //No ha pasado una hora, no se reinicia el tiempo

            usuarioPrueba4.TiempoPrimerSecreto = tiempoPrimerSMasTiempo;
            usuarioPrueba4.ReiniciarContador();
            Assert.IsTrue(usuarioPrueba4.ContadorSecretos == 0);                                        //Se reinicia el contador

        }
    }
}