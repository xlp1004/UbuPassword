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

        [TestMethod()]
        public void UsuarioCreado()
        {
            Assert.IsNotNull(usuarioPrueba);
            Assert.IsNotNull(usuarioPruebaNoGestor);
            Assert.IsNotNull(usuarioPrueba3);
            Assert.IsNull(usuarioPrueba2);
            Assert.IsInstanceOfType(usuarioPrueba, typeof(Usuario));
            Assert.IsInstanceOfType(usuarioPruebaNoGestor, typeof(Usuario));
            Assert.IsNotInstanceOfType(usuarioPrueba2, typeof(Usuario));
            Assert.IsInstanceOfType(usuarioPrueba3, typeof(Usuario));
        }

        [TestMethod]
        public void ParametrosUsuarioCreado()
        {
            Assert.IsNotNull(usuarioPrueba.Nombre);
            Assert.IsNotNull(usuarioPrueba.Apellidos);
            Assert.IsNotNull(usuarioPrueba.EMail);
            Assert.IsNotNull(usuarioPrueba.Contrasenya);
            Assert.IsNull(usuarioPrueba3.Nombre);
            Assert.IsNull(usuarioPrueba3.Apellidos);
            Assert.IsNull(usuarioPrueba3.EMail);
            Assert.IsNull(usuarioPrueba3.Contrasenya);
            Assert.IsFalse(usuarioPrueba3.Gestor);
            Assert.IsNotNull(usuarioPrueba3.IdUsuario);
            Assert.IsTrue(usuarioPrueba3.IdUsuario == -1);
        }

        [TestMethod()]
        public void TestIdDistintas()
        {
            Assert.IsInstanceOfType(usuarioPrueba.IdUsuario, typeof(Int16));
            Assert.IsInstanceOfType(usuarioPruebaNoGestor.IdUsuario, typeof(Int16));
            Assert.IsTrue(usuarioPrueba.IdUsuario < usuarioPruebaNoGestor.IdUsuario);
            Assert.IsTrue((usuarioPrueba.IdUsuario + 1) == usuarioPruebaNoGestor.IdUsuario);
        }

        [TestMethod()]
        public void TestUsuarioNombreValido()
        {
            Usuario usuarioPrueba4 = new Usuario("@", Apellidos, Email, Password);

            Assert.IsNull(usuarioPrueba3.Nombre);
            Assert.IsNull(usuarioPrueba4.Nombre);
            Assert.IsInstanceOfType(usuarioPrueba.Nombre, typeof(String));
            Assert.AreEqual(usuarioPrueba.Nombre, "Alvaro");
            Assert.AreEqual(usuarioPruebaNoGestor.Nombre, "Adolfo");
        }

        [TestMethod()]
        public void TestUsuarioApellidoValido()
        {
            Usuario usuarioPrueba4 = new Usuario(Nombre, "@", Email, Password);

            Assert.IsNull(usuarioPrueba4.Apellidos);
            Assert.IsNull(usuarioPrueba3.Apellidos);
            Assert.IsInstanceOfType(usuarioPrueba.Apellidos, typeof(String));
            Assert.AreEqual(usuarioPrueba.Apellidos, "Lopez");
            Assert.AreEqual(usuarioPruebaNoGestor.Apellidos, "Vine");
        }

        [TestMethod()]
        public void TestUsuarioEmailValido()
        {
            Usuario usuarioPrueba4 = new Usuario(Nombre, Apellidos, "-", Password);

            Assert.IsNull(usuarioPrueba4.EMail);
            Assert.IsNull(usuarioPrueba3.EMail);
            Assert.IsInstanceOfType(usuarioPrueba.EMail, typeof(String));
            Assert.AreEqual(usuarioPrueba.EMail, "Alv@ubu.es");
            Assert.AreEqual(usuarioPruebaNoGestor.EMail, "Adf@ubu.es");
        }

        [TestMethod()]
        public void TestUsuarioContrasenyaValido()
        {
            Usuario usuarioPruebaMala1 = new Usuario(Nombre, Apellidos, Email, "1234567");
            Usuario usuarioPruebaMala2 = new Usuario(Nombre, Apellidos, Email, "12345678");
            Usuario usuarioPruebaMala3 = new Usuario(Nombre, Apellidos, Email, "abcdefghi");

            Assert.IsNull(usuarioPruebaMala1.Contrasenya);
            Assert.IsNull(usuarioPruebaMala2.Contrasenya);
            Assert.IsNull(usuarioPruebaMala3.Contrasenya);
            Assert.IsNull(usuarioPrueba3.Contrasenya);
            Assert.IsInstanceOfType(usuarioPrueba.Contrasenya, typeof(String));
            Assert.AreEqual(usuarioPrueba.Contrasenya, usuarioPrueba.encriptar("pass1234"));
            Assert.AreEqual(usuarioPruebaNoGestor.Contrasenya, usuarioPruebaNoGestor.encriptar("contra4321"));
        }

        [TestMethod()]
        public void TestEsGestor()
        {
            Assert.IsFalse(usuarioPrueba.Gestor);
            usuarioPrueba.Gestor = true;
            Assert.IsTrue(usuarioPrueba.Gestor);
        }

        [TestMethod()]
        public void CrearGestorTest()
        {
            Usuario usuarioPrueba4 = new Usuario(Nombre, Apellidos, Email, Password);
            usuarioPrueba.Gestor = true;

            Assert.IsFalse(usuarioPrueba.CrearGestor(usuarioPrueba2));
            Assert.IsFalse(usuarioPruebaNoGestor.CrearGestor(usuarioPrueba4));
            Assert.IsFalse(usuarioPrueba.CrearGestor(usuarioPrueba));
            Assert.IsTrue(usuarioPrueba.CrearGestor(usuarioPrueba4));
        }

        [TestMethod()]
        public void CrearUsuarioTest()
        {
            Usuario usuarioPrueba4 = usuarioPrueba.CrearUsuario(Nombre, Apellidos, Email, Password);
            Assert.IsNull(usuarioPrueba4);

            usuarioPrueba.Gestor = true;

            usuarioPrueba4 = usuarioPrueba.CrearUsuario(null, Apellidos, Email, Password);
            Assert.IsNull(usuarioPrueba4);

            usuarioPrueba4 = usuarioPrueba.CrearUsuario(Nombre, null, Email, Password);
            Assert.IsNull(usuarioPrueba4);

            usuarioPrueba4 = usuarioPrueba.CrearUsuario(Nombre, Apellidos, null, Password);
            Assert.IsNull(usuarioPrueba4);

            usuarioPrueba4 = usuarioPrueba.CrearUsuario(Nombre, Apellidos, Email, null);
            Assert.IsNull(usuarioPrueba4);

            usuarioPrueba4 = usuarioPrueba.CrearUsuario(Nombre, Apellidos, Email, Password);
            Assert.IsNotNull(usuarioPrueba4);
        }

        [TestMethod()]
        public void CambiarContrasenyaTest()
        {
            Usuario usuarioPrueba4 = new Usuario(Nombre, Apellidos, Email, Password);

            usuarioPrueba4.CambiarContrasenya(Password, null);
            Assert.AreEqual(usuarioPrueba4.Contrasenya, usuarioPrueba4.encriptar(Password));

            usuarioPrueba4.CambiarContrasenya(null, Password2);
            Assert.AreEqual(usuarioPrueba4.Contrasenya, usuarioPrueba4.encriptar(Password));

            usuarioPrueba4.CambiarContrasenya("otraPass123", Password2);
            Assert.AreEqual(usuarioPrueba4.Contrasenya, usuarioPrueba4.encriptar(Password));

            usuarioPrueba4.CambiarContrasenya(Password, Password2);
            Assert.AreEqual(usuarioPrueba4.Contrasenya, usuarioPrueba4.encriptar(Password2));
        }

        [TestMethod()]
        public void CambiarContrasenyaUsuarioGestorTest()
        {
            Usuario usuarioPrueba4 = new Usuario(Nombre, Apellidos, Email, Password);

            usuarioPrueba.CambiarContrasenyaUsuarioGestor(Password, Password2, usuarioPrueba4);
            Assert.AreEqual(usuarioPrueba4.Contrasenya, usuarioPrueba4.encriptar(Password));

            usuarioPrueba.Gestor = true;

            usuarioPrueba.CambiarContrasenyaUsuarioGestor(null, Password2, usuarioPrueba4);
            Assert.AreEqual(usuarioPrueba4.Contrasenya, usuarioPrueba4.encriptar(Password));

            usuarioPrueba.CambiarContrasenyaUsuarioGestor(Password, null, usuarioPrueba4);
            Assert.AreEqual(usuarioPrueba4.Contrasenya, usuarioPrueba4.encriptar(Password));

            usuarioPrueba.CambiarContrasenyaUsuarioGestor(Password, Password2, null);
            Assert.AreEqual(usuarioPrueba4.Contrasenya, usuarioPrueba4.encriptar(Password));

            usuarioPrueba.CambiarContrasenyaUsuarioGestor("otraPass123", Password2, usuarioPrueba4);
            Assert.AreEqual(usuarioPrueba4.Contrasenya, usuarioPrueba4.encriptar(Password));

            usuarioPrueba.CambiarContrasenyaUsuarioGestor(Password, Password2, usuarioPrueba4);
            Assert.AreEqual(usuarioPrueba4.Contrasenya, usuarioPrueba4.encriptar(Password2));
        }

        [TestMethod()]
        public void CrearEntradaTest()
        {
            Assert.IsTrue(usuarioPrueba.ContadorSecretos == 0);
            Entrada entrada = usuarioPrueba.CrearEntrada(Password, Nombre);
            Assert.IsNotNull(entrada);
            Entrada entrada1 = usuarioPrueba.CrearEntrada(null, Nombre);
            Assert.IsNull(entrada1);
            Entrada entrada2 = usuarioPrueba.CrearEntrada(Password, null);
            Assert.IsNull(entrada2);
            Assert.IsTrue(usuarioPrueba.ContadorSecretos == 1);
            usuarioPrueba.CrearEntrada(Password, Nombre);
            Assert.IsTrue(usuarioPrueba.ContadorSecretos == 2);
            usuarioPrueba.CrearEntrada(Password, Nombre);
            Assert.IsTrue(usuarioPrueba.ContadorSecretos == 3);
            usuarioPrueba.CrearEntrada(Password, Nombre);
            Assert.IsTrue(usuarioPrueba.ContadorSecretos == 4);
            usuarioPrueba.CrearEntrada(Password, Nombre);
            Assert.IsTrue(usuarioPrueba.ContadorSecretos == 5);
            Entrada entrada3 = usuarioPrueba.CrearEntrada(Password, Nombre);
            Assert.IsTrue(usuarioPrueba.ContadorSecretos == 5);
            Assert.IsNull(entrada3);


            Assert.IsTrue(usuarioPruebaNoGestor.ContadorSecretos == 0);
            usuarioPruebaNoGestor.CrearEntrada(Password, Nombre);
            Assert.IsTrue(usuarioPruebaNoGestor.ContadorSecretos == 1);
        }

        [TestMethod()]
        public void ReiniciarContadorTest()
        {
            Usuario usuarioPrueba4 = new Usuario(Nombre, Apellidos, Email, Password);
            usuarioPrueba4.CrearEntrada(Password, Nombre);
            Assert.IsTrue(usuarioPrueba4.ContadorSecretos == 1);
            TimeOnly tiempoPrimerSMasTiempo = (usuarioPrueba4.TiempoPrimerSecreto).AddMinutes(-60);

            usuarioPrueba4.ReiniciarContador();
            Assert.IsTrue(usuarioPrueba4.ContadorSecretos == 1);

            usuarioPrueba4.TiempoPrimerSecreto = tiempoPrimerSMasTiempo;
            usuarioPrueba4.ReiniciarContador();
            Assert.IsTrue(usuarioPrueba4.ContadorSecretos == 0);

        }
    }
}